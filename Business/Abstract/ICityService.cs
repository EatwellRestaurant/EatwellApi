﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICityService
    {
        Task<IDataResult<List<City>>> GetAll();
        Task<IDataResult<City?>> Get(int id);
        Task<IResult> Add(City city);
        IResult Delete(City city);
        IResult Update(City city);
    }
}
