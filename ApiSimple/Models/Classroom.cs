using System.Text.Json.Serialization;

namespace ApiSimple.Models
{
    public class Classroom
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        
        [JsonIgnore]
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}