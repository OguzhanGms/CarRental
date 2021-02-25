using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length < 2)
            {
                return new ErrorResult(Messages.NameMin);
            }
            _brandDal.Add(brand);
            return new SuccessResult(Messages.DataAdded);
        }

        public IResult Update(Brand brand)
        {
            if (_brandDal.Get(b => b.BrandId == brand.BrandId) == null)
            {
                return new ErrorResult(Messages.NotFoundResult);
            }
            else if (brand.BrandName.Length < 2)
            {
                return new ErrorResult(Messages.NameMin);
            }
            _brandDal.Update(brand);
            return new SuccessResult(Messages.DataAdded);
        }

        public IResult Delete(Brand brand)
        {
            if (_brandDal.Get(b=>b.BrandId == brand.BrandId) == null)
            {
                return new ErrorResult(Messages.NotFoundResult);
            }
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.DataDeleted);
        }

        public IDataResult<Brand> Get(int brandId)
        {
            if (_brandDal.Get(b=>b.BrandId == brandId) == null)
            {
                return new ErrorDataResult<Brand>(Messages.NotFoundResult);
            }

            return new SuccessDataResult<Brand>(_brandDal.Get(p => p.BrandId == brandId));
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (_brandDal.GetAll().Count <= 0)
            {
                return new ErrorDataResult<List<Brand>>(Messages.NotFoundResult);
            }
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }
    }
}
