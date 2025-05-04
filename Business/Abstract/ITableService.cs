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
        Task<CreateSuccessResponse> Add(TableUpsertDto upsertDto);

        Task<UpdateSuccessResponse> Update(int tableId, TableUpsertDto upsertDto);

        Task<DeleteSuccessResponse> Delete(int tableId);

    }
}
