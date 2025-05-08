using Business.Abstract;
using Entities.Dtos.Table;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        readonly ITableService _tableService;

        public TablesController(ITableService tableService) 
            => _tableService = tableService;
        


        [HttpPost]
        public async Task<IActionResult> Add(TableInsertDto insertDto) 
            => Ok(await _tableService.Add(insertDto));



        [HttpPut]
        public async Task<IActionResult> Update(int tableId, TableUpdateDto updateDto)
            => Ok(await _tableService.Update(tableId, updateDto));
        

        
        [HttpDelete]
        public async Task<IActionResult> Delete(int tableId)
            => Ok(await _tableService.Delete(tableId));
        
        

        [HttpGet]
        public async Task<IActionResult> GetAllForAdmin(int branchId)
            => Ok(await _tableService.GetAllForAdmin(branchId));

    }
}
