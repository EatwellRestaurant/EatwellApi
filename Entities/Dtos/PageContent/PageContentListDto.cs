using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.PageContent
{
    public class PageContentListDto : IDto
    {
        public int Id { get; internal set; }

        public byte SectionId { get; set; }

        public string SectionName { get; set; }

        public string? Description { get; set; }

        public string? ImagePath { get; set; }
    }
}
