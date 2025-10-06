using Core.Entities.Dtos;
using Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public static class EnumHelper
    {
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
