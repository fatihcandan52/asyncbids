using System.ComponentModel.DataAnnotations;

namespace SigortamNet.MVC.ViewModels
{
    public class MyBidsViewModel
    {
        [Display(Name = "T.C. Kimlik Numarası", Prompt = "Lütfen T.C. kimlik numaranızı giriniz")]
        public string IdentificationNumber { get; set; }
    }
}
