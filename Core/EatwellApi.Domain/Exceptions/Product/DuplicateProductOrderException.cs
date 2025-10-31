using EatwellApi.Domain.Exceptions.Bases;

namespace EatwellApi.Domain.Exceptions.Product
{
    public class DuplicateProductOrderException : BadRequestBaseException
    {
        /// <summary>
        /// Aynı sıralama değerine sahip birden fazla ürün var!
        /// </summary>
        public DuplicateProductOrderException() : base("Aynı sıralama değerine sahip birden fazla ürün var!")
        {
        }
    }
}
