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
                .WithMessage("We only accept payment by these card issuers: " + string.Join(", ", _validCardIssuers));

            RuleFor(x => x.CVV)
                .GreaterThan(99)
                .LessThan(1000);

            RuleFor(x => x.ExpiryDate)
                .NotNull()
                .Length(5)
                .Matches(@"^\d{2}[/]\d{2}$")
                    .WithMessage("Must be in the format MM/YY")
                .Must(BeAValidDate)
                    .WithMessage("Must be a valid date in the format MM/YY, and must be in the future");
        }

        public bool BeAValidDate(string expiryDate)
        {
            var monthString = expiryDate.Substring(0, 2);
            var yearString = expiryDate.Substring(3, 2);

            int.TryParse(monthString, out var month);
            int.TryParse(yearString, out var year);

            year += 2000;

            var date = new DateTime(year, month, 1);
            return date > DateTime.Now;
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
