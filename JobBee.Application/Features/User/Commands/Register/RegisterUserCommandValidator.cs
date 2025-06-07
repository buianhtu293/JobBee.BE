using FluentValidation;
using JobBee.Application.Contracts.Persistence;

namespace JobBee.Application.Features.User.Commands.Register
{
	public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
	{
		private readonly IUserRepository _userRepository;

		public RegisterUserCommandValidator(IUserRepository userRepository)
		{
			RuleFor(p => p.UserName)
				.NotEmpty().WithMessage("{PropertyName} is required")
				.NotNull()
				.MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

			RuleFor(p => p)
				.MustAsync(IsMatchPassword)
				.WithMessage("Password and Password Confirm doesn't match");

			RuleFor(p => p)
				.MustAsync(IsEmailUnique)
				.WithMessage("Email already existed");

			_userRepository = userRepository;
		}

		private async Task<bool> IsEmailUnique(RegisterUserCommand command, CancellationToken cancellationToken)
		{
			return await _userRepository.IsEmailUniqueAsync(command.Email);
		}

		private async Task<bool> IsMatchPassword(RegisterUserCommand command, CancellationToken cancellationToken)
		{
			await Task.Yield();

			return !string.IsNullOrWhiteSpace(command.Password)
				&& !string.IsNullOrWhiteSpace(command.PasswordConfirm)
				&& command.Password == command.PasswordConfirm;
		}
	}
}
