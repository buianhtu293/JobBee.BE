using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.EmailService;
using JobBee.Application.Exceptions;
using JobBee.Application.Features.User.Commands.ResendVerifyAccount;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.User.Commands.ForgetPassword
{
	public class ForgetPasswordCommandHandler : IRequestHandler<ForgetPasswordCommand, ApiResponse<ForgetPasswordDto>>
	{
		private readonly IMapper _mapper;
		private readonly IUserRepository _userRepository;
		private readonly IUnitOfWork<Domain.Entities.User, Guid> _unitOfWork;
		private readonly IPasswordHasher _passwordHasher;
		private readonly IEmailService _emailService;

		public ForgetPasswordCommandHandler(IMapper mapper,
			IUserRepository userRepository,
			IUnitOfWork<Domain.Entities.User, Guid> unitOfWork,
			IPasswordHasher passwordHasher,
			IEmailService emailService)
		{
			_mapper = mapper;
			_userRepository = userRepository;
			_unitOfWork = unitOfWork;
			_passwordHasher = passwordHasher;
			_emailService = emailService;
		}

		public async Task<ApiResponse<ForgetPasswordDto>> Handle(ForgetPasswordCommand request, CancellationToken cancellationToken)
		{
			var user = await _userRepository.GetByEmailAsync(request.Email);
			if (user == null)
			{
				throw new NotFoundException(nameof(user), request.Email);
			}

			//Email verification
			byte[] tokenBytes = RandomNumberGenerator.GetBytes(64);
			string token = Convert.ToBase64String(tokenBytes);
			user.SecurityStamp = _passwordHasher.Hash(token);
			var callbackUrl = $"https://jobbeefe.vercel.app/auth/reset-password?token={token}&email={request.Email}";

			await _emailService.SendEmailPassword(request.Email, "Reset Password", callbackUrl);

			_userRepository.UpdateSecurityStamp(user);
			await _unitOfWork.SaveChangesAsync();

			var ForgetPasswordAccount = _mapper.Map<ForgetPasswordDto>(user);
			var data = new ApiResponse<ForgetPasswordDto>("Success", 200, ForgetPasswordAccount);

			return data;
		}
	}
}
