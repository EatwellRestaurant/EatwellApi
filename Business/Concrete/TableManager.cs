using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation.Table;
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
        readonly IBranchService _branchService;
        readonly IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;

        public TableManager(
            ITableDal tableDal, 
            IUnitOfWork unitOfWork, 
            IBranchService branchService, 
            IMapper mapper) 
            : base(tableDal)
        {
            _tableDal = tableDal;
            _unitOfWork = unitOfWork;
            _branchService = branchService;
            _mapper = mapper;
        }


        [SecuredOperation("admin", Priority = 1)]
        [ValidationAspect(typeof(TableInsertDtoValidator), Priority = 2)]
        public async Task<CreateSuccessResponse> Add(TableInsertDto insertDto)
        {
            await CheckIfBranchIdExists(insertDto.BranchId);

            await CheckIfTableNameExists(insertDto.Name, insertDto.BranchId);

            await _tableDal.AddAsync(_mapper.Map<Table>(insertDto));
            await _unitOfWork.SaveChangesAsync();

            return new CreateSuccessResponse(CommonMessages.EntityAdded);
        }



        [SecuredOperation("admin", Priority = 1)]
        [ValidationAspect(typeof(TableUpdateDtoValidator), Priority = 2)]
        public async Task<UpdateSuccessResponse> Update(int tableId, TableUpdateDto updateDto)
        {
            Table table = await GetByIdTableForDeleteAndUpdate(tableId);

            if (table.Name != updateDto.Name)
                await CheckIfTableNameExists(updateDto.Name, table.BranchId, tableId);

            _mapper.Map(updateDto, table);

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



        [SecuredOperation("admin", Priority = 1)]
        public async Task<DataResponse<List<TableListDto>>> GetAllForAdmin(int branchId) 
            => new DataResponse<List<TableListDto>>(_mapper.Map<List<TableListDto>>
                (await _tableDal
                .GetAllQueryable(t => t.BranchId == branchId && !t.IsDeleted)
                .OrderBy(t => t.No)
                .ToListAsync()),
                CommonMessages.EntityListed);




        #region BusinessRules

        private async Task CheckIfBranchIdExists(int branchId)
        {
            if (!await _branchService.AnyAsync(b => b.Id == branchId && !b.IsDeleted))
                throw new EntityNotFoundException("Şube");
        }


        private async Task CheckIfTableNameExists(string tableName, int branchId, int? tableId = null)
        {
            if (await _tableDal.AnyAsync(t => t.Name == tableName && !t.IsDeleted && t.BranchId == branchId && (tableId.HasValue ? t.Id != tableId : true)))
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
