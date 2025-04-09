using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ResponseModels
{
    /// <summary>
    /// Write işlemleri için. (Ekleme, güncelleme, silme)
    /// </summary>
    public record SuccessResponse : Response
    {
        public string Message { get; init; }

        public SuccessResponse(string message, int statusCode)
        {
            Message = message;
            Success = true;
            StatusCode = statusCode;
        }
    }
}
