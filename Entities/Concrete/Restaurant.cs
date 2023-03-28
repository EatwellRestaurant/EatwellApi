using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Restaurant : IEntity
    {
        public int Id { get; set; }
        public int? BranchId { get; set; }
        public string? WebSite { get; set; }

    }
}
