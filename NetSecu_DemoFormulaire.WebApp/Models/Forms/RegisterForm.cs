using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NetSecu_DemoFormulaire.WebApp.Models.Forms
{
#nullable disable
    public class RegisterForm
    {
        [DisplayName("Nom :")]
        [Required]
        [MinLength(1)]
        public string Nom {  get; set; }
        [DisplayName("Prenom :")]
        [Required]
        [MinLength(4, ErrorMessage = "Votre prénom est trop court")]
        public string Prenom { get; set; }
        [DisplayName("Email :")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [DisplayName("Mot de passe :")]
        [Required]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-=]).{8,20}$",ErrorMessage = "Votre mot de passe doit avoir au min 1 lettre en minus, 1 lettre majuscule, 1 caractère spécial et une taile de min 8 caractères")]
        [DataType(DataType.Password)]
        public string Passwd { get; set; }
        [DisplayName("Confirmation :")]
        [Compare(nameof(Passwd))]
        [DataType(DataType.Password)]
        public string Confirmation { get; set; }
    }
}
