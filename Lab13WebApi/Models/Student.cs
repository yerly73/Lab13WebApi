namespace Lab13WebApi.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }


        public Grade? Grade { get; set; }
        public int GradeId { get; set; }
    }
}
