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
        //With T Data fail
        public static ResponseWrapper<T> Fail(T data)
        {
            return new ResponseWrapper<T>() { Data=data,IsSuccessful = false };
        }

        public  static ResponseWrapper<T> Fail(T data,string message)
        {
            return new ResponseWrapper<T>() {Data=data,IsSuccessful = false, Messages = [message] };
        }

        public  static ResponseWrapper<T> Fail(T data,List<string> messages)
        {
            return new ResponseWrapper<T>() { Data=data, IsSuccessful = false, Messages = messages };
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

        //With T data as response 
        public  static ResponseWrapper<T> Success(T data)
        {
            return new ResponseWrapper<T>() {Data=data, IsSuccessful = true };
        }

        public static ResponseWrapper<T> Success(T data,string messages)
        {
            return new ResponseWrapper<T>() { Data = data, IsSuccessful = true, Messages = [messages] };
        }

        public static ResponseWrapper<T> Success(T data, List<string> messages)
        {
            return new ResponseWrapper<T>() { Data = data, IsSuccessful = true, Messages = messages };
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
        //Asycronous with Type Data in the response
        public  static Task<ResponseWrapper<T>> FailAsync(T data)
        {
            return Task.FromResult(Fail(data));
        }

        public static Task<ResponseWrapper<T>> FailAsync(T data,string message)
        {
            return Task.FromResult(Fail(data,message));
        }

        public static Task<ResponseWrapper<T>> FailAsync(T data,List< string> message)
        {
            return Task.FromResult(Fail(data, message));
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
        public new static Task<ResponseWrapper<T>> SuccessAsync(List<string> messages)
        {
            return Task.FromResult(Fail(messages));
        }

        //Succes with data of type  T
        public static Task<ResponseWrapper<T>> SuccessAsync(T data, string message)
        {
            return Task.FromResult(Success(data, message));
        }
        public static Task<ResponseWrapper<T>> SuccessAsync(T data)
        {
            return Task.FromResult(Success(data));
        }

        public static Task<ResponseWrapper<T>> SuccessAsync(T data, List<string> message)
        {
            return Task.FromResult(Success(data, message));
        }





    }
}