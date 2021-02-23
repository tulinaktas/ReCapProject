using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data,false,message) //butun veriler istenebilir
        {

        }
        public ErrorDataResult(T data) : base(data, false) // sadece data ve error bilgisi istenebilir
        {

        }
        public ErrorDataResult(string message) : base(default,false,message) //data istenmeyebilir(o halde data default verilir)
        {

        }
        public ErrorDataResult() :base(default,false) //sadece error bilgisi istenebilir
        {

        }
    }
}
