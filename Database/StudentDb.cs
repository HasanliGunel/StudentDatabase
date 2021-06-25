using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleStudentDatabase.Database;

namespace ExampleStudentDatabase.Database
{
    public class StudentDb:DbContext
    {
        public StudentDb(DbContextOptions<StudentDb> context) : base(context) { }
        public DbSet<Student> Students { get; set; }
    }
}
