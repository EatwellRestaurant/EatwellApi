using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ResponseModels
{
    public record ErrorResponse : Response
    {
        public string Message { get; init; }

        public List<int>? Data { get; set; }


        public ErrorResponse(string message, int statusCode, List<int>? data = null) 
        {
            Message = message;
            Success = false;
            StatusCode = statusCode;
            Data = data;
        }


    }
}
