using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace JobBee.Application.Features.User.Commands.ResetPassword
{
	public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
	{
        public ResetPasswordCommandValidator()
        {
			RuleFor(p => p)
				.MustAsync(IsMatchPassword)
				.WithMessage("Password and Confirm Password doesn't match");
        }

        private Task<bool> IsMatchPassword(ResetPasswordCommand resetPasswordCommand, CancellationToken token)
        {
			if (resetPasswordCommand == null)
				return Task.FromResult(false);

			var password = resetPasswordCommand.Password?.Trim();
			var confirmPassword = resetPasswordCommand.ConfirmPassword?.Trim();

			bool isMatch = string.Equals(password, confirmPassword, StringComparison.Ordinal);
			return Task.FromResult(isMatch);
		}

    }
}
