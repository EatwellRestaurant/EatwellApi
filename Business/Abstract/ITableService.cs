using Core.ResponseModels;
using Entities.Concrete;
using Entities.Dtos.MealCategory;
using Entities.Dtos.Table;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITableService : IService<Table>
    {
        Task<CreateSuccessResponse> Add(TableInsertDto insertDto);

        Task<UpdateSuccessResponse> Update(int tableId, TableUpdateDto updateDto);

        Task<DeleteSuccessResponse> Delete(int tableId);

        Task<DataResponse<List<TableListDto>>> GetAllForAdmin(int branchId);

    }
}
