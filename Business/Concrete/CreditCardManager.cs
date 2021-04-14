using Business.Abstract;
using Business.Constant;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CreditCardManager:ICreditCardService
    {
        ICreditCardDal _creditCardDal;
        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public IResult Add(CreditCard creditCard)
        {
            var result = BusinessRules.Run(CheckCreditCardExist(creditCard));
            if (result != null)
            {
                return result;
            }

            creditCard.Amount = 1000;
           _creditCardDal.Add(creditCard);
            return new SuccessResult(Messages.CreditCardAdded);
        }

        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult(Messages.CreditCarDeleted);
        }

        public IDataResult<CreditCard> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<CreditCard>(_creditCardDal.Get(c => c.CustomerId == customerId));
        }

        private IResult CheckCreditCardExist(CreditCard creditCard)
        {
            var result = _creditCardDal.Get(
            c => c.CardNumber == creditCard.CardNumber && 
            c.CVV == creditCard.CVV && 
            c.ExpirationDate == creditCard.ExpirationDate && 
            c.FullName == creditCard.FullName);

            if (result == null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult(Messages.CreditCardUpdated);
        }
    }
}
