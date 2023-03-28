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
    public class MenuManager : IMenuService
    {
        private IMenuDal _menuDal;

        public MenuManager(IMenuDal menuDal)
        {
            _menuDal = menuDal;
        }

        public IResult Add(Menu menu)
        {
            _menuDal.Add(menu);
            return new SuccessResult(MenuMessages.MenuAdded);
        }

        public IResult Delete(Menu menu)
        {
            _menuDal.Delete(menu);
            return new SuccessResult(MenuMessages.MenuDeleted);
        }

        public IDataResult<Menu> Get(int id)
        {
            return new SuccessDataResult<Menu>(_menuDal.Get(m => m.Id == id), MenuMessages.MenuWasBrought);
        }

        public IDataResult<List<Menu>> GetAll()
        {
            return new SuccessDataResult<List<Menu>>(_menuDal.GetAll(), MenuMessages.MenusListed);
        }

        public IResult Update(Menu menu)
        {
            _menuDal.Update(menu);
            return new SuccessResult(MenuMessages.MenuUpdated);
        }
    }
}
