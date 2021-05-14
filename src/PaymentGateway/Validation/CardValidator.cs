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
        }
    }
}
