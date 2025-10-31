using EatwellApi.Domain.Exceptions.Bases;

namespace EatwellApi.Domain.Exceptions.File
{
    public class FileNotProvidedException : BadRequestBaseException
    {
        /// <summary>
        /// Lütfen bir resim dosyası giriniz!
        /// </summary>
        public FileNotProvidedException() : base("Lütfen bir resim dosyası giriniz!")
        {
        }
    }
}
