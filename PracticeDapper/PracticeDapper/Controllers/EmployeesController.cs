using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticeDapper;
using PracticeDapper.Contracts;
using PracticeDapper.Models;

namespace PracticeDapper.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly ICompanyRepository companyRepository;

        public EmployeesController(
            IEmployeeRepository employeeRepository,
            ICompanyRepository companyRepository)
        {
            this.employeeRepository = employeeRepository;
            this.companyRepository = companyRepository;
        }

        public IActionResult Index()
        {
            var employees = employeeRepository.GetAll();
            return View(employees);
        }

        public  IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = employeeRepository.GetById(id.Value);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(companyRepository.GetAll(), "CompanyId", "CompanyName");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("EmployeeId,Name,Age,CompanyId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeRepository.Add(employee);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(companyRepository.GetAll(), "CompanyId", "CompanyId");
            return View(employee);
        }

        // GET: Employees/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = employeeRepository.GetById(id.Value);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(companyRepository.GetAll(), "CompanyId", "CompanyId", employee.CompanyId);
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("EmployeeId,Name,Age,CompanyId")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    employeeRepository.Update(employee);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(employeeRepository.GetAll(), "CompanyId", "CompanyId", employee.CompanyId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = employeeRepository.GetById(id.Value);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = employeeRepository.GetById(id);
            employeeRepository.Delete(employee);
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return true;
        }
    }
}
