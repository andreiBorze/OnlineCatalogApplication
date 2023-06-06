using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public interface IStudentsDbContext
    {
        DbSet<Address> Addresses { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<Grade> Grades { get; set; }
        DbSet<Student> Students { get; set; }
    }
}