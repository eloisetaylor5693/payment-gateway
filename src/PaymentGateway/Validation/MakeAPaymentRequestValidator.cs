using FluentValidation;
using PaymentGateway.Requests;

namespace PaymentGateway.Validation
{
    public class MakeAPaymentRequestValidator : AbstractValidator<MakeAPaymentRequest>
    {
        public MakeAPaymentRequestValidator()
        {
            RuleFor(x => x.IsoCurrencyCode)
                .NotNull()
                .Length(3)
                .Matches(@"^[a-zA-Z]+$")
                .WithMessage("Must be a valid 3 letter ISO Country Code");

            RuleFor(x => x.PaymentAmount)
                .NotNull()
                .GreaterThan(0)
                .LessThan(5000);
        }
    }
}
