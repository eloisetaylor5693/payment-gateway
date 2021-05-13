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

            RuleFor(x => x.MerchantId)
                .NotNull()
                .Length(15)
                .Matches(@"^[0-9]+$")
                .WithMessage("Must be a 15 digit number");

            RuleFor(x => x.TerminalId)
                .NotNull()
                .Length(8)
                .Matches(@"^[0-9]+$")
                .WithMessage("Must be an 8 digit number");

            RuleFor(x => x.PaymentReference)
                .NotNull()
                .Length(1,25)
                .Matches(@"^[a-zA-Z0-9#-]+$")
                .WithMessage("Must be a string with less than 25 characters long, containing letters, numbers, or the characters # or -");
        }
    }
}
