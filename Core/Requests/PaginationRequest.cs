using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Requests
{
    public class PaginationRequest
    {
        int _pageNumber = 1;

        public int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = value < 1 ? 1 : value;
        }


        int _pageSize = 10;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value <= 30 ? value : 10;
        }

    }
}
