using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Year : BaseEntity
    {
        public string Name { get; set; }



        public ICollection<Permission> Permissions { get; set; }
    }
}
