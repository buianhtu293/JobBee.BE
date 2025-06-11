using System.Security.Cryptography;
using AutoMapper;
using FluentEmail.Core;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.EmailService;
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
		private readonly IRoleRepository _roleRepository;
		private readonly IEmailService _emailService;

		public RegisterUserCommandHandler(IMapper mapper, 
			IUserRepository userRepository,
			IUnitOfWork<Domain.Entities.User, Guid> unitOfWork,
			IPasswordHasher passwordHasher,
			IRoleRepository roleRepository,
			IEmailService emailService)
		{
			_mapper = mapper;
			_userRepository = userRepository;
			_unitOfWork = unitOfWork;
			_passwordHasher = passwordHasher;
			_roleRepository = roleRepository;
			_emailService = emailService;
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

			// Assign role
			var roleName = request.IsCandidate!.Value ? "candidate" : "employer";
			var role = await _roleRepository.GetByName(roleName);

			if (role == null)
				throw new NotFoundException($"Role '{roleName}' not found.", role);

			userToCreate.Roles = new List<Domain.Entities.Role> { role };

			//Email verification
			byte[] tokenBytes = RandomNumberGenerator.GetBytes(64);
			string token = Convert.ToBase64String(tokenBytes);
			userToCreate.SecurityStamp = _passwordHasher.Hash(token);
			var callbackUrl = $"http://localhost:4200/verification?token={token}&email={userToCreate.Email}";

		 	await _emailService.SendEmailVerification(userToCreate.Email, "Verification Account", callbackUrl);

			// Save user (with roles)
			_userRepository.InsertUserAsync(userToCreate);
			await _unitOfWork.SaveChangesAsync();

			var userCreated = _mapper.Map<RegisterUserDto>(userToCreate);
			var data = new ApiResponse<RegisterUserDto>("Success", 201, userCreated);

			return data;

		}
	}
}
