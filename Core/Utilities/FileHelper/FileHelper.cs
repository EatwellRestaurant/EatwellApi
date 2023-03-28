using Core.Utilities.Business;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.FileHelper
{
    public class FileHelper
    {
        public static IDataResult<string> Upload(IFormFile file, string root)
        {
            var result = BusinessRules.Run(CheckIfFileEnter(file),
                CheckIfFileExtensionIsImage(Path.GetExtension(file.FileName)));

            if (!result.Success)
            {
                return new ErrorDataResult<string>(result.Message);
            }

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            var rootToUse = CheckIfDirectoryExists(root);

            var imagePath = rootToUse + fileName;

            CreateFile(imagePath, file);

            return new SuccessDataResult<string>(data: imagePath, message: "Dosya oluşturuldu");
        }


        public static IResult Delete(string filePath)
        {
            var result = CheckIfFileExists(filePath);

            if (!result.Success)
            {
                return result;
            }

            File.Delete(filePath);
            return new SuccessResult("Dosya silindi");
        }


        public static IDataResult<string> Update(IFormFile file, string oldPath, string root)
        {
            var resultOfDelete = Delete(oldPath);

            if (!resultOfDelete.Success)
            {
                return new ErrorDataResult<string>(resultOfDelete.Message);
            }

            var resultOfUpload = Upload(file, root);

            if (!resultOfUpload.Success)
            {
                return resultOfUpload;
            }

            return new SuccessDataResult<string>(resultOfUpload.Data, "Dosya güncellendi");
        }





        //Business Rules
        private static IResult CheckIfFileEnter(IFormFile file)
        {
            if (file.Length < 0)
            {
                return new ErrorResult("Dosya girilmemiş");
            }
            return new SuccessResult();
        }
         
        private static IResult CheckIfFileExtensionIsImage(string extension)
        {
            if (extension == ".jpg" || extension == ".png" || extension == ".jpeg" || extension == ".webp")
            {
                return new SuccessResult();
            }
            return new ErrorResult("Dosya uzantısı geçerli değil");
        }


        //To do: Eğer burda bir hata alırsan metodu void yap.
        private static string CheckIfDirectoryExists(string root)
        {
            if (!Directory.Exists(root))
            {
                return Directory.CreateDirectory(root).ToString();  
            }
            return root;
        }

        private static void CreateFile(string directory, IFormFile file)
        {
            //Yeni bir dosya oluşturulur ve eğer aynı isimde bir dosya bulunuyorsa üzerine yazılır.
            using (FileStream fileStream = File.Create(directory))
            {
                file.CopyTo(fileStream); //Oluşturduğumuz dosyanın içine resmi kopyaladık.
                fileStream.Flush(); //Tampondaki bilgilerin boşaltılmasını ve stream dosyasının güncellenmesini sağlar.
            }
        }

        private static IResult CheckIfFileExists(string filePath)
        {
            if (File.Exists(filePath))
            {
                return new SuccessResult();
            }
            return new ErrorResult("Böyle bir dosya mevcut değil");
        }
    }
}
