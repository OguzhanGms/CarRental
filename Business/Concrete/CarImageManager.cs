using Business.Abstract;
using Core.Utilities.Helpers.FileHelpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using Business.Constants;
using Core.Utilities.Business;
using Rental = Entities.Concrete.Rental;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfImageLimitExceeded(carImage.CarId), CheckIfCarImageUploaded(carImage));
            
            if (result != null)
            {
                return result;
            }
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Update(CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageUpdated(carImage));

            if (result != null)
            {
                return result;
            }
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageDeleted(carImage));

            if (result != null)
            {
                return result;
            }
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<CarImage> Get(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c=>c.CarImageId == carImageId));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(carId));
        }

        private IResult CheckIfImageLimitExceeded(int carId)
        {
            var carImagecount = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (carImagecount >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }

            return new SuccessResult();
        }

        private List<CarImage> CheckIfCarImageNull(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (!result.Any())
            {
                return new List<CarImage>(new
                    List<CarImage>
                    {
                        new CarImage
                        {
                            CarId = carId,
                            ImagePath = FilePaths.DefaultCarImagePath
                        }
                    });
            }
            return result;
        }

        private IResult CheckIfCarImageUploaded(CarImage carImage)
        {
            var result = FileHelper.CarImageUpload(carImage.FromFile).Result;
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }

            carImage.Date = DateTime.Now;
            carImage.ImagePath = result.Data;
            return new SuccessResult();
        }

        private IResult CheckIfCarImageUpdated(CarImage carImage)
        {
            var result = FileHelper.CarImageUpdate(carImage.ImagePath, carImage.FromFile).Result;
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }

            carImage.Date = DateTime.Now;
            carImage.ImagePath = result.Data;
            return new SuccessResult();
        }

        private IResult CheckIfCarImageDeleted(CarImage carImage)
        {
            var result = FileHelper.CarImageDelete(carImage.ImagePath).Result;
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }
            return new SuccessResult();
        }
    }
}
