using EatwellApi.Application.Dtos;
using EatwellApi.Application.Extensions;

namespace EatwellApi.Application.Helpers
{
    public static class EnumHelper
    {
        /// <summary>
        /// Belirtilen enum türündeki değerleri, lookup (Id - Name) yapısına sahip DTO listesine dönüştürür.
        /// </summary>
        /// <typeparam name="TEnum">
        /// Lookup verisi üretilecek enum türü.
        /// Enum değerleri <see cref="System.ComponentModel.DataAnnotations.DisplayAttribute"/> ile
        /// tanımlanmışsa, <c>Name</c> alanı bu değerden alınır.
        /// </typeparam>
        /// <typeparam name="TDto">
        /// Enum değerlerini temsil eden lookup DTO türü.
        /// <see cref="LookupDto{TKey}"/> tipinden türemeli ve parametresiz constructor içermelidir.
        /// </typeparam>
        /// <returns>
        /// Enum değerlerini temsil eden <typeparamref name="TDto"/> listesini döndürür.
        /// </returns>
        public static List<TDto> ToLookupList<TEnum, TDto>()
            where TEnum : Enum
            where TDto : LookupDto<byte>, new()
        {
            return Enum.GetValues(typeof(TEnum))  // Enum içindeki tüm değerleri döndüren bir System.Array üretiyoruz.
                .Cast<TEnum>()  // Array içindeki öğeleri, yine Enum türüne cast edip IEnumerable<TEnum> haline getiriyoruz.
                .Select(lookup => new TDto
                {
                    Id = Convert.ToByte(lookup),
                    Name = lookup.GetDisplayName()
                })
                .ToList();
        }
    }
}
