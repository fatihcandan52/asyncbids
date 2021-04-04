using FluentValidation;
using SigortamNet.MVC.ViewModels;

namespace SigortamNet.MVC.Validations
{
    public class VisitorViewModelValidator : BaseViewModelValidator<VisitorViewModel>
    {
        public VisitorViewModelValidator()
        {
            RuleFor(x => x.IdentificationNumber)
                .NotEmpty().WithMessage("Lütfen T.C. kimlik numaranızı giriniz")
                .Length(11).WithMessage("T.C. kimlik numarası 11 karakter olmalıdır");

            RuleFor(x => x.LicensePlate)
                .NotEmpty().WithMessage("Lütfen araç plakanızı giriniz")
                .MinimumLength(5).WithMessage("Araç plakası minimum 5 karakter olmalıdır")
                .MaximumLength(20).WithMessage("Araç plakası maksimum 20 karakter olmalıdır");

            RuleFor(x => x.LicenseSerialCode)
               .NotEmpty().WithMessage("Lütfen ruhsat seri kodunu giriniz")
               .Length(2).WithMessage("Ruhsat seri kodu 2 karakter olmalıdır");

            RuleFor(x => x.LicenseSerialNo)
               .NotEmpty().WithMessage("Lütfen ruhsat seri numarasını giriniz")
               .Length(6).WithMessage("Ruhsat seri numarası 6 karakter olmalıdır");
        }
    }
}
