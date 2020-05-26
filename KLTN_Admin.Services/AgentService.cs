using KLTN_Admin.ServiceInterfaces;
using KLTN_Admin.SharedModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace KLTN_Admin.Services
{
    public class AgentService : ServiceBase, IAgentService
    {
        public AgentService() : base()
        {

        }

        public AgentSharedModel CreateAgent(AgentSharedModel agent)
        {
            var request = new RestRequest("/agent", Method.POST, DataFormat.Json);
            request.AddJsonBody(agent);
            var response = _client.Execute(request);
            var statusCode = (int)response.StatusCode;
            if (statusCode != 200)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<AgentSharedModel>(response.Content);
        }

        public bool DeleteAgent(string agentId)
        {
            throw new NotImplementedException();
        }

        public bool EditAgent(AgentSharedModel agent)
        {
            var request = new RestRequest("/agent/{agent_id}", Method.PATCH, DataFormat.Json);
            request.AddJsonBody(agent);
            request.AddUrlSegment("agent_id", agent.Id);
            var response = _client.Execute(request);
            var statusCode = response.StatusCode;
            if ((int)statusCode != 200)
            {
                return false;
            }
            return true;
        }

        public AddtionalAgentShardeModel GetAddtionlAgentData()
        {
            var request = new RestRequest("/agent/addAgentData", Method.GET);
            var response = _client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<AddtionalAgentShardeModel>(response.Content);
            }

            return null;
        }

        public AgentSharedModel GetAgentById(string agentId)
        {
            var request = new RestRequest("/agent/{agent_id}", Method.GET);
            request.AddUrlSegment("agent_id", agentId);
            var response = _client.Execute(request);
            var statusCode = (int)response.StatusCode;
            if (statusCode != 200)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<AgentSharedModel>(response.Content);
        }

        public List<AgentSharedModel> GetAllAgent()
        {
            var request = new RestRequest("/agent", Method.GET);
            return _client.Execute<List<AgentSharedModel>>(request).Data;
        }
    }
}
