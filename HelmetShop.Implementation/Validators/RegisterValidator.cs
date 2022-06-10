using FluentValidation;
using HelmetShop.Application.UseCases.DTO;
using HelmetShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelmetShop.Implementation.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator(HsContext context)
        {
            RuleFor(x => x.Username).Cascade(CascadeMode.Stop)
                                    .NotEmpty().WithMessage("Username is required")                                    
                                    .MinimumLength(3).WithMessage("Username has to be at least 3 characters long")
                                    .MaximumLength(20).WithMessage("Username has to be 20 characters long at most")
                                    .Matches(@"^(?=[a-zA-Z0-9._]{3,20}$)(?!.*[_.]{2})[^_.].*[^_.]$")
                                        .WithMessage("Username is not in the correct format. Hint: user letters, numbers, . and _")
                                    .Must(x => !context.Users.Any(u => u.Username == x)).WithMessage("Username {PropertyValue} already exists");

            RuleFor(x => x.Email).Cascade(CascadeMode.Stop)
                                 .NotEmpty().WithMessage("Email is required").EmailAddress()
                                 .WithMessage("{PropertyValue} is not a valid email address")
                                 .Must(x => !context.Users.Any(e => e.Email == x)).WithMessage("Email {PropertyValue} is already registered");

            RuleFor(x => x.FirstName).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("First name is required")
                                     .MaximumLength(50).WithMessage("First name has to be 50 characters long at most")
                                     .Matches(@"^[A-Z][a-z]{2,}(\s[A-Z][a-z]{2,})?$").WithMessage("First name is not in the correct format");

            RuleFor(x => x.LastName).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Last name is required")
                                    .MaximumLength(50).WithMessage("Last name has to be 50 characters long at most")
                                    .Matches(@"^[A-Z][a-z]{2,}(\s[A-Z][a-z]{2,})?$").WithMessage("Last name is not in the correct format"); ;

            RuleFor(x => x.Password).Cascade(CascadeMode.Stop)
                                    .NotEmpty().WithMessage("Password is required")
                                    .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")
                                        .WithMessage("Password must contain at least 8 characters, 1 uppercase, 1 lowercase and 1 special character");

        }
    }
}
