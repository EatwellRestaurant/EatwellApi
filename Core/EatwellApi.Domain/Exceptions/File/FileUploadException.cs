using EatwellApi.Domain.Exceptions.Bases;

namespace EatwellApi.Domain.Exceptions.File
{
    public class FileUploadException : BadRequestBaseException
    {
        /// <summary>
        /// Dosya yüklenemedi!
        /// </summary>
        public FileUploadException() : base("Dosya yüklenemedi!")
        {
        }
    }
}
