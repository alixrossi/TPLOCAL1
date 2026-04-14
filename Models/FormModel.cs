using System.ComponentModel.DataAnnotations;

namespace TPLOCAL1.Models
{
    public class FormModel
    {
        // Infos personnelles
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Le code postal doit contenir exactement 5 chiffres.")]
        public string PostCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "L'adresse mail n'est pas valide.")]
        public string Email { get; set; }

        // Info formation
        [Required]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [Required]
        public string Formation { get; set; }

        // Avis formation
        public string? OpinionCobol { get; set; }
        public string? OpinionCSharp { get; set; }
    }
}
