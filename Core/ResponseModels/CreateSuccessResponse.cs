using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ResponseModels
{
    public record CreateSuccessResponse : SuccessResponse
    {
        public CreateSuccessResponse(string message) : base(message, StatusCodes.Status201Created)
        {
        }
    }
}
