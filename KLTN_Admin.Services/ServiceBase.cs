using KLTN_Admin.Common.Consts;
using KLTN_Admin.SharedModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace KLTN_Admin.Services
{
    public abstract class ServiceBase
    {
        protected RestClient _client;

        public ServiceBase()
        {
            _client = new RestClient("http://localhost:3000");
            _client.UseNewtonsoftJson(new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DefaultValueHandling = DefaultValueHandling.Include,
                TypeNameHandling = TypeNameHandling.None,
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.None,
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
            });
        }

        protected TData ExecuteRequest<TData>(RestRequest request) where TData : class, new()
        {
            var response = _client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseResult = JsonConvert.DeserializeObject<ResponseResult<TData>>(response.Content);
                if (responseResult != null)
                {
                    if (responseResult.State == Consts.ResponseState.Successfull)
                    {
                        return responseResult.Data;
                    }
                    else if (responseResult.StatusCode == 404)
                    {
                        return null;
                    }
                }

                throw new Exception($"Message: {responseResult.Message}, status code: {responseResult.StatusCode}, state: {responseResult.State}");
            }

            throw new Exception($"Execute request failed, status code: {response.StatusDescription}");
        }
    }
}
