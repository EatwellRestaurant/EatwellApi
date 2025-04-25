using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.FileHelper
{
    public interface IFileHelper
    {
        Task<ImageRespone> Upload(IFormFile file);

        Task Delete(string fileName);

        Task<ImageRespone> Update(IFormFile file, string fileName);
    }
}
