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
        IDataResult<string> Upload(IFormFile file);

        IResult Delete(string filePath);

        IDataResult<string> Update(IFormFile file, string oldPath);
    }
}
