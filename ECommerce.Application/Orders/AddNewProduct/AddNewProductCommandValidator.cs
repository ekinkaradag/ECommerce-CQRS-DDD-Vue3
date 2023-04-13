using ECommerce.Application.Orders.GetProducts;
using FluentValidation;

namespace ECommerce.Application.Orders.AddNewProduct
{
    public class AddNewProductCommandValidator : AbstractValidator<AddNewProductCommand>
    {
        public AddNewProductCommandValidator()
        {
			RuleFor(x => x.Name)
                .NotEmpty()
				.WithMessage("The product needs to have a name");

			RuleFor(x => x.ImageUrl)
                .NotEmpty()
                .Must(name => name.StartsWith("/"))
				.WithMessage("The product needs to have a valid url for its image: It should start with '/'");

			RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("The product needs to have a price that is greater than 0");
        }
    }
}