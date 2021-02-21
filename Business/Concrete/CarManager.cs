using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandDal _brandDal;
        
        public CarManager(ICarDal carDal, IBrandDal brandDal)
        {
            _carDal = carDal;
            _brandDal = brandDal; //arabanın ismini ogrenmek icin db brand baglantısını kullanacagız
        }
        public void Add(Car car)
        {
            var carBrandName = _brandDal.Get(p => p.BrandId == car.BrandId).BrandName; // araba ismini bulduk
            
            //iş kuralları -- business
            //araba ismi min 2 harf ve gunluk fiyatı 0dan buyuk olmalı
            if (car.DailyPrice > 0 && carBrandName.Length>=2)
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
            return _carDal.Get(p=>p.CarId == id);
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(p => p.BrandId ==brandId);//brandIdsi gonderilen idye eşit olan araclar
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(p => p.ColorId == colorId);//colorIdsi gonderilen idye eşit olan araclar
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
