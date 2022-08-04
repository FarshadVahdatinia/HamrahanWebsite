using HamrahanTemplate.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamrahanTemplate.Infrastructure.UnitOfWork
{
    public interface IUow
    {
        public IPostRepository Post { get; }
        public IGradeRepository Grade { get; }
        public IPersonRepository Person { get; }
        public ICourseRepository Course { get; }
        
        /// <summary>
        /// متد سیو
        /// </summary>
        void save();
        void Dispose();
    }
}
