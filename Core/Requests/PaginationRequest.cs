using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Requests
{
    public class PaginationRequest
    {
        int pageNumber;

        public int PageNumber
        {
            get => pageNumber;
            set => pageNumber = value < 1 ? 1 : value;
        }


        int pageSize;

        public int PageSize
        {
            get => pageSize;
            set => pageSize = value <= 30 ? value : 10;
        }

    }
}
