using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            if (user.FirstName.Length < 2)
            {
                return new ErrorResult(Messages.NameMin);
            }
            else if (user.LastName.Length <2)
            {
                return new ErrorResult(Messages.NameMin);
            }
            else if (user.Email.Contains("@") == false || user.Email.Length < 5)
            {
                return new ErrorResult(Messages.InavlidEmail);
            }
            else if (user.Password.Length < 8)
            {
                return new ErrorResult(Messages.InavlidPassword);
            }
            _userDal.Add(user);
            return new SuccessResult(Messages.DataAdded);
        }

        public IResult Update(User user)
        {
            if (_userDal.Get(u=>u.UserId == user.UserId) == null)
            {
                return new ErrorResult(Messages.NotFoundResult);
            }
            else if (user.FirstName.Length < 2)
            {
                return new ErrorResult(Messages.NameMin);
            }
            else if (user.LastName.Length < 2)
            {
                return new ErrorResult(Messages.NameMin);
            }
            else if (user.Email.Contains("@") == false || user.Email.Length < 5)
            {
                return new ErrorResult(Messages.InavlidEmail);
            }
            else if (user.Password.Length < 8)
            {
                return new ErrorResult(Messages.InavlidPassword);
            }
            _userDal.Update(user);
            return new SuccessResult(Messages.DataUpdated);
        }

        public IResult Delete(User user)
        {
            if (_userDal.Get(u => u.UserId == user.UserId) == null)
            {
                return new ErrorResult(Messages.NotFoundResult);
            }
            _userDal.Delete(user);
            return new SuccessResult(Messages.DataDeleted);
        }

        public IDataResult<User> Get(int userId)
        {
            if (_userDal.Get(c => c.UserId == userId) == null)
            {
                return new ErrorDataResult<User>(Messages.NotFoundResult);
            }
            return new SuccessDataResult<User>(_userDal.Get(u=>u.UserId == userId), Messages.DatasListed);
        }

        public IDataResult<List<User>> GetAll()
        {
            if (_userDal.GetAll() == null)
            {
                return new ErrorDataResult<List<User>>(Messages.NotFoundResult);
            }
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.DatasListed);
        }

        public IDataResult<List<User>> GetUsersByFirstName(string firstName)
        {
            if (_userDal.GetAll(u => u.FirstName.Contains(firstName)).Count == 0)
            {
                return new ErrorDataResult<List<User>>(Messages.NotFoundResult);
            }
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u=>u.FirstName.Contains(firstName)), Messages.DatasListed);
        }

        public IDataResult<List<User>> GetUsersByLastName(string lastName)
        {
            if (_userDal.GetAll(u => u.LastName.Contains(lastName)) == null)
            {
                return new ErrorDataResult<List<User>>(Messages.NotFoundResult);
            }
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.LastName.Contains(lastName)), Messages.DatasListed);
        }

        public IDataResult<List<User>> GetUsersByEmail(string email)
        {
            if (_userDal.GetAll(u => u.Email.Contains(email)) == null)
            {
                return new ErrorDataResult<List<User>>(Messages.NotFoundResult);
            }
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.Email.Contains(email)), Messages.DatasListed);
        }
    }
}
