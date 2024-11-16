using FluentValidation;

namespace SampleApplication.Models.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("Email kısmı boş geçilemez...");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email adresini doğru giriniz..");

            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Name kısmı boş geçilemez...");
            RuleFor(x => x.Name).MinimumLength(5).MaximumLength(40).WithMessage("Min: 5 Max: 40 karakter olması gerekmektedir...");


        }
    }
}
