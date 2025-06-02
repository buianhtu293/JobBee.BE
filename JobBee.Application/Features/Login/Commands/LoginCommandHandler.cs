using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Api.Models;
using JobBee.Application.Abstractions;
using JobBee.Application.Abstractions.Messaging;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Shared.Shared;

namespace JobBee.Application.Features.Login.Commands
{
	internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, string>
	{
		private readonly IUserRepository _userRepository;
		private readonly IJwtProvider _jwtProvider;

		public LoginCommandHandler(IUserRepository userRepository,
			IJwtProvider jwtProvider)
        {
			this._userRepository = userRepository;
			this._jwtProvider = jwtProvider;
		}
        public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
		{
			//Get user
			var user = await _userRepository.GetByEmailAsync(request.email, cancellationToken);

			if (user == null)
			{
				throw new NotFoundException(nameof(User), request.email);
			}

			//Generate JWT
			string token = _jwtProvider.Generate(user);

			//Return JWT
			return token;
		}
	}
}
