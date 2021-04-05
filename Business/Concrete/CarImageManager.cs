using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Validation;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        [CacheRemoveAspect("ICarImageService.Get")]
        //[SecuredOperation("admin,carimage.add")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfMaxPhotoLimit(carImage.CarId));
            if (result !=null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }

        [CacheAspect]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        [CacheRemoveAspect("ICarImageService.Get")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfMaxPhotoLimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Update(carImage.ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<CarImage>> GetPhotosByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarPhotoIsNull(carId));
        }

        private IResult CheckIfMaxPhotoLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);

            if (result.Count<5)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
        private List<CarImage> CheckIfCarPhotoIsNull(int carId)
        {
            var defaultPath = @"C:\Users\tulin\source\repos\ReCapProject\WebAPI\CarImages\simge.jpg"; 
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (!result.Any())
            {
                return new List<CarImage> { new CarImage() { CarId = carId, Date = DateTime.Now, ImagePath = defaultPath } };
            }
            return result;
        }
    }
}
