using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<User> Get(int userId);
        IDataResult<List<User>> GetAll();
        IDataResult<List<User>> GetUsersByFirstName(string firstName);
        IDataResult<List<User>> GetUsersByLastName(string lastName);
        IDataResult<List<User>> GetUsersByEmail(string email);
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
    }
}
