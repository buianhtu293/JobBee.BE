using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.EmailService;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.User.Commands.VerifyAccount
{
	public class VerifyUserCommandHandler : IRequestHandler<VerifyUserCommand, ApiResponse<VerifyUserDto>>
	{
		private readonly IMapper _mapper;
		private readonly IUserRepository _userRepository;
		private readonly IUnitOfWork<Domain.Entities.User, Guid> _unitOfWork;
		private readonly IPasswordHasher _passwordHasher;

		public VerifyUserCommandHandler(IMapper mapper,
			IUserRepository userRepository,
			IUnitOfWork<Domain.Entities.User, Guid> unitOfWork,
			IPasswordHasher passwordHasher)
		{
			_mapper = mapper;
			_userRepository = userRepository;
			_unitOfWork = unitOfWork;
			_passwordHasher = passwordHasher;
		}
		public async Task<ApiResponse<VerifyUserDto>> Handle(VerifyUserCommand request, CancellationToken cancellationToken)
		{
			var user = await _userRepository.GetByEmailAsync(request.Email);
			if (user == null)
			{
				throw new NotFoundException(nameof(user), request.Email);
			}

			var isVerify = _passwordHasher.Verify(request.Token, user.SecurityStamp);

			if (!isVerify)
			{
				throw new NotFoundException(nameof(user), request.Email);
			}

			user.EmailConfirmed = true;
			_userRepository.Update(user);
			await _unitOfWork.SaveChangesAsync();
			var verifyUserDto = _mapper.Map<VerifyUserDto>(user);
			var data = new ApiResponse<VerifyUserDto>("Success", 201, verifyUserDto);
			return data;

		}
	}
}
