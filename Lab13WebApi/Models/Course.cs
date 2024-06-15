namespace Lab13WebApi.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name{ get; set; }
        public int Credit { get; set; }
        public Nullable<bool> Activo { get; set; } = true;


    }
}
