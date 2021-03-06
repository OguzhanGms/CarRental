﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(CarColor color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.DataAdded);
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(CarColor color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.DataUpdated);
        }

        public IResult Delete(CarColor color)
        {
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
