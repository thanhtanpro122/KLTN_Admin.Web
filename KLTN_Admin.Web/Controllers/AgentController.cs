﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KLTN_Admin.ServiceInterfaces;
using KLTN_Admin.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace KLTN_Admin.Web.Controllers
{
    public class AgentController : BaseController
    {
        private readonly IAgentService _agentService;

        public AgentController(IAgentService agentService, IMapper mapper) : base(mapper)
        {
            _agentService = agentService;
        }
        public IActionResult Index(string searchString, int? page)
        {
            var model = _mapper.Map<List<AgentViewModel>>(_agentService.GetAllAgent());
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(model.ToPagedList(pageNumber, pageSize));
        }
    }
}