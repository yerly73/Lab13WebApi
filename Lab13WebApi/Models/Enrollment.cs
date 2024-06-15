namespace Lab13WebApi.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public DateTime? Date { get; set; }


        //clave foranea de producto
        public Student? Student { get; set; }
        public int StudentId { get; set; }

        //clave foranea de facturas
        public Course? Cource { get; set; }
        public int CourceId { get; set; }
    }
}
