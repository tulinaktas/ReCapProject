using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public void Add(Car car)
        {
            //iş kuralları -- business
            //araba ismi min 2 harf ve gunluk fiyatı 0dan buyuk olmalı
            if (car.DailyPrice > 0 && car.Description.Length>=2)
            {
                _carDal.Add(car);
            }
            else
            {
                throw new Exception("The daily price cannot be zero");
            }

        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _carDal.Get(c=>c.CarId == id);
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(b => b.BrandId ==brandId);//brandIdsi gonderilen idye eşit olan araclar
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);//colorIdsi gonderilen idye eşit olan araclar
        }

        public List<CarDetailsDto> GetCarsDetails() //dto olarak olusturdugumuz joinden arabanın marka adı ve renk adı da gelecek.
        {
            return _carDal.GetCarsDetails();
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
