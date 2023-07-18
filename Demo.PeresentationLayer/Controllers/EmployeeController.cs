using Demo.BusinessLogicLayer.Interfaces;
using Demo.DataAccessLayer.Entities;
using System;
using Microsoft.AspNetCore.Mvc;
using Demo.PeresentationLayer.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Demo.PeresentationLayer.Helpers;

namespace Demo.PeresentationLayer.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        ////Prorerty
        private readonly IMapper _mapper;



        ////constructor
        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        ////Actions


        ////Index
        public async Task<IActionResult> Index(string SearchValue)
        {
            var employee = Enumerable.Empty<Employee>();

            if (string.IsNullOrEmpty(SearchValue))
                employee = await _unitOfWork._EmployeeRepository.GetAll();
            else
                employee = _unitOfWork._EmployeeRepository.GetEmployeesByName(SearchValue);

            var MappedEmp = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employee);
            return View(MappedEmp);
        }



        ////Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel employeeVM)
        {
            if (ModelState.IsValid)
            {
               employeeVM.ImageName = DocumentSetting.UploadFile(employeeVM.Image, "images");

                var mappedEmployee = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                await _unitOfWork._EmployeeRepository.Add(mappedEmployee);
                TempData["Message"] = "Employee Created successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(employeeVM);
        }



        ////Details
        public async Task<IActionResult> Details(int? id, string ViewName = "Details")
        {
            if (id == null)
                return NotFound();
            var employee = await _unitOfWork._EmployeeRepository.Get(id.Value);
            if (employee == null)
                return NotFound();
            var MappedEmps = _mapper.Map<Employee, EmployeeViewModel>(employee);

            return View(ViewName, MappedEmps);
        }



        ////Edit
        public async Task<IActionResult> Edit(int? id)
        {
            return await Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id, EmployeeViewModel employeeVM)
        {
            if (id != employeeVM.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {

                try
                {
                    var mappedEmp = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                    await _unitOfWork._EmployeeRepository.Update(mappedEmp);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(employeeVM);
                }
            }
            return View(employeeVM);
        }



        ////Delete
        public async Task<IActionResult> Delete(int? id)
        {
            return await Details(id, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, EmployeeViewModel employeeVM)
        {
            if (id != employeeVM.Id)
                return BadRequest();
            try
            {
                var mappedEmp = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);

                await _unitOfWork._EmployeeRepository.Delete(mappedEmp);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(employeeVM);
            }

        }





    }
}
