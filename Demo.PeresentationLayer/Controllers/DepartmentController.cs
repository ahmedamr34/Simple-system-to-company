using Demo.BusinessLogicLayer.Interfaces;
using Demo.BusinessLogicLayer.Repositries;
using Demo.DataAccessLayer.Entities;
using System;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Collections;
using Demo.PeresentationLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Demo.PeresentationLayer.Controllers
{
    [Authorize]

    public class DepartmentController : Controller
    {


        //Prorerties
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;


        //constructor
        public DepartmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        ////Actions


        ////Index
        public async Task<IActionResult> Index()
        {
            var dept =await _unitOfWork._DepartmentRepository.GetAll();
            var MappedDepartment =  _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentViewModel>>(dept);
            return View(MappedDepartment);
        }



        ////Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentViewModel departmentVM)
        {
            if (ModelState.IsValid)
            {
                var MappedDepartment = _mapper.Map<DepartmentViewModel, Department>(departmentVM);
              await  _unitOfWork._DepartmentRepository.Add(MappedDepartment);
                return RedirectToAction(nameof(Index));
            }
            return View(departmentVM);
        }



        ////Details
        public async Task<IActionResult> Details(int? id, string ViewName = "Details")
        {
            if (id == null)
                return NotFound();

            var department =await _unitOfWork._DepartmentRepository.Get(id.Value);
            if (department == null)
                return NotFound();

            var MappedDepartment = _mapper.Map<Department, DepartmentViewModel>(department);
            return View(ViewName, MappedDepartment);
        }



        ////Edit 
        public async Task<IActionResult> Edit(int? id)
        {
            return await Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int? id, DepartmentViewModel departmentVM)
        {
            if (id != departmentVM.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    var MappedDepartment = _mapper.Map<DepartmentViewModel, Department>(departmentVM);
                   await _unitOfWork._DepartmentRepository.Update(MappedDepartment);
                    return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(departmentVM);
                }
            }
            return View(departmentVM);
        }



        ////Delete
        public async Task<IActionResult> Delete(int? id)
        {
            return await Details(id, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, DepartmentViewModel departmentVM)
        {
            if (id != departmentVM.Id)
                return BadRequest();
            try
            {
                var MappedDepartment = _mapper.Map<DepartmentViewModel, Department>(departmentVM);

                await _unitOfWork._DepartmentRepository.Delete(MappedDepartment);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(departmentVM);
            }
        }
    }
}
