using FluentValidation;
using SigortamNet.MVC.ViewModels;

namespace SigortamNet.MVC.Validations
{
    public class VisitorViewModelValidator : BaseViewModelValidator<VisitorViewModel>
    {
        public VisitorViewModelValidator()
        {
            RuleFor(x => x.IdentificationNumber)
                .NotEmpty().WithMessage("Lütfen T.C. kimlik numaranızı giriniz");

            RuleFor(x => x.LicensePlate)
                .NotEmpty().WithMessage("Lütfen araçplakanızı giriniz");

            RuleFor(x => x.LicenseSerialCode)
               .NotEmpty().WithMessage("Lütfen ruhsat seri kodunu giriniz");

            RuleFor(x => x.LicenseSerialNo)
               .NotEmpty().WithMessage("Lütfen ruhsat seri numarasını giriniz");
        }
    }
}
