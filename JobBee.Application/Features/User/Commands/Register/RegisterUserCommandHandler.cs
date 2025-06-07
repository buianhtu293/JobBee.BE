using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.User.Commands.Register
{
	public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ApiResponse<RegisterUserDto>>
	{
		private readonly IMapper _mapper;
		private readonly IUserRepository _userRepository;
		private readonly IUnitOfWork<Domain.Entities.User, Guid> _unitOfWork;
		private readonly IPasswordHasher _passwordHasher;
		private readonly IMediator _mediator;

		public RegisterUserCommandHandler(IMapper mapper, 
			IUserRepository userRepository, 
			IUnitOfWork<Domain.Entities.User, Guid> unitOfWork,
			IPasswordHasher passwordHasher,
			IMediator mediator)
		{
			_mapper = mapper;
			_userRepository = userRepository;
			_unitOfWork = unitOfWork;
			_passwordHasher = passwordHasher;
			_mediator = mediator;
		}

		public async Task<ApiResponse<RegisterUserDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
		{
			var validator = new RegisterUserCommandValidator(_userRepository);
			var validatorResult = await validator.ValidateAsync(request);

			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid user", validatorResult);
			}

			var userToCreate = _mapper.Map<Domain.Entities.User>(request);
			userToCreate.Id = Guid.NewGuid();
			userToCreate.UserName = request.UserName;
			userToCreate.NormalizedUserName = request.UserName.ToUpper();
			userToCreate.Email = request.Email;
			userToCreate.NormalizedEmail = request.Email.ToUpper();
			userToCreate.EmailConfirmed = false;
			userToCreate.PasswordHash = _passwordHasher.Hash(request.Password);
			userToCreate.SecurityStamp = null;
			userToCreate.ConcurrencyStamp = null;
			userToCreate.PhoneNumber = null;
			userToCreate.PhoneNumberConfirmed = false;
			userToCreate.TwoFactorEnabled = false;
			userToCreate.LockoutEnd = null;
			userToCreate.LockoutEnabled = false;
			userToCreate.AccessFailedCount = 0;

			_userRepository.Insert(userToCreate);

			var userCreated = _mapper.Map<RegisterUserDto>(userToCreate);
			var data = new ApiResponse<RegisterUserDto>("Success", 201, userCreated);

			await _unitOfWork.SaveChangesAsync();

			return data;
		}
	}
}
