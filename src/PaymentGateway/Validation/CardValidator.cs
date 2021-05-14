using FluentValidation;
using PaymentGateway.Models;
using System;
using System.Linq;

namespace PaymentGateway.Validation
{
    public class CardValidator : AbstractValidator<Card>
    {
        public CardValidator()
        {
            RuleFor(x => x.CardNumber)
                .NotNull()
                .CreditCard();

            RuleFor(x => x.NameOnCard)
                .NotNull()
                .Length(5, 60)
                .Matches(@"^[a-zA-Z ]+$")
                .WithMessage("Must be the name with no special characters");

            RuleFor(x => x.CardIssuer)
                .NotNull()
                .Must(issuer => _validCardIssuers.Contains(issuer.ToLower()))
                .WithMessage("We only accept payment by these card issuers: " + String.Join(", ", _validCardIssuers));

            RuleFor(x => x.CVV)
                .GreaterThan(99)
                .LessThan(1000);
        }

        public string[] _validCardIssuers = new[]
        {
            "visa",
            "mastercard",
            "maestro",
            "solo",
            "american express"
        };
    }
}
