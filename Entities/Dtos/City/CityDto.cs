using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.City
{
    public class CityDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
