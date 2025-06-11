using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.User.Commands.ResetPassword
{
	public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, ApiResponse<ResetPasswordDto>>
	{
		private readonly IMapper _mapper;
		private readonly IUserRepository _userRepository;
		private readonly IUnitOfWork<Domain.Entities.User, Guid> _unitOfWork;
		private readonly IPasswordHasher _passwordHasher;

		public ResetPasswordCommandHandler(IMapper mapper,
			IUserRepository userRepository,
			IUnitOfWork<Domain.Entities.User, Guid> unitOfWork,
			IPasswordHasher passwordHasher)
		{
			_mapper = mapper;
			_userRepository = userRepository;
			_unitOfWork = unitOfWork;
			_passwordHasher = passwordHasher;
		}

		public async Task<ApiResponse<ResetPasswordDto>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
		{
			var validator = new ResetPasswordCommandValidator();
			var validatorResult = await validator.ValidateAsync(request);

			if(validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Password", validatorResult);
			}

			var user = await _userRepository.GetByEmailAsync(request.Email);
			if (user == null)
			{
				throw new NotFoundException(nameof(user), request.Email);
			}

			user.PasswordHash = _passwordHasher.Hash(request.Password);
			_userRepository.Update(user);
			await _unitOfWork.SaveChangesAsync();

			var resetPasswordUser = _mapper.Map<ResetPasswordDto>(user);
			var data = new ApiResponse<ResetPasswordDto>("Success", 200, resetPasswordUser);

			return data;
		}
	}
}
