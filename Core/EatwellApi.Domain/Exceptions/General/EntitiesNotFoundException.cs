using EatwellApi.Domain.Exceptions.Bases;

namespace EatwellApi.Domain.Exceptions.General
{
    public class EntitiesNotFoundException : NotFoundBaseException
    {
        public List<int>? Ids { get; set; }


        /// <summary>
        /// Varsayılan mesaj yerine, özel bir hata mesajı tanımlamak için kullanılır.
        /// </summary>
        public EntitiesNotFoundException(string message, bool isCustomMessage) : base(message)
        {
        }



        /// <summary>
        /// Gönderdiğiniz bu {name} mevcutta yok!
        /// </summary>
        public EntitiesNotFoundException(string name) : base($"Gönderdiğiniz bu {name} mevcutta yok!")
        {
        }


        /// <summary>
        /// Gönderdiğiniz bu {name}, {modelName} içinde yok!
        /// </summary>
        public EntitiesNotFoundException(string name, string modelName) : base($"Gönderdiğiniz bu {name}, {modelName} içinde yok!")
        {
        }
    }
}
