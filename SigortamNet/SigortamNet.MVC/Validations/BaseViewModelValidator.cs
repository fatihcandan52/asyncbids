using FluentValidation;
using SigortamNet.MVC.ViewModels;

namespace SigortamNet.MVC.Validations
{
    public class BaseViewModelValidator<TViewModel> : AbstractValidator<TViewModel> where TViewModel : BaseViewModel
    {

    }
}
