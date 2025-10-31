namespace EatwellApi.Application.Dtos.User
{
    public class UserDetailDto : UserListDto
    {
        public bool Verification { get; set; }

        public DateTime? LastLoginDate { get; set; }

    }
}
