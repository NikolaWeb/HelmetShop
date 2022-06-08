using HelmetShop.Application.UseCases.Commands;
using HelmetShop.Application.UseCases.DTO;
using HelmetShop.DataAccess;
using HelmetShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelmetShop.Implementation.UseCases.Commands
{
    public class CreateCategoryCommand : UseCase, ICreateCategoryCommand
    {
        public CreateCategoryCommand(HsContext context) : base(context)
        {
        }

        public int Id => 3;

        public string Name => "Create Category";

        public string Description => "Create category using EF";

        public void Execute(CategoryDto request)
        {
            var category = new Category
            {
                Name = request.Name
            };

            Context.Categories.Add(category);

            Context.SaveChanges();
        }
    }
}
