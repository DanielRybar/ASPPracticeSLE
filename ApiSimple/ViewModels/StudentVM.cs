namespace ApiSimple.ViewModels
{
    public class StudentVM
    {
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public int? ClassroomId { get; set; }
    }
}