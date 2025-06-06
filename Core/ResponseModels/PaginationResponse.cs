﻿using Core.Requests;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ResponseModels
{
    public record PaginationResponse<T> : Response
    {
        public List<T> Data { get; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; }

        public int TotalItems { get; }

        public bool HasPrevious => PageNumber > 1;

        public bool HasNext => PageNumber < TotalPages;



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
