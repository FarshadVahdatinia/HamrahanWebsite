using Contexts;
using Hamrahan.Models;
using HamrahanTemplate.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamrahanTemplate.Infrastructure.Repository
{
   public class GradeRepository: Repository<EducationGrade>,IGradeRepository
    {
        private readonly HamrahanDbContext _db;

        public GradeRepository(HamrahanDbContext db):base(db)
        {
            _db = db;
        }
    }
}
