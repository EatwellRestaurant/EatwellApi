using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Year
{
    public class YearListDto : IDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

    }
}
