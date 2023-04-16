using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class EvaluationDetailDto : IDto
    {
        public int EvaluationId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string Message { get; set; }
    }
}
