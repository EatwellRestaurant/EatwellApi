using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Table
{
    public class TableUpsertDto
    {
        public string Name { get; set; }
        public byte Capacity { get; set; }
    }
}
