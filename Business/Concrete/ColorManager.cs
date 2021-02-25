using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        ICarColorDal _colorDal;

        public ColorManager(ICarColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(CarColor color)
        {
            if (color.ColorName.Length < 2)
            {
                return new ErrorResult(Messages.NameMin);
            }
            _colorDal.Add(color);
            return new SuccessResult(Messages.DataAdded);
        }

        public IResult Update(CarColor color)
        {
            if (color.ColorName.Length < 2)
            {
                return new ErrorResult(Messages.NameMin);
            }
            _colorDal.Update(color);
            return new SuccessResult(Messages.DataUpdated);
        }

        public IResult Delete(CarColor color)
        {
            if (color.ColorName.Length < 2)
            {
                return new ErrorResult(Messages.NameMin);
            }
            _colorDal.Delete(color);
            return new SuccessResult(Messages.DataDeleted);
        }

        public IDataResult<CarColor> Get(int colorId)
        {
            if (_colorDal.Get(b => b.ColorId == colorId) == null)
            {
                return new ErrorDataResult<CarColor>(Messages.NotFoundResult);
            }

            return new SuccessDataResult<CarColor>(_colorDal.Get(p => p.ColorId == colorId));
        }

        public IDataResult<List<CarColor>> GetAll()
        {
            if (_colorDal.GetAll().Count <= 0)
            {
                return new ErrorDataResult<List<CarColor>>(Messages.NotFoundResult);
            }
            return new SuccessDataResult<List<CarColor>>(_colorDal.GetAll());
        }
    }
}
