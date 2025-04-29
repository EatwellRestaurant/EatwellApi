using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.User
{
    public class UserDetailDto : UserListDto
    {
        public bool Verification { get; set; }

        public DateTime? LastLoginDate { get; set; }

    }
}
