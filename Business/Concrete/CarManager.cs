using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IDataResult<Car> Get(int carId)
        {
            if (_carDal.Get(c => c.CarId == carId) == null)
            {
                return new ErrorDataResult<Car>(Messages.NotFoundResult);
            }

            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (_carDal.GetAll().Count <= 0)
            {
                return new ErrorDataResult<List<Car>>(Messages.NotFoundResult);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.DatasListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId)
        {
            if (_carDal.GetCarsDetail(c => c.BrandId == brandId).Count <= 0)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.NotFoundResult);
            }

            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetail(p => p.BrandId == brandId),
                Messages.DatasListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId)
        {
            if (_carDal.GetAll(c => c.ColorId == colorId).Count <= 0)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.NotFoundResult);
            }

            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetail(p => p.ColorId == colorId),
                Messages.DatasListed);
        }

        public IDataResult<CarDetailDto> GetDetail(int carId)
        {
            if (_carDal.GetDetail(carId) == null)
            {
                return new ErrorDataResult<CarDetailDto>(Messages.NotFoundResult);
            }

            return new SuccessDataResult<CarDetailDto>(_carDal.GetDetail(carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetail()
        {
            if (_carDal.GetCarsDetail().Count <= 0)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.NotFoundResult);
            }

            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetail(), Messages.DatasListed);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.DataAdded);
        }
        
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            if (_carDal.Get(c=>c.CarId == car.CarId) == null)
            {
                return new ErrorResult(Messages.NotFoundResult);
            }

            _carDal.Update(car);
            return new SuccessResult(Messages.DataUpdated);
        }

        public IResult Delete(Car car)
        {
            if (_carDal.Get(c => c.CarId == car.CarId) == null)
            {
                return new ErrorResult(Messages.NotFoundResult);
            }

            _carDal.Delete(car);
            return new ErrorResult(Messages.DataDeleted);
        }
    }
}

