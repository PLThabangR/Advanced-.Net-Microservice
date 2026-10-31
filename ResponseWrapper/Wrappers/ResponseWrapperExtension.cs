using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ResponseWrapper.Wrappers
{
    //We will use it to read any response coming to our service
    //We do want to always dezirialize everytime we will use this
    public static class ResponseWrapperExtension
    {
        //We need to deserialize to know what type of object we dealing with
        public static async Task<ResponseWrapper<T>> ToResponse<T>(this HttpResponseMessage responseMessage)
        {
            var responseAsString = await responseMessage.Content.ReadAsStringAsync();
            //Now we ae deserializing
            var responseObject =  JsonSerializer.Deserialize<ResponseWrapper<T>>(responseAsString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve
            });

            return responseObject;


        }

    }
}
