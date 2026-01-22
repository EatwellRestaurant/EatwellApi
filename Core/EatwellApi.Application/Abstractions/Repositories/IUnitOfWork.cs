namespace EatwellApi.Application.Abstractions.Repositories
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
