﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KLTN_Admin.ServiceInterfaces;
using KLTN_Admin.SharedModels;
using KLTN_Admin.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace KLTN_Admin.Web.Controllers
{
    public class ConstController : BaseController
    {
        private readonly IConstService _constService;

        public ConstController(IConstService constService, IMapper mapper) : base(mapper)
        {
            _constService = constService;
        }
        public IActionResult Index(string searchString, int? page)
        {
            var model = _mapper.Map<List<ConstViewModel>>(_constService.GetListConst());
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(model.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public IActionResult Create(ConstViewModel model)
        {
            var check = _constService.CreateConst(_mapper.Map<ConstSharedModel>(model));
            if (!check)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(string id)
        {
            var CheckDelete = _constService.DeleteConst(id);
            if (!CheckDelete)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }

    }
}