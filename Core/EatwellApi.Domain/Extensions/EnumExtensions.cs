using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EatwellApi.Domain.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue
                .GetType()
                .GetMember(enumValue.ToString())         // O anki enum değerinin ismini buluyoruz 
                .First()                                 // İlk üyeyi alıyoruz
                .GetCustomAttribute<DisplayAttribute>()? // Bu enum değerinde Display attribute var mı bakıyoruz
                .Name                                    // Varsa Display.Name değerini döndürüyoruz
                ?? enumValue.ToString();                 // Yoksa enum’un kendi ismini döndürüyoruz
        }
    }
}
