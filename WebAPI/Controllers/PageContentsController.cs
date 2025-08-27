using Business.Abstract;
using Entities.Dtos.PageContent;
using Entities.Enums;
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
        public async Task<IActionResult> Update([FromForm] PageContentUpdateDto pageContentDto)
            => Ok(await _pageContentService.Update(pageContentDto));
        
        
        
        [HttpGet]
        public async Task<IActionResult> GetAll(PageEnum pageEnum)
            => Ok(await _pageContentService.GetAll(pageEnum));
        
    
    }
}
