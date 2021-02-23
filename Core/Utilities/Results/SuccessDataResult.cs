using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data, true, message) //butun veriler istenebilir
        {

        }
        public SuccessDataResult(T data) : base(data, true) // sadece data ve success bilgisi istenebilir
        {

        }
        public SuccessDataResult(string message) : base(default, true, message) //data istenmeyebilir(o halde data default verilir)
        {

        }
        public SuccessDataResult() : base(default, true) //sadece success bilgisi istenebilir
        {

        }
    }
}
