using EatwellApi.Application.Parameters;
using Microsoft.AspNetCore.Http;

namespace EatwellApi.Application.Wrappers
{
    public record PaginationResponse<T> : Response
    {
        public List<T> Data { get; init; } = new();

        public int PageNumber { get; init; }

        public int PageSize { get; init; }

        public int TotalPages { get; init; }

        public int TotalItems { get; init; }

        public bool HasPrevious => PageNumber > 1;

        public bool HasNext => PageNumber < TotalPages;


        // Cacheleme işleminde JSON Deserialize sırasında parametresiz constructor'a ihtiyaç duyuluyor.
        // Bunun için parametresiz constructor ekliyoruz.
        public PaginationResponse() { }


        public PaginationResponse(List<T> data, PaginationRequest paginationRequest, int totalItems)
        {
            int totalPages = (int)Math.Ceiling(totalItems / (double)paginationRequest.PageSize);

            Data = data;
            PageNumber = paginationRequest.PageNumber;
            PageSize = paginationRequest.PageSize;
            TotalItems = totalItems;
            TotalPages = totalPages == 0 ? 1 : totalPages;
            Success = true;
            StatusCode = StatusCodes.Status200OK;
        }
    }
}
