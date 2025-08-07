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
    public class PageContentDto : IDto
    {
        public int Id { get; internal set; }

        public string? Description { get; set; }

        public IFormFile? ImagePath { get; set; }
    }
}
