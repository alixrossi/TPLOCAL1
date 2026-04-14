using System.ComponentModel.DataAnnotations;

namespace TPLOCAL1.Models
{
    public class FormModel
    {
        // Infos personnelles
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string Sexe { get; set; }
        [Required]
        public string Adresse { get; set; }
        [Required]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Le code postal doit contenir exactement 5 chiffres.")]
        public string CodePostal { get; set; }
        [Required]
        public string Ville { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "L'adresse mail n'est pas valide.")]
        public string AdresseMail { get; set; }

        // Info formation
        [Required]
        [DataType(DataType.Date)]
        public DateTime? DateDebut { get; set; }
        [Required]
        public string Formation { get; set; }

        // Avis formation
        public string? AvisCobol { get; set; }
        public string? AvisCSharp { get; set; }
    }
}
