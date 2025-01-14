using FluentValidation;
using Transactions.Info.Core.DTOs;

namespace Transactions.Info.Extra.API.Helpers.Validators
{
    public class CustomerAccountValidator : AbstractValidator<CustomerAccountDTO>
    {
        public CustomerAccountValidator()
        {
            RuleFor(account => account.AccountNumber)
              .NotEmpty().WithMessage("Account Number is required.")
              .Matches("[0-9]{10}").WithMessage("'{PropertyName}' must only contain ten digits.");

            
        }
    }
}
