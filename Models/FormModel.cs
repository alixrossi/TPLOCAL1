using System;
using System.ComponentModel.DataAnnotations;

namespace TPLOCAL1.Models
{
    public class FormModel
    {
        // Infos personnelles
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Sexe { get; set; }
        public string Adresse { get; set; }
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Le code postal doit contenir exactement 5 chiffres.")]
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        [RegularExpression(@"^([\w]+)@([\w]+)\.([\w]+)$", ErrorMessage = "L'adresse mail n'est pas valide.")]
        public string AdresseMail { get; set; }

        // Info formation
        [DataType(DataType.Date)]
        public DateTime? DateDebut { get; set; }
        public string Formation { get; set; }
        
        // Avis formation
        public string AvisCobol { get; set; }
        public string AvisCSharp { get; set; }
    }
}
