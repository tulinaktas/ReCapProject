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
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            UserManager userManager = new UserManager(new EFUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

         

            //RentalAddTest(rentalManager); --> daha sonra iyileştireceğim
            //UserAddTest(userManager);
            //CustomerAddTest(customerManager);




            //CarCrudTest(carManager);
            //ColorCrudTest(colorManager);
            //BrandCrudTest(brandManager);
            //CarDetailsTest(carManager);

            //Test(carManager);
            //InMemorydeCalisma();
            //AddTest(carManager, car1);
            //DeleteTest(carManager, car1);
            //UpdateTest(carManager);
            ////GetByIdTest(carManager);
        }

        private static void RentalAddTest(RentalManager rentalManager)
        {
            var result = rentalManager.Add(new Rental()
            {
                CarId = 10,
                CustomerId = 1,
                RentDate = DateTime.Now,
                ReturnDate = new DateTime(2021, 2, 26)
            });
            Console.WriteLine(result.Message);
        }

        private static void CustomerAddTest(CustomerManager customerManager)
        {
            customerManager.Add(new Customer()
            {
                CompanyName = "TulinsCompany",
                UserId = 1
            });
            customerManager.Add(new Customer()
            {
                CompanyName = "TugcesCompany",
                UserId = 2
            });
        }

        private static void CarDetailsTest(CarManager carManager)
        {
            foreach (var car in carManager.GetCarsDetails().Data)
            {
                Console.WriteLine("{0}/{1}/{2}/{3}", car.BrandName, car.ColorName, car.CarName, car.DailyPrice);
            }
        }

        private static void UserAddTest(UserManager userManager)
        {
            userManager.Add(new User()
            {
                FirstName = "Tuğçe",
                LastName = "Aktaş",
                Email = "tugceaktas@hotmail.com",
                Password = "1234567"
            });
        }

        private static void BrandCrudTest(BrandManager brandManager)
        {
            Brand brand1 = new Brand() { BrandName = "deneme" };

            brandManager.Add(brand1);
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
            brandManager.Update(new Brand() { BrandId = 1002, BrandName = "deneme degisti" });
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
            brandManager.Delete(new Brand() { BrandId = 1002 });
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void ColorCrudTest(ColorManager colorManager)
        {
            Console.WriteLine(colorManager.GetById(5));
            Color color1 = new Color()
            {
                ColorName = "Dark Green"
            };
            Console.WriteLine("Renk ekleme");
            colorManager.Add(color1);
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
            Console.WriteLine("Renk guncelleme islemi");
            colorManager.Update(new Color { ColorId = 1002, ColorName = "deneme" });
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
            Console.WriteLine("Renk silme islemi");
            colorManager.Delete(new Color { ColorId = 1002 });
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void CarCrudTest(CarManager carManager)
        {
            Console.WriteLine(carManager.GetById(6).Data.Description);

            Car car1 = new Car()
            {
                BrandId = 3,
                ColorId = 9,
                DailyPrice = 120,
                Description = "Fiat marka gri araba",
                ModelYear = "2021"
            };
            Console.WriteLine("Araba ekleme islemi");
            carManager.Add(car1);
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("Araba guncelleme islemi");
            carManager.Update(new Car { CarId = 16, BrandId = 2, ColorId = 1, DailyPrice = 130, Description = "deneme", ModelYear = "2016" });
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("Araba silme islemi");
            carManager.Delete(new Car { CarId = 16 });
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Description);
            }
        }

        private static void Test(CarManager carManager)
        {
            List<Car> cars = carManager.GetAll().Data;
            foreach (var car in cars)
            {
                Console.WriteLine(car.Description);
            }

            List<Car> sameBrandCars = carManager.GetCarsByBrandId(8).Data;
            foreach (var car in sameBrandCars)
            {
                Console.WriteLine(car.Description);
            }

            carManager.Add(new Car() // hata veriyor
            {
                BrandId = 1,
                ColorId = 9,
                DailyPrice = 0,
                Description = "BMW marka gri araba",
                ModelYear = "2013"
            });
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

            var c = carManager.GetAll().Data;
            foreach (var car in c)
            {
                Console.WriteLine(car.Description);
            }
        }

        private static void GetByIdTest(CarManager carManager)
        {
            var car = carManager.GetById(2);
            Console.WriteLine(car.Data.Description);
        }

        private static void DeleteTest(CarManager carManager, Car car1)
        {
            carManager.Delete(car1);
            List<Car> c = carManager.GetAll().Data;
            foreach (var car in c)
            {
                Console.WriteLine(car.Description);
            }
        }

        private static void AddTest(CarManager carManager, Car car1)
        {
            carManager.Add(car1);
            List<Car> cars = carManager.GetAll().Data;
            foreach (var car in cars)
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
