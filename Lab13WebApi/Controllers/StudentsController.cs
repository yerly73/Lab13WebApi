using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab13WebApi.Models;

namespace Lab13WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly DemoContext _context;

        public StudentsController(DemoContext context)
        {
            _context = context;
        }

        // Endpoint 1: Buscar estudiantes por nombre, apellido y email ordenados por apellido
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Student>>> SearchStudents(string? firstName, string? lastName, string? email)
        {
            var query = _context.Student
                .Include(s => s.Grade)
                .Where(s =>
                    (string.IsNullOrEmpty(firstName) || s.FirstName.Contains(firstName)) &&
                    (string.IsNullOrEmpty(lastName) || s.LastName.Contains(lastName)) &&
                    (string.IsNullOrEmpty(email) || s.Email.Contains(email)))
                .OrderByDescending(s => s.LastName);

            var students = await query.ToListAsync();

            if (students == null || students.Count == 0)
            {
                return NotFound();
            }

            return students;
        }

        // Endpoint 2: Buscar estudiantes por nombre y grado ordenados por nombre del curso
        [HttpGet("searchByGrade")]
        public async Task<ActionResult<IEnumerable<Student>>> SearchStudentsByGrade(string? firstName, int? gradeId)
        {
            var query = _context.Student
                .Include(s => s.Grade)
                .Where(s =>
                    (string.IsNullOrEmpty(firstName) || s.FirstName.Contains(firstName)) &&
                    (!gradeId.HasValue || s.GradeId == gradeId))
                .OrderByDescending(s => s.Grade.Name);

            var students = await query.ToListAsync();

            if (students == null || students.Count == 0)
            {
                return NotFound();
            }

            return students;
        }

        // Endpoint 3: Lista de estudiantes matriculados por nombre del curso ordenados por curso y apellido
        [HttpGet("enrolledByCourse")]
        public async Task<ActionResult<IEnumerable<Student>>> GetEnrolledStudentsByCourse(string courseName)
        {
            var query = _context.Student
                .Include(s => s.Grade)

                .OrderBy(s => s.Grade.Name)
                .ThenBy(s => s.LastName);

            var students = await query.ToListAsync();

            if (students == null || students.Count == 0)
            {
                return NotFound();
            }

            return students;
        }

        // Endpoint 4: Lista de estudiantes matriculados por grado ordenados por curso y apellido
        [HttpGet("enrolledByGrade")]
        public async Task<ActionResult<IEnumerable<Student>>> GetEnrolledStudentsByGrade(int gradeId)
        {
            var query = _context.Student
                .Include(s => s.Grade)
                .Where(s => s.GradeId == gradeId)
                .OrderBy(s => s.Grade.Name)
                .ThenBy(s => s.LastName);

            var students = await query.ToListAsync();

            if (students == null || students.Count == 0)
            {
                return NotFound();
            }

            return students;
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.StudentId == id);
        }
    }
}
