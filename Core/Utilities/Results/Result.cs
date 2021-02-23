using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //ctor icinde getterları set edebiliyoruz!
        public Result(bool success, string message) : this(success) // success'i diger ctora yolladık
        {
            Message = message;
        }
        //method overloading
        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }

        public string Message { get; }
    }
}
