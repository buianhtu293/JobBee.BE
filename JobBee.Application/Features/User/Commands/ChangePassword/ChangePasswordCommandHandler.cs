using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.User.Commands.ChangePassword
{
	public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ApiResponse<ChangePasswordDto>>
	{
		private readonly IMapper _mapper;
		private readonly IUserRepository _userRepository;
		private readonly IUnitOfWork<Domain.Entities.User, Guid> _unitOfWork;
		private readonly IPasswordHasher _passwordHasher;

		public ChangePasswordCommandHandler(IMapper mapper, 
			IUserRepository userRepository, 
			IUnitOfWork<Domain.Entities.User, Guid> unitOfWork, 
			IPasswordHasher passwordHasher)
		{
			_mapper = mapper;
			_userRepository = userRepository;
			_unitOfWork = unitOfWork;
			_passwordHasher = passwordHasher;
		}

		public async Task<ApiResponse<ChangePasswordDto>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
		{
			var validator = new ChangePasswordCommandValidator();
			var validatorResult = await validator.ValidateAsync(request);

			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Password", validatorResult);
			}

			var user = await _userRepository.GetByEmailAsync(request.Email);
			if (user == null)
			{
				throw new NotFoundException(nameof(user), request.Email);
			}

			if(!_passwordHasher.Verify(request.OldPassword, user.PasswordHash))
			{
				throw new BadRequestException("Invalid Old Password", validatorResult);
			}

			user.PasswordHash = _passwordHasher.Hash(request.Password);
			_userRepository.UpdatePassword(user);
			await _unitOfWork.SaveChangesAsync();

			var changePasswordUser = _mapper.Map<ChangePasswordDto>(user);
			var data = new ApiResponse<ChangePasswordDto>("Success", 200, changePasswordUser);

			return data;
		}
	}
}
