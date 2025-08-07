using Business.Abstract;
using Entities.Dtos.PageContent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageContentsController : ControllerBase
    {
        readonly IPageContentService _pageContentService;

        public PageContentsController(IPageContentService pageContentService)
        {
            _pageContentService = pageContentService;
        }



        [HttpPut]
        public async Task<IActionResult> Save([FromForm] PageContentDto pageContentDto)
            => Ok(await _pageContentService.Save(pageContentDto));
        
    
    }
}
