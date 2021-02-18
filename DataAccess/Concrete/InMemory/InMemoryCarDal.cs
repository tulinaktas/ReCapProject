using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
                new Car(){Id = 1, BrandId =1, ColorId = 1, DailyPrice = 590000, Description = "AUDI Araba", ModelYear="2017" },
                new Car(){Id = 2, BrandId =1, ColorId = 2, DailyPrice = 150000, Description = "AUDI Araba", ModelYear="2004" },
                new Car(){Id = 3, BrandId =1, ColorId = 1, DailyPrice = 100000, Description = "AUDI Araba", ModelYear="2001" },
                new Car(){Id = 4, BrandId =2, ColorId = 3, DailyPrice = 125000, Description = "Ford Araba", ModelYear="2014" },
                new Car(){Id = 5, BrandId =2, ColorId = 4, DailyPrice = 250000, Description = "Ford Araba", ModelYear="2018" },
                new Car(){Id = 6, BrandId =3, ColorId = 3, DailyPrice = 102000, Description = "Volkswagen Araba", ModelYear="2009" }
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = null;
            var result =_cars.SingleOrDefault(c => car.Id == c.Id);
            carToDelete = result;
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);
            //return (Car)_cars.Where(c => c.Id == id);
        }

        public void Update(Car car)
        {
            Car carToUpdate = null;
            var result = _cars.SingleOrDefault(c => car.Id == c.Id);
            carToUpdate = result;

            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;

        }
    }
}
