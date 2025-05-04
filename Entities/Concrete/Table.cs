using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Table : BaseEntity
    {
        public string Name { get; set; }
        public byte Capacity { get; set; }
    }
}
