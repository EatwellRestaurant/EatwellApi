using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Dtos
{
    public class LookupDto<TType> : IDto
    {
        public TType Id { get; set; }
        public string Name { get; set; }
    }

}
