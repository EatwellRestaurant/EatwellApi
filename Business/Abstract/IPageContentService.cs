using Core.ResponseModels;
using Entities.Dtos.PageContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPageContentService 
    {
        Task<UpdateSuccessResponse> Save(PageContentDto pageContentDto);
    }
}
