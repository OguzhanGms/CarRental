using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

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
    }
}
