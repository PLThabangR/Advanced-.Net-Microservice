
namespace ResponseWrapper.Wrappers
{
    public interface IResponseWrapper
    {
        //Store feedback to the consumer
        public List<string> Messages { get; set; }
        //
        public bool IsSuccessful { get; set; }
    }    
        //out put of type T this is generic specific type or object
        public interface IResponseWrapper<out T>: IResponseWrapper
    { 
        public T Data { get; }


    }
}
