using ECommerce.Application.Orders.GetProducts;
using FluentValidation;

namespace ECommerce.Application.Orders.PlaceCustomerOrder
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            this.RuleFor(x => x.Quantity).GreaterThan(0)
                .WithMessage("At least one product has invalid quantity");
        }
    }
}