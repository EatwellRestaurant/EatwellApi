namespace EatwellApi.Application.Abstractions.Services.Reservation
{
    public interface IReservationService
    {
        Task<int> CountReservationsAsync(int? branchId = null);
    } 
}
 