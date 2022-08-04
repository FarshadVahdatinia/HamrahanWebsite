using Contexts;
using Hamrahan.Models;
using Hamrahan.Models.course;
using HamrahanTemplate.Application.Pagination;
using HamrahanTemplate.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamrahanTemplate.Infrastructure.Repository
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    { 
        private readonly HamrahanDbContext _db;

        public CourseRepository(HamrahanDbContext db) : base(db)
        {
            _db = db;
        }
    
        public Pagination<Course> FindAllByPagination(CoursePaginationParameters parameters)
        {
            Pagination<Course> p = new(_db.Courses.OrderBy(n => n.UpdateDate), parameters.PageNumber, parameters.PageSize);
            return p;
        }

      
        public IQueryable<Course> FindById(long? id)
        {
            return _db.Courses.Where(t => t.Id == id);
        }

        public bool SoftDelete(Course entity)
        {
            if (entity == null)
            {
                return false;
            }
            if (entity.IsDeleted == false)
            {
                try
                {
                    entity.IsDeleted = true;
                    return true;
                }
                catch (Exception)
                {

                    return false;

                }
            }

            else
            {
                return false;
            }
        }
    }
}
