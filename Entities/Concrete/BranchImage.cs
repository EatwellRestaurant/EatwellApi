using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BranchImage : IEntity
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public string? ImagePath { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }




        public Branch Branch { get; set; }

    }
}
