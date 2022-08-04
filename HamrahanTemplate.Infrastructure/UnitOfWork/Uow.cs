using Contexts;
using HamrahanTemplate.Infrastructure.Contract;
using HamrahanTemplate.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamrahanTemplate.Infrastructure.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly HamrahanDbContext _db;
        private IPostRepository _post;
        private IGradeRepository _grade;
        private IPersonRepository _person;
        private ICourseRepository _course;
   
        public Uow(HamrahanDbContext db)
        {
            _db = db;
          
        }


        public IPostRepository Post { get
            {
                if (_post == null)
                    _post = new PostRepository(_db);
                return _post;
            }
        }
        public IGradeRepository Grade
        {
            get
            {
                if (_grade == null)
                    _grade = new GradeRepository(_db);
                return _grade;
            }
        }
        public IPersonRepository Person
        {
            get
            {
                if (_person == null)
                    _person = new PersonRepository(_db);
                return _person;
            }
        }  public ICourseRepository Course
        {
            get
            {
                if (_course == null)
                    _course = new CourseRepository(_db);
                return _course;
            }
        }
        public void Dispose()
        {
            try { _db.Dispose();  }
            catch (Exception) { }
          
        }

        public void save()
        {
            try { _db.SaveChanges(); }
            catch (Exception){}
            
        }
    }
}
