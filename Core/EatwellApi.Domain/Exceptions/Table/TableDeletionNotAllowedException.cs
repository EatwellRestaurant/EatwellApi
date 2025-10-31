using EatwellApi.Domain.Exceptions.Bases;

namespace EatwellApi.Domain.Exceptions.Table
{
    public class TableDeletionNotAllowedException : BadRequestBaseException
    {
        /// <summary>
        /// Bu masaya ait rezervasyon olduğu için silinemez!
        /// </summary>
        public TableDeletionNotAllowedException() : base("Bu masaya ait rezervasyon olduğu için silinemez!")
        {
        }
    }
}
