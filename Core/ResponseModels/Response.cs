using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ResponseModels
{
    public abstract record Response
    {
        public bool Success { get; init; }
        public int StatusCode { get; init; }
    }
}
