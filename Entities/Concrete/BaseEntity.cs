using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public abstract class BaseEntity : IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } 
        public DateTime CreateDate { get; set; } 
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
} 
