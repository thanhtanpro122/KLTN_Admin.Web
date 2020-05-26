using KLTN_Admin.ServiceInterfaces;
using KLTN_Admin.SharedModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLTN_Admin.Services
{
    public class ConstService: ServiceBase, IConstService
    {
        public ConstService() : base()
        {

        }

        public bool CreateConst(ConstSharedModel const_item)
        {
            var request = new RestRequest("/const", Method.POST, DataFormat.Json);
            request.AddJsonBody(const_item);
            var response = _client.Execute(request);
            var statusCode = (int)response.StatusCode;
            if (statusCode != 200)
            {
                return false;
            }
            return true;
        }

        public bool DeleteConst(string constId)
        {
            var request = new RestRequest("/const/{const_id}", Method.DELETE);
            request.AddUrlSegment("const_id", constId);
            var response = _client.Execute(request);
            var statusCode = (int)response.StatusCode;
            if (statusCode != 200)
            {
                return false;
            }
            return true;
        }

        public bool EditConst(ConstSharedModel const_item)
        {
            var request = new RestRequest("/const/{const_id}", Method.PATCH, DataFormat.Json);
            request.AddJsonBody(const_item);
            request.AddUrlSegment("const_id", const_item.Id);
            var response = _client.Execute(request);
            var statusCode = response.StatusCode;
            if ((int)statusCode != 200)
            {
                return false;
            }
            return true;
        }

        public ConstSharedModel GetConstById(string constId)
        {
            var request = new RestRequest("/const/{const_id}", Method.GET);
            request.AddUrlSegment("const_id", constId);
            var response = _client.Execute(request);
            var statusCode = (int)response.StatusCode;
            if (statusCode != 200)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<ConstSharedModel>(response.Content);
        }

        public List<ConstSharedModel> GetListConst()
        {
            var request = new RestRequest("/const", Method.GET);
            return _client.Execute<List<ConstSharedModel>>(request).Data;
        }
    }
}
