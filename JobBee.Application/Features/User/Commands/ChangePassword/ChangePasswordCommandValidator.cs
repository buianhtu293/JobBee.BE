using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JobBee.Application.Features.User.Commands.ResetPassword;

namespace JobBee.Application.Features.User.Commands.ChangePassword
{
	public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
	{
        public ChangePasswordCommandValidator()
        {
			RuleFor(p => p)
				.MustAsync(IsMatchPassword)
				.WithMessage("Password and Confirm Password doesn't match");
		}

        private Task<bool> IsMatchPassword(ChangePasswordCommand changePasswordCommand, CancellationToken token)
		{
			if (changePasswordCommand == null)
				return Task.FromResult(false);

			var password = changePasswordCommand.Password?.Trim();
			var confirmPassword = changePasswordCommand.ConfirmPassword?.Trim();

			bool isMatch = string.Equals(password, confirmPassword, StringComparison.Ordinal);
			return Task.FromResult(isMatch);
		}
	}
}
