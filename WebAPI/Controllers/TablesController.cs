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
        public async Task<IActionResult> Add(TableUpsertDto upsertDto) 
            => Ok(await _tableService.Add(upsertDto));



        [HttpPut]
        public async Task<IActionResult> Update(int tableId, TableUpsertDto upsertDto)
            => Ok(await _tableService.Update(tableId, upsertDto));
        

        
        [HttpDelete]
        public async Task<IActionResult> Delete(int tableId)
            => Ok(await _tableService.Delete(tableId));

    }
}
