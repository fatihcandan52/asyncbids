using System.ComponentModel.DataAnnotations;

namespace SigortamNet.MVC.ViewModels
{
    public class VisitorViewModel
    {
        [Display(Name = "Plaka")]
        public string LicensePlate { get; set; }
        [Display(Name = "T.C. Kimlik Numarası")]
        public string IdentificationNumber { get; set; }
        [Display(Name = "Ruhsat Seri Kodu")]
        public string LicenseSerialCode { get; set; }
        [Display(Name = "Ruhsat Seri No")]
        public string LicenseSerialNo { get; set; }
    }
}
