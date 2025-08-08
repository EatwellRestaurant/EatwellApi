using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Dtos.PageContent
{
    public class PageContentUpdateDto : IDto
    {
        public int Id { get; set; }

        public string? Description { get; set; }

        public IFormFile? Image { get; set; }
    }
}
