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

        public IResult Payment(CreditCard creditCard)
        {
            var _creditCard = _creditCardService.GetByNumber(creditCard.CardNumber).Data;
            var amount = _creditCard.Amount;

            if(amount < creditCard.Amount)
            {
                return new ErrorResult();
            }
            else
            {
                _creditCard.Amount = amount - creditCard.Amount;
                _creditCardService.Update(_creditCard);
                return new SuccessResult();
            }
        }
    }
}
