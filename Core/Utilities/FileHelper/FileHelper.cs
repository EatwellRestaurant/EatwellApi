using Core.Exceptions.File;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FluentFTP;
using FluentFTP.Helpers;
using Microsoft.Extensions.Configuration;
using Core.Exceptions.General;

namespace Core.Utilities.FileHelper
{
    public sealed class FileHelper : IFileHelper
    {
        readonly FtpClient _ftpClient;
        FtpSettings _ftpSettings;

        public FileHelper(IConfiguration configuration)
        {
            _ftpSettings = configuration.GetSection("FtpSettings").Get<FtpSettings>()!;

            _ftpClient = new FtpClient(_ftpSettings.Host, _ftpSettings.Username, _ftpSettings.Password, 21);

            _ftpClient.Connect();
        }


        public IDataResult<string> Upload(IFormFile file)
        {
            CheckIfFileEnter(file);

            CheckIfFileExtensionIsImage(Path.GetExtension(file.FileName));

            string tempFilePath = Path.Combine(Path.GetTempPath(), file.FileName);

            using (var stream = new FileStream(tempFilePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string uploadUrl = $"{_ftpSettings.Path}/{fileName}";

            var success = _ftpClient.UploadFile(tempFilePath, uploadUrl);

            File.Delete(tempFilePath);

            if (success != FtpStatus.Success)
                throw new FileUploadException();


            return new SuccessDataResult<string>(data: uploadUrl);
        }


        public IResult Delete(string filePath)
        {
            if (!_ftpClient.FileExists(filePath))
                throw new EntityNotFoundException("Görsel");
            

            _ftpClient.DeleteFile(filePath);

            return new SuccessResult("Dosya silindi.");
        }


        public IDataResult<string> Update(IFormFile file, string oldPath)
        {
            Delete(oldPath);
            
            return new SuccessDataResult<string>(Upload(file).Data, "Dosya güncellendi.");
        }





        #region BusinessRules

        private void CheckIfFileEnter(IFormFile file)
        {
            if (file.Length < 0)
                throw new FileNotProvidedException();
        }


        private void CheckIfFileExtensionIsImage(string extension)
        {
            if (extension != ".jpg" && extension != ".png" && extension != ".jpeg" && extension != ".webp")
                throw new FileNotProvidedException();
        }


        #endregion
    }
}
