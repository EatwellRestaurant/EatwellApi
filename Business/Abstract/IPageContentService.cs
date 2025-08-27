using Core.ResponseModels;
using Entities.Dtos.PageContent;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPageContentService 
    {
        Task<DataResponse<string?>> Update(PageContentUpdateDto pageContentDto);

        Task<DataResponse<List<PageContentListDto>>> GetAll(PageEnum pageEnum);
    }
}
