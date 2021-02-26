using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            if (_rentalDal.Get(r => r.CarId == rental.CarId && r.ReturnDate == null) != null)
            {
                return new ErrorResult(Messages.RentedCar);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.DataAdded);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.DataUpdated);
        }

        public IResult Delete(Rental rental)
        {
            if (_rentalDal.Get(r => r.RentalId == rental.RentalId) == null)
            {
                return new ErrorResult(Messages.NotFoundResult);
            }
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.DataDeleted);
        }

        public IDataResult<Rental> Get(int rentalId)
        {
            if (_rentalDal.Get(r => r.RentalId == rentalId) == null)
            {
                return new ErrorDataResult<Rental>(Messages.NotFoundResult);
            }
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.RentalId == rentalId), Messages.DataDeleted);
        }

        public IDataResult<List<RentalDetailDto>> GetAll()
        {
            if (_rentalDal.GetAll().Count <= 0)
            {
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.NotFoundResult);
            }
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalsDetail(), Messages.DatasListed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalsDetail()
        {
            if (_rentalDal.GetAll().Count <= 0)
            {
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.NotFoundResult);
            }
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalsDetail(), Messages.DatasListed);
        }

        public IDataResult<RentalDetailDto> GetDetail(int rentalId)
        {
            if (_rentalDal.GetDetail(rentalId) == null)
            {
                return new ErrorDataResult<RentalDetailDto>(Messages.NotFoundResult);
            }
            return new SuccessDataResult<RentalDetailDto>(_rentalDal.GetDetail(rentalId), Messages.DatasListed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalsByUserId(int userId)
        {
            if (_rentalDal.GetRentalsDetail(r => r.UserId == userId).Count <= 0)
            {
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.NotFoundResult);
            }
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalsDetail(r => r.UserId == userId), Messages.DatasListed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalsByCustomerId(int customerId)
        {
            if (_rentalDal.GetRentalsDetail(r => r.CustomerId == customerId).Count <= 0)
            {
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.NotFoundResult);
            }
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalsDetail(r => r.CustomerId == customerId), Messages.DatasListed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalsByCarId(int carId)
        {
            if (_rentalDal.GetRentalsDetail(r => r.CarId == carId).Count <= 0)
            {
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.NotFoundResult);
            }
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalsDetail(r => r.CarId == carId), Messages.DatasListed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalsByNullReturnDate()
        {
            if (_rentalDal.GetRentalsDetail(r => r.ReturnDate == null).Count <= 0)
            {
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.NotFoundResult);
            }
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalsDetail(r => r.ReturnDate == null), Messages.DatasListed);
        }
    }
}
