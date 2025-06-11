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
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.User.Commands.ResendVerifyAccount
{
	public class ResendVerifyAccountCommandHandler : IRequestHandler<ResendVerifyAccountCommand, ApiResponse<ResendVerifyAccountDto>>
	{
		private readonly IMapper _mapper;
		private readonly IUserRepository _userRepository;
		private readonly IUnitOfWork<Domain.Entities.User, Guid> _unitOfWork;
		private readonly IPasswordHasher _passwordHasher;
		private readonly IEmailService _emailService;

		public ResendVerifyAccountCommandHandler(IMapper mapper, 
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

		public async Task<ApiResponse<ResendVerifyAccountDto>> Handle(ResendVerifyAccountCommand request, CancellationToken cancellationToken)
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
			var callbackUrl = $"http://localhost:4200/verification?token={token}&email={request.Email}";

			await _emailService.SendEmailVerification(request.Email, "Verification Account", callbackUrl);

			_userRepository.Update(user);
			await _unitOfWork.SaveChangesAsync();

			var resendVerifyAccount = _mapper.Map<ResendVerifyAccountDto>(user);
			var data = new ApiResponse<ResendVerifyAccountDto>("Success", 200, resendVerifyAccount);

			return data;

		}
	}
}
