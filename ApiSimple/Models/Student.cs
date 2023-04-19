using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiSimple.Models
{
    public class Student
    {
        [Key] // anotaci není nutné psát, pokud název obsahuje Id
        public int Id { get; set; }

        [Required]
        public string Firstname { get; set; } = string.Empty;

        [Required]
        public string Lastname { get; set; } = string.Empty;

        [Required]
        public DateTime BirthDate { get; set; }

        [JsonIgnore]
        public Classroom Classroom { get; set; } = default!; // navigation property
        
        [Required] // vazba 1:N
        public int? ClassroomId { get; set; } // nemusím psát anotaci cizího klíče
    }
}