using Business.Abstract;
using Business.Constants.Messages.Entity;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TableManager : ITableService
    {
        private ITableDal _tableDal;

        public TableManager(ITableDal tableDal)
        {
            _tableDal = tableDal;
        }

        public IResult Add(Table table)
        {
            _tableDal.Add(table);
            return new SuccessResult(TableMessages.TableAdded);
        }

        public IResult Delete(Table table)
        {
            _tableDal.Delete(table);
            return new SuccessResult(TableMessages.TableDeleted);
        }

        public IDataResult<Table> Get(int id)
        {
            return new SuccessDataResult<Table>(_tableDal.Get(t => t.Id == id), TableMessages.TableWasBrought);
        }

        public IDataResult<List<Table>> GetAll()
        {
            return new SuccessDataResult<List<Table>>(_tableDal.GetAll(), TableMessages.TablesListed);
        }

        public IResult Update(Table table)
        {
            _tableDal.Update(table);
            return new SuccessResult(TableMessages.TableUpdated);
        }
    }
}
