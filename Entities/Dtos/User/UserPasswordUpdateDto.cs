using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.User
{
    public class UserPasswordUpdateDto : IDto
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordAgain { get; set; } 
    }
}
