using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ResponseModels
{
    public record DeleteSuccessResponse : SuccessResponse
    {
        public DeleteSuccessResponse(string message) : base(message, StatusCodes.Status204NoContent)
        {
        }
    }
}
