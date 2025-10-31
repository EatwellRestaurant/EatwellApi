using EatwellApi.Domain.Exceptions.Bases;

namespace EatwellApi.Domain.Exceptions.File
{
    public class FileSizeExceededException : BadRequestBaseException
    {
        /// <summary>
        /// Dosya boyutu, izin verilen maksimum sınırı aşıyor.
        /// </summary>
        public FileSizeExceededException() : base("Dosya boyutu, izin verilen maksimum sınırı aşıyor!")
        {
        }
    }
}
