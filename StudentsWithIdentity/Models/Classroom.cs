using System.ComponentModel.DataAnnotations;

namespace StudentsWithIdentity.Models
{
    public class Classroom
    {
        public int Id { get; set; }
        
        [Display(Name = "Třída")]
        public string Name { get; set; } = string.Empty;
        
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
