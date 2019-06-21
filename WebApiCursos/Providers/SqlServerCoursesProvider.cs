using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiCursos.Context;
using WebApiCursos.Interfaces;
using WebApiCursos.Models;

namespace WebApiCursos.Providers
{
    public class SqlServerCoursesProvider : ICoursesProvider
    {
        private readonly CoursesDbContext db;

        public SqlServerCoursesProvider(CoursesDbContext db)
        {
            this.db = db;
        }
        public async Task<(bool IsSuccess, int? Id)> AddAsync(Course course)
        {
            db.Courses.Add(course);
            var newId = await db.SaveChangesAsync();
            return (true, newId);
        }

        public async Task<ICollection<Course>> GetAllAsync()
        {
            var results = await db.Courses.ToListAsync();

            return results;
        }

        public async Task<Course> GetAsync(int id)
        {
            var result = await db.Courses.FirstOrDefaultAsync(c => c.Id == id);
            return result;
        }

        public async Task<ICollection<Course>> SearchAsync(string search)
        {
            var raw = db.Courses.FromSqlRaw($"SELECT * FROM Courses WHERE Name LIKE '%{search}%'");
            var results = await raw.ToListAsync();

            return results;
        }

        public async Task<bool> UpdateAsync(int id, Course course)
        {
            db.Courses.Update(course);

            var result = await db.SaveChangesAsync();

            return result == 1;
        }
    }
}
