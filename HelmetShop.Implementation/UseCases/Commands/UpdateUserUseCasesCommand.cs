using FluentValidation;
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
    public class UpdateUserUseCasesCommand : UseCase, IUpdateUserUseCasesCommand
    {
        private readonly UpdateUserUseCasesValidator _validator;
        public UpdateUserUseCasesCommand(HsContext context, UpdateUserUseCasesValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 11;

        public string Name => "Update user use cases";

        public string Description => "";

        public void Execute(UpdateUserUseCasesDto request)
        {
            _validator.ValidateAndThrow(request);

            var useCases = Context.UserUseCases.Where(x => x.UserId == request.UserId).ToList();

            Context.UserUseCases.RemoveRange(useCases);

            var newUseCases = request.UseCaseIds.Select(x => new UserUseCase
            {
                UseCaseId = x,
                UserId = request.UserId
            });

            Context.UserUseCases.AddRange(newUseCases);
            Context.SaveChanges();
        }
    }
}
