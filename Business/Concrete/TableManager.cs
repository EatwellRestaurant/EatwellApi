using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Exceptions.General;
using Core.ResponseModels;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Table;
using Microsoft.EntityFrameworkCore;
using Service.Concrete;

namespace Business.Concrete
{
    public class TableManager : Manager<Table>, ITableService
    {
        readonly ITableDal _tableDal;
        readonly IUnitOfWork _unitOfWork;

        public TableManager(ITableDal tableDal, IUnitOfWork unitOfWork) : base(tableDal)
        {
            _tableDal = tableDal;
            _unitOfWork = unitOfWork;
        }


        [SecuredOperation("admin", Priority = 1)]
        [ValidationAspect(typeof(TableUpsertDtoValidator), Priority = 2)]
        public async Task<CreateSuccessResponse> Add(TableUpsertDto upsertDto)
        {
            await CheckIfTableNameExists(upsertDto.Name);

            Table table = new()
            {
                Name = upsertDto.Name,
                Capacity = upsertDto.Capacity
            };

            await _tableDal.AddAsync(table);
            await _unitOfWork.SaveChangesAsync();

            return new CreateSuccessResponse(CommonMessages.EntityAdded);
        }



        [SecuredOperation("admin", Priority = 1)]
        [ValidationAspect(typeof(TableUpsertDtoValidator), Priority = 2)]
        public async Task<UpdateSuccessResponse> Update(int tableId, TableUpsertDto upsertDto)
        {
            Table table = await GetByIdTableForDeleteAndUpdate(tableId);

            await CheckIfTableNameExists(upsertDto.Name, tableId);

            table.Name = upsertDto.Name;
            table.Capacity = upsertDto.Capacity;

            _tableDal.Update(table);
            await _unitOfWork.SaveChangesAsync();

            return new UpdateSuccessResponse(CommonMessages.EntityUpdated);
        }



        [SecuredOperation("admin", Priority = 1)]
        public async Task<DeleteSuccessResponse> Delete(int tableId)
        {
            Table table = await GetByIdTableForDeleteAndUpdate(tableId);

            table.IsDeleted = true;
            table.DeleteDate = DateTime.Now;

            _tableDal.Update(table);
            await _unitOfWork.SaveChangesAsync();
            
            return new DeleteSuccessResponse(CommonMessages.EntityDeleted);
        }



        #region BusinessRules

        private async Task CheckIfTableNameExists(string tableName, int? tableId = null)
        {
            if (await _tableDal.AnyAsync(t => t.Name == tableName && !t.IsDeleted && (tableId.HasValue ? t.Id != tableId : true)))
                throw new EntityAlreadyExistsException("masa ismi");
        }


        private async Task<Table> GetByIdTableForDeleteAndUpdate(int tableId)
        {
            Table? table = await _tableDal
                .Where(t => t.Id == tableId && !t.IsDeleted)
                .SingleOrDefaultAsync()
                ?? throw new EntityNotFoundException("Masa");


            return table;
        }

        #endregion
    }
}
