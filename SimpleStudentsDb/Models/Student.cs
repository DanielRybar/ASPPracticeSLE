using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleStudentsDb.Models
{
    public class Student
    {
        [Key] // anotaci není nutné psát, pokud název obsahuje Id
        public int Id { get; set; }

        [Required]
        [Display(Name = "Jméno")] // co se má zobrazovat v UI
        public string Firstname { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Příjmení")]
        public string Lastname { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Datum narození")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        public Classroom Classroom { get; set; } = default!; // navigation property
        [Required]
        public int ClassroomId { get; set; } // nemusím psát anotaci cizího klíče

        [NotMapped] // anotace, která říká, že se jedná o vlastnost, která se neukládá do databáze
        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
    }
}