using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ResponseModels
{
    public record DataResponse<T> : Response
    {
        public T Data { get; init; }
        public string? Message { get; init; }

        public DataResponse(T data, string? message = null)
        {
            Data = data;
            Message = message;
            Success = true;
            StatusCode = StatusCodes.Status200OK;
        }
    }
}
