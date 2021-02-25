using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car{CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 200, ModelYear = 2010, Description = "Otomatik dizel"},
                new Car{CarId = 2, BrandId = 2, ColorId = 2, DailyPrice = 320, ModelYear = 2015, Description = "Manuel dizel"},
                new Car{CarId = 3, BrandId = 2, ColorId = 3, DailyPrice = 400, ModelYear = 2020, Description = "Otomatik Benzin"},
                new Car{CarId = 4, BrandId = 3, ColorId = 6, DailyPrice = 150, ModelYear = 2000, Description = "Manuel Benzin"},
                new Car{CarId = 5, BrandId = 4, ColorId = 4, DailyPrice = 500, ModelYear = 2005, Description = "Otomatik Benzin SUV"},
            };
        }

        public Car GetById(int carId)
        {
            return _cars.SingleOrDefault(p => p.CarId == carId);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetail()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarsDetail()
        {
            throw new NotImplementedException();
        }


        CarDetailDto ICarDal.GetDetail(int carId)
        {
            return GetDetail(carId);
        }

        public List<CarDetailDto> GetCarsDetail(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public CarDetailDto GetDetail(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
