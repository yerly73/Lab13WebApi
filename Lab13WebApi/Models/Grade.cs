namespace Lab13WebApi.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public string Name { get; set; }
        public float Description { get; set; }
        public Nullable<bool> Activo { get; set; } = true;
    }
}
