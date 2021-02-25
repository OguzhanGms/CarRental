﻿using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            if (customer.CompanyName.Length < 5)
            {
                return new ErrorResult(Messages.InavlidCompanyName);
            }
            _customerDal.Add(customer);
            return new SuccessResult(Messages.DataAdded);
        }

        public IResult Update(Customer customer)
        {
            if (customer.CompanyName.Length < 5)
            {
                return new ErrorResult(Messages.InavlidCompanyName);
            }
            _customerDal.Update(customer);
            return new SuccessResult(Messages.DataUpdated);
        }

        public IResult Delete(Customer customer)
        {
            if (customer.UserId == 0 || _customerDal.Get(c => c.UserId == customer.UserId) == null)
            {
                return new ErrorResult(Messages.InavlidUser);
            }
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.DataDeleted);
        }

        public IDataResult<Customer> Get(int customerId)
        {
            if (_customerDal.Get(c => c.CustomerId == customerId) == null)
            {
                return new ErrorDataResult<Customer>(Messages.NotFoundResult);
            }
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.CustomerId == customerId), Messages.DatasListed);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            if (_customerDal.GetAll() == null)
            {
                return new ErrorDataResult<List<Customer>>(Messages.NotFoundResult);
            }
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.DatasListed);
        }

        public IDataResult<Customer> GetByUserId(int userId)
        {
            if (_customerDal.Get(u => u.UserId == userId) == null)
            {
                return new ErrorDataResult<Customer>(Messages.NotFoundResult);
            }
            return new SuccessDataResult<Customer>(_customerDal.Get(u => u.UserId == userId), Messages.DatasListed);
        }

        public IDataResult<List<Customer>> GetCustomersByCompanyName(string companyName)
        {
            if (_customerDal.GetAll(c=>c.CompanyName.Contains(companyName)) == null)
            {
                return new ErrorDataResult<List<Customer>>(Messages.NotFoundResult);
            }
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(c => c.CompanyName.Contains(companyName)), Messages.DatasListed);
        }
    }
}