using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System;
using System.Collections.Generic;
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
    }
}
