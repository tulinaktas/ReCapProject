using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
        List<Car> GetAll();
        Car GetById(int id); //idye gore arac getirme
        List<Car> GetCarsByBrandId(int brandId); //brandIdye gore aracları getirme
        List<Car> GetCarsByColorId(int colorId); //colorIdye gore aracları getirme
        List<CarDetailsDto> GetCarsDetails();
    }
}
