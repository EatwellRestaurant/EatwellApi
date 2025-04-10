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

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string uploadUrl = $"ftp://{_ftpSettings.Host}/{_ftpSettings.Path}/{fileName}";


            using (var stream = file.OpenReadStream())
            {
                if (!_ftpClient.DirectoryExists(_ftpSettings.Path))
                {
                    _ftpClient.CreateDirectory(_ftpSettings.Path);
                }

                var success = _ftpClient.UploadFile(fileName, uploadUrl);

                if (!success.IsSuccess())
                    throw new FileUploadException();
            }


            return new SuccessDataResult<string>(uploadUrl, "Dosya başarıyla yüklendi");
        }


        public IResult Delete(string filePath)
        {
            var result = CheckIfFileExists(filePath);

            if (!result.Success)
            {
                return result;
            }

            File.Delete(filePath);
            return new SuccessResult("Dosya silindi");
        }


        public IDataResult<string> Update(IFormFile file, string oldPath, string root)
        {
            var resultOfDelete = Delete(oldPath);

            if (!resultOfDelete.Success)
            {
                return new ErrorDataResult<string>(resultOfDelete.Message);
            }

            var resultOfUpload = Upload(file);

            if (!resultOfUpload.Success)
            {
                return resultOfUpload;
            }

            return new SuccessDataResult<string>(resultOfUpload.Data, "Dosya güncellendi");
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



        private static IResult CheckIfFileExists(string filePath)
        {
            if (File.Exists(filePath))
            {
                return new SuccessResult();
            }
            return new ErrorResult("Böyle bir dosya mevcut değil");
        }

        #endregion
    }
}
