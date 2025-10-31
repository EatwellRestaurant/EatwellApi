using EatwellApi.Domain.Exceptions.Bases;

namespace EatwellApi.Domain.Exceptions.Table
{
    public class CapacityChangeNotAllowedException : BadRequestBaseException
    {
        /// <summary>
        /// Bu masanın ileri tarihlerde rezervasyonları bulunduğu için kapasitesi değiştirilemez!
        /// </summary>
        public CapacityChangeNotAllowedException() : base("Bu masanın ileri tarihlerde rezervasyonları bulunduğu için kapasitesi değiştirilemez!")
        {
        }
    }
}
