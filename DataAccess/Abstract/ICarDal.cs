using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailsDto> GetCarsDetailByBrandId(int brandId);
        List<CarDetailsDto> GetCarsDetailByColorId(int colorId);
        List<CarDetailsDto> GetCarsDetails();
        CarDetailsDto GetCarDetailsById(int carId);
        List<CarDetailsDto> GetCarsDetailByColorIdAndBrandId(int colorId, int brandId);
    }
}
