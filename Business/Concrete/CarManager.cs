using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Entities.DTOs;
using Core.Utilities.Results;
using Business.Constant;
using Core.CrossCuttingConcerns.Validation;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Business.BusinessAspect.Autofac;
using Core.Aspect.Autofac.Caching;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Business;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        
        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("admin,car.add")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            var result = BusinessRules.Run(CheckCountOfSameCarBrand(car.BrandId));
            if (result != null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        [SecuredOperation("admin,car.delete")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [CacheAspect]
        [SecuredOperation("admin,car.getall")]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }
        
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c=>c.CarId == id),Messages.CarById);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(b => b.BrandId ==brandId));//brandIdsi gonderilen idye eşit olan araclar
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));//colorIdsi gonderilen idye eşit olan araclar
        }

        [CacheAspect]
        public IDataResult<List<CarDetailsDto>> GetCarsDetails() //dto olarak olusturdugumuz joinden arabanın marka adı ve renk adı da gelecek.
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarsDetails());
        }

        public IDataResult<List<CarDetailsDto>> GetCarsDetailByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarsDetailByBrandId(brandId));
        }

        public IDataResult<List<CarDetailsDto>> GetCarsDetailByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarsDetailByColorId(colorId));
        }

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("admin,car.update")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
           _carDal.Update(car);
           return new SuccessResult(Messages.CarUpdated);
        }

        private IResult CheckCountOfSameCarBrand(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId).Count;
            if (result>10)
            {
                return new ErrorResult(Messages.SameBrandCarsCountExceeded);
            }
            return new SuccessResult();
        }

        public IDataResult<CarDetailsDto> GetCarDetailsById(int carId)
        {
            return new SuccessDataResult<CarDetailsDto>(_carDal.GetCarDetailsById(carId));
        }
    }
}
