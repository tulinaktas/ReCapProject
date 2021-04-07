using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id); //idye gore arac getirme
        IDataResult<List<Car>> GetCarsByBrandId(int brandId); //brandIdye gore aracları getirme
        IDataResult<List<Car>> GetCarsByColorId(int colorId); //colorIdye gore aracları getirme
        IDataResult<List<CarDetailsDto>> GetCarsDetails();
        IDataResult<List<CarDetailsDto>> GetCarsDetailByBrandId(int brandId);
        IDataResult<List<CarDetailsDto>> GetCarsDetailByColorId(int colorId);
        IDataResult<CarDetailsDto> GetCarDetailsById(int carId);
        IDataResult<List<CarDetailsDto>> GetCarsDetailByColorIdAndBrandId(int colorId, int brandId);
    }
}
