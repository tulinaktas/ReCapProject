using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        ICreditCardService _creditCardService;
        public PaymentManager(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        public IResult Payment(CreditCard creditCard, decimal RentPrice)
        {
            var _creditCard = _creditCardService.GetByCustomerId(creditCard.CustomerId).Data;
            var amount = _creditCard.Amount;

            if(amount < RentPrice)
            {
                return new ErrorResult();
            }
            else
            {
                _creditCard.Amount = amount - RentPrice;
                _creditCardService.Update(_creditCard);
                return new SuccessResult();
            }
        }
    }
}
