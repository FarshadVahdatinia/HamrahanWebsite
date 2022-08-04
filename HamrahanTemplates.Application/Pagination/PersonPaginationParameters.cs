using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamrahanTemplate.Application.Pagination
{
    public class PersonPaginationParameters
    {
        const int maxPageSize = 10;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 2;


        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value > maxPageSize || value < 1 ? maxPageSize : value; }
        }




    }
}
