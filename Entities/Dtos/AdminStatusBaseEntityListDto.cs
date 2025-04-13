using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class AdminStatusBaseEntityListDto : IDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DeactivationDate { get; set; }
    }
}
