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

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public IResult Add(Car car)
        {
            //iş kuralları -- business
            //araba ismi min 2 harf ve gunluk fiyatı 0dan buyuk olmalı
            if (car.DailyPrice < 0 && car.Description.Length>=2)
            {
                return new ErrorResult();
            }

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c=>c.CarId == id));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(b => b.BrandId ==brandId));//brandIdsi gonderilen idye eşit olan araclar
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));//colorIdsi gonderilen idye eşit olan araclar
        }

        public IDataResult<List<CarDetailsDto>> GetCarsDetails() //dto olarak olusturdugumuz joinden arabanın marka adı ve renk adı da gelecek.
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarsDetails());
        }

        public IResult Update(Car car)
        {
           _carDal.Update(car);
           return new SuccessResult(Messages.CarUpdated);
        }
    }
}
