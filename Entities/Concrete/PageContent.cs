using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class PageContent : IEntity
    { 
        public int Id { get; set; }

        public byte Page { get; set; }

        public byte Section { get; set; }

        public string? Description { get; set; }

        public string? ImagePath { get; set; }

        public string? ImageName { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }


    }
}
