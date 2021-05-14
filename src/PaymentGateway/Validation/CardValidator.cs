using FluentValidation;
using PaymentGateway.Models;

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
        }
    }
}
