using Core.Entities.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Evaluation : IEntity
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Message { get; set; }
        public int Point { get; set; }
    }
}
