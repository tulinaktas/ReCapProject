using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal(),new EfBrandDal());

            List<Car> cars = carManager.GetAll();
            foreach (var car in cars)
            {
               Console.WriteLine(car.Description);
            }

            List<Car> sameBrandCars = carManager.GetCarsByBrandId(8);
            foreach (var car in sameBrandCars)
            {
                Console.WriteLine(car.Description);
            }

            carManager.Add(new Car() // hata veriyor
            {
               BrandId = 1, ColorId = 9, DailyPrice= 0, Description ="BMW marka gri araba", ModelYear = "2013"
            });


            //InMemorydeCalisma();
            //AddTest(carManager, car1);
            //DeleteTest(carManager, car1);
            //UpdateTest(carManager);
            ////GetByIdTest(carManager);
        }

        private static void InMemorydeCalisma()
        {
            
            Car car1 = new Car()
            {
                CarId = 7,
                BrandId = 3,
                ColorId = 4,
                DailyPrice = 300000,
                Description = "Volkswagen Araba",
                ModelYear = "2018"
            };
        }

        private static void UpdateTest(CarManager carManager)
        {
            carManager.Update(new Car() { CarId = 7, BrandId = 4, ColorId = 4, DailyPrice = 350000, Description = "Volkswagen Araba(modifiye)", ModelYear = "2018" });

            var c = carManager.GetAll();
            foreach (var car in c)
            {
                Console.WriteLine(car.Description);
            }
        }

        private static void GetByIdTest(CarManager carManager)
        {
            var car = carManager.GetById(2);
            Console.WriteLine(car.Description);
        }

        private static void DeleteTest(CarManager carManager, Car car1)
        {
            carManager.Delete(car1);
            List<Car> c = carManager.GetAll();
            foreach (var car in c)
            {
                Console.WriteLine(car.Description);
            }
        }

        private static void AddTest(CarManager carManager, Car car1)
        {
            carManager.Add(car1);
            List<Car> cars = carManager.GetAll();
            foreach (var car in cars)
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
