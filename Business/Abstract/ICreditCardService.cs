using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        Result Add(CreditCard creditCard);
        Result Delete(CreditCard creditCard);
        Result Update(CreditCard creditCard);
        IDataResult<CreditCard> GetByCustomerId(int customerId);

    }
}
