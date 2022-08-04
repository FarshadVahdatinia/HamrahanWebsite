using Contexts;
using Hamrahan.Models;
using HamrahanTemplate.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HamrahanTemplate.Infrastructure.Repository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        private readonly HamrahanDbContext _db;
        public PostRepository(HamrahanDbContext db):base(db)
        {
            _db = db;
        }
        public IQueryable<Post> FindById(int? id)
        {
            return _db.Posts.Where(t => t.Id == id);
        }

      

        public bool SoftDelete(Post entity)
        {
            if (entity==null)
            {
                return false;
            }
            if (entity.IsDeleted==false)
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

