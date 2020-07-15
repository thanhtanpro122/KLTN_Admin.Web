using KLTN_Admin.SharedModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLTN_Admin.ServiceInterfaces
{
    public interface IAgentService
    {
        List<AgentSharedModel> GetAllAgent(string adminId);

        List<AgentSharedModel> GetAgentsByAdminRoot(string adminId);

        AgentSharedModel GetAgentById(string agentId);

        AgentSharedModel CreateAgent(AgentSharedModel agent);

        bool EditAgent(AgentSharedModel agent);

        bool DeleteAgent(string agentId);

        AddtionalAgentShardeModel GetAddtionlAgentData();

        bool AddAgentDetail(AgentAddSharedModel data);
    }
}
