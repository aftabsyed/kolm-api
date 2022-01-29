using FluentValidation;

namespace Kolmeo.API.DTO
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public class Validator : AbstractValidator<ProductDto>
        {
            public Validator()
            {
                RuleFor(x => x.Name)
                    .NotEmpty();

                RuleFor(x => x.Description)
                    .NotEmpty();

                RuleFor(x => x.Price)
                    .NotEmpty();
            }
        }
    }
}
