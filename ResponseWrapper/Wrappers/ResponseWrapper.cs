using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponseWrapper.Wrappers
{
    public class ResponseWrapper : IResponseWrapper
    {
        //Implement methods from interface
        public List<string> Messages { get; set; } = [];
       public  bool IsSuccessful { get; set; }
        
        //Synchronous non generic response wrappers
        public static IResponseWrapper  Fail()
        {
            return new ResponseWrapper(){IsSuccessful =false };

        }

         public static IResponseWrapper  Fail(string message)
        {
            return new ResponseWrapper(){IsSuccessful =false,Messages=[message] };

        }

        public static IResponseWrapper Fail(List<string> messages)
        {
            return new ResponseWrapper() { IsSuccessful = false, Messages = messages };

        }


        //asynchronous response wrapper
        public  static Task<IResponseWrapper> FailAsync()
        {   //We are reusing logic
            return Task.FromResult(Fail());

        }

        public static Task<IResponseWrapper> FailAsync(string message)
        {
            return Task.FromResult(Fail(message));

        }

        public static Task<IResponseWrapper> FailAsync(List<string> messages)
        {
            return Task.FromResult(Fail(messages));

        }

        //Synchronous response wrappers
        public static IResponseWrapper Success()
        {
            return new ResponseWrapper() { IsSuccessful = true };

        }

        public static IResponseWrapper Success(string message)
        {
            return new ResponseWrapper() { IsSuccessful = true, Messages = [message] };

        }

        public static IResponseWrapper Success(List<string> messages)
        {
            return new ResponseWrapper() { IsSuccessful = true, Messages = messages };

        }

        //Asynchronous response wrappers
        public static Task<IResponseWrapper> SuccessAsync()
        {
            return Task.FromResult(Success());

        }

        public static Task<IResponseWrapper> SuccessAsync(string message)
        {
            return Task.FromResult(Success(message));

        }

        public static Task<IResponseWrapper> SuccessAsync(List<string> messages)
        {
            return Task.FromResult(Success(messages));

        }
 }

    
    //we inherit from the non generic class and also implement the IResponseWrapper<T>
    public class ResponseWrapper<T> : ResponseWrapper, IResponseWrapper<T>
    {
        public T Data { get;set; }
            
        //Default constructor
        public ResponseWrapper() { }

        //Generic Synchronous response wrappers fro fail

        //We are overriding the above methods 
        public new static ResponseWrapper<T> Fail()
        {   
            return new ResponseWrapper<T>() { IsSuccessful = false };
        }
        public new static ResponseWrapper<T> Fail(string message)
        {
            return new ResponseWrapper<T>() { IsSuccessful = false,Messages= [message] };
        }
        public new static ResponseWrapper<T> Fail(List<string>messages)
        {
            return new ResponseWrapper<T>() { IsSuccessful = false ,Messages =messages };
        }

        //Synchronous for success
        public new static ResponseWrapper<T>Success()
        {
            return new ResponseWrapper<T>() { IsSuccessful = true };
        }
        public new static ResponseWrapper<T> Success(string messages)
        {
            return new ResponseWrapper<T>() { IsSuccessful = true, Messages = [messages] };
        }
        public new static ResponseWrapper<T> Success(List<string> messages)
        {
            return new ResponseWrapper<T>() { IsSuccessful = true, Messages = messages };
        }


        //Asyncrounous generic response for fail
        public new static Task<ResponseWrapper<T>> FailAsync()
        {
            return Task.FromResult(Fail());
        }
        public new static Task<ResponseWrapper<T>> FailAsync(string message)
        {
            return Task.FromResult(Fail(message));
        }
        public new static Task<ResponseWrapper<T>> FailAsync(List<string> messages)
        {
            return Task.FromResult(Fail(messages));
        }

        //Asyncronous generic for success
        public new static Task<ResponseWrapper<T>> SuccessAsync()
        {
            return Task.FromResult(Success());
        }

        public new static Task<ResponseWrapper<T>> SuccessAsync(string message)
        {
            return Task.FromResult(Success(message));
        }
        public new static Task<ResponseWrapper<T>> SuccesAsync(List<string> messages)
        {
            return Task.FromResult(Fail(messages));
        }



    }
}