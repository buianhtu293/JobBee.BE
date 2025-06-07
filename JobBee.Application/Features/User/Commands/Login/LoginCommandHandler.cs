using JobBee.Domain.Entities;
using JobBee.Application.Abstractions;
using JobBee.Application.Abstractions.Messaging;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Shared.Shared;

namespace JobBee.Application.Features.User.Commands.Login
{
    internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;

        public LoginCommandHandler(IUserRepository userRepository,
            IJwtProvider jwtProvider)
        {
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
        }
        public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            //Get user
            var user = await _userRepository.GetByEmailAsync(request.email, cancellationToken);

            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.email);
            }

            user = await _userRepository.Login(request.email, request.password);

            if (user == null)
            {
                throw new NotFoundException("Wrong Password", request.email);
            }

            //Generate JWT
            string token = _jwtProvider.Generate(user);

            //Return JWT
            return token;
        }
    }
}
