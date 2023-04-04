using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants.Messages.Entity
{
    public static class BranchMessages
    {
        public static string BranchAdded = "Şube Eklendi"; 
        public static string BranchDeleted = "Şube Silindi";
        public static string BranchUpdated = "Şube Güncellendi";
        public static string BranchWasBrought = "Şube Getirildi";
        public static string BranchesListed = "Şubeler Listelendi";
        public static string BranchNameAlreadyExists = "Bu isimde zaten başka bir şube var";
        public static string BranchAddressAlreadyExists = "Bu adreste başka bir şube var";
    }
}
