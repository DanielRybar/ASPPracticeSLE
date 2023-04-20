using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace StudentsWithIdentity.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Jméno")]
        [PersonalData] // mělo by být uvedeno u osobních dat, která vyžadují zvýšenou ochranu
        [Required(ErrorMessage = "Jméno musí být vyplněno.")]
        public string Firstname { get; set; } = String.Empty;

        [Display(Name = "Příjmení")]
        [PersonalData]
        [Required(ErrorMessage = "Příjmení musí být vyplněno.")]
        public string Lastname { get; set; } = String.Empty;

        [NotMapped] // tato položka v databázi nebude, ale objekt nám ji sám spočítá
        public string Fullname
        {
            get
            {
                return Firstname + " " + Lastname;
            }
        }
    }
}