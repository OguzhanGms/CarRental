using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<Rental> Get(int rentalId);
        IDataResult<List<RentalDetailDto>> GetAll();
        IDataResult<List<RentalDetailDto>> GetRentalsDetail();
        IDataResult<RentalDetailDto> GetDetail(int rentalId);
        IDataResult<List<RentalDetailDto>> GetRentalsByUserId(int userId);
        IDataResult<List<RentalDetailDto>> GetRentalsByCustomerId(int customerId);
        IDataResult<List<RentalDetailDto>> GetRentalsByCarId(int carId);
        IDataResult<List<RentalDetailDto>> GetRentalsByNullReturnDate();
    }
}
