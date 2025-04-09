using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.ResponseModels
{
    public record ServerErrorResponse : Response
    {
        public string TypeName { get; init; }

        public string Message { get; init; }

        public string? InnerExcpetionMessage { get; init; }


        public ServerErrorResponse(Type type, string message, string? innerExceptionMessage)
        {
            TypeName = type.Name;
            Message = message;
            InnerExcpetionMessage = innerExceptionMessage;
            StatusCode = StatusCodes.Status500InternalServerError;
            Success = false;
        }

    }
}
