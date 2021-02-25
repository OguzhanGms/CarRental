using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Newtonsoft.Json.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarDal : EFEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarsDetail(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            
            return this.getResult(filter);
            
        }

        public CarDetailDto GetDetail(int carId)
        {
            return this.getResult(c => c.CarId == carId).First();
        }

        List<CarDetailDto> getResult(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result =
                    from c in context.Cars
                    join b in context.Brands
                        on c.BrandId equals b.BrandId
                    join cl in context.Colors on c.ColorId equals cl.ColorId
                    select new CarDetailDto()
                    {
                        CarId = c.CarId,
                        CarName = c.CarName,
                        BrandId = c.BrandId,
                        BrandName = b.BrandName,
                        ColorName = cl.ColorName,
                        ColorId = c.ColorId,
                        ModelYear = c.ModelYear,
                        DailyPrice = c.DailyPrice,
                        Description = c.Description
                    };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        } 
    }
}
