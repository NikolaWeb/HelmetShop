using FluentValidation;
using HelmetShop.Application.Emails;
using HelmetShop.Application.UseCases.Commands;
using HelmetShop.Application.UseCases.DTO;
using HelmetShop.DataAccess;
using HelmetShop.Domain;
using HelmetShop.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelmetShop.Implementation.UseCases.Commands
{
    public class RegisterUserCommand : UseCase, IRegisterUserCommand
    {
        private RegisterValidator _validator;
        private IEmailSender _sender;
        public RegisterUserCommand(HsContext context, RegisterValidator validator, IEmailSender sender) : base(context)
        {
            _validator = validator;
            _sender = sender;
        }

        public int Id => 4;

        public string Name => "User Registration";

        public string Description => "";

        public void Execute(RegisterDto request)
        {
            _validator.ValidateAndThrow(request);

            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password
            };

            Context.Users.Add(user);

            Context.SaveChanges();

            _sender.SendEmail(new MailMessage
            {
                From = "noreply@helmetshop.rs",
                To = request.Email,
                Subject = "Please confirm registration",
                Body = "Dear " + request.FirstName + " please confirm that you registered on our website helmetshop.rs...",
            });
        }
    }
}
