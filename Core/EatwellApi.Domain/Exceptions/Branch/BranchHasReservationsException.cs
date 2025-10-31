using EatwellApi.Domain.Exceptions.Bases;

namespace EatwellApi.Domain.Exceptions.Branch
{
    public class BranchHasReservationsException : BadRequestBaseException
    {
        /// <summary>
        /// Bu şubeye ait rezervasyon olduğu için silinemez!
        /// </summary>
        public BranchHasReservationsException() : base("Bu şubeye ait rezervasyon olduğu için silinemez!")
        {
        }
    }
}
