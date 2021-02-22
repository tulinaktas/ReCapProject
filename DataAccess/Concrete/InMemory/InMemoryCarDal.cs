using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        //datalari aliyoruz
        //simülasyon
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car(){CarId = 1, BrandId =1, ColorId = 1, DailyPrice = 590000, Description = "AUDI Araba", ModelYear="2017" },
                new Car(){CarId = 2, BrandId =1, ColorId = 2, DailyPrice = 150000, Description = "AUDI Araba", ModelYear="2004" },
                new Car(){CarId = 3, BrandId =1, ColorId = 1, DailyPrice = 100000, Description = "AUDI Araba", ModelYear="2001" },
                new Car(){CarId = 4, BrandId =2, ColorId = 3, DailyPrice = 125000, Description = "Ford Araba", ModelYear="2014" },
                new Car(){CarId = 5, BrandId =2, ColorId = 4, DailyPrice = 250000, Description = "Ford Araba", ModelYear="2018" },
                new Car(){CarId = 6, BrandId =3, ColorId = 3, DailyPrice = 102000, Description = "Volkswagen Araba", ModelYear="2009" }
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = null;
            var result =_cars.SingleOrDefault(c => car.CarId == c.CarId);
            carToDelete = result;
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.CarId == id);
            //return (Car)_cars.Where(c => c.Id == id);
        }

        public List<CarDetailsDto> GetCarsDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = null;
            var result = _cars.SingleOrDefault(c => car.CarId == c.CarId);
            carToUpdate = result;

            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;

        }
    }
}
