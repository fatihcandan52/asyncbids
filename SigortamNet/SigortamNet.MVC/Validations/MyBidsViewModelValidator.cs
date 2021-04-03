using FluentValidation;
using SigortamNet.MVC.ViewModels;

namespace SigortamNet.MVC.Validations
{
    public class MyBidsViewModelValidator : AbstractValidator<MyBidsViewModel>
    {
        public MyBidsViewModelValidator()
        {
            RuleFor(x => x.IdentificationNumber)
                .NotEmpty().WithMessage("Lütfen T.C. kimlik numaranızı  giriniz.");
        }
    }
}
