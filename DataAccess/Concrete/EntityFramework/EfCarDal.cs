using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarsDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             select new CarDetailsDto
                             {
                                 Id =car.CarId,
                                 CarName = car.Description,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice                            
                             };

                return result.ToList();
            }
        }
        public List<CarDetailsDto> GetCarsDetailByColorId(int colorId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             where color.ColorId == colorId
                             select new CarDetailsDto
                             {
                                 Id = car.CarId,
                                 CarName = car.Description,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice
                             };

                return result.ToList();
            }
        }

        public List<CarDetailsDto> GetCarsDetailByBrandId(int brandId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             where brand.BrandId == brandId
                             select new CarDetailsDto
                             {
                                 Id = car.CarId,
                                 CarName = car.Description,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice
                             };

                return result.ToList();
            }
        }


        public CarDetailsDto GetCarDetailsById(int carId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             where car.CarId == carId
                             select new CarDetailsDto
                             {
                                 Id = car.CarId,
                                 CarName = car.Description,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice
                             };

                return result.SingleOrDefault();
            }
        }
    }
}
