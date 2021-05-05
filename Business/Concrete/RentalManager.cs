using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [SecuredOperation("admin,rental.add")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(RentControl(rental.RentDate, rental.ReturnDate), RentedCarBeenReturned(rental.CarId,rental.RentDate,rental.ReturnDate));

            if (result != null)
            {
                return result;
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.RentalListed);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IDataResult<List<RentalDetailsDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailsDto>>(_rentalDal.GetRentalDetails());
        }

        private IResult RentControl(DateTime rentDate, DateTime? returnDate)
        {
            var result = _rentalDal.GetAll(r => r.RentDate == rentDate && r.ReturnDate == returnDate).Any();
            if (result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IResult RentedCarBeenReturned(int carId, DateTime rentDate, DateTime? returnDate)
        {
            var rentedCar = _rentalDal.GetAll(r => r.CarId == carId).Any();
            if (rentedCar)
            {
                var rentedCars = _rentalDal.GetAll(r => r.CarId == carId);
                foreach (var car in rentedCars)
                {
                    int rangeReturnToRent = DateTime.Compare((DateTime)car.ReturnDate, rentDate);
                    int rangeRentToReturn = DateTime.Compare(car.RentDate, (DateTime)returnDate);

                    if (car.ReturnDate == null || rangeReturnToRent > 0 || rangeRentToReturn > 0)
                    {
                        return new ErrorResult(Messages.InvalidRental);
                    }
                }
                // <0 result.ReturnDate daha önce rentDateden
            }
            return new SuccessResult();
        }
    }
}
