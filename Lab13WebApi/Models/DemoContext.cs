using Microsoft.EntityFrameworkCore;

namespace Lab13WebApi.Models
{
    public class DemoContext : DbContext
    {
        public DbSet<Course> Course { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<Grade> Grade { get; set; }
        public DbSet<Student> Student { get; set; }
        //cadena de conexion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=LAB1504-10\\SQLEXPRESS;Initial Catalog=StoreBD1; User id=user01; Pwd=123456;Trusted_Connection=True;TrustServerCertificate=True");

        }
    }
}
