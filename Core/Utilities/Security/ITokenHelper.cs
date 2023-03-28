﻿using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security
{
    public interface ITokenHelper
    {
        //Bu metotla, token'ın kim için oluşturulacağını ve içerisine hangi yetkileri koyacağımızı belirleriz.
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
