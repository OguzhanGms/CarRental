using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFRentalDal : EFEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalsDetail(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            return getResult(filter);
        }

        public RentalDetailDto GetDetail(int rentalId)
        {
            return getResult(r => r.RentalId == rentalId).First();
        }

        List<RentalDetailDto> getResult(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                    join r in context.Rentals on c.CarId equals r.CarId
                    join cs in context.Customers on r.CustomerId equals cs.CustomerId
                    join u in context.Users on cs.UserId equals u.UserId
                    select new RentalDetailDto
                    {
                        RentalId = r.RentalId,
                        CarId = c.CarId,
                        CarName = c.CarName,
                        CustomerId = cs.CustomerId,
                        CompanyName = cs.CompanyName,
                        UserId = u.UserId,
                        UserName = u.FirstName + " " + u.LastName,
                        RentDate = r.RentDate,
                        ReturnDate = r.ReturnDate
                    };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
