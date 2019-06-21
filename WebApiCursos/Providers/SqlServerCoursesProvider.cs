using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCursos.Interfaces;
using WebApiCursos.Models;

namespace WebApiCursos.Providers
{
    public class SqlServerCoursesProvider : ICoursesProvider
    {
        public Task<(bool IsSuccess, int? Id)> AddAsync(Course course)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Course>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Course> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Course>> SearchAsync(string search)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, Course course)
        {
            throw new NotImplementedException();
        }
    }
}
