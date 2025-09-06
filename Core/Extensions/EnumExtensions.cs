using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
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
