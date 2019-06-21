using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCursos.Models;

namespace WebApiCursos.Context
{
    public class CoursesDbContext : DbContext
    {
        public CoursesDbContext(DbContextOptions options) : base(options) { } 

        public DbSet<Course> Courses { get; set; }
    }
}
