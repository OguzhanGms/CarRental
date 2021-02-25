using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColorService
    {
        IResult Add(CarColor color);
        IResult Update(CarColor color);
        IResult Delete(CarColor color);
        IDataResult<CarColor> Get(int colorId);
        IDataResult<List<CarColor>> GetAll();
    }
}
