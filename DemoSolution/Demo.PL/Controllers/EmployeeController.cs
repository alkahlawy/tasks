using Demo.BLL.DTOs.Employees;
using Demo.BLL.Services.Departments;
using Demo.BLL.Services.Employees;
using Demo.DAL.Models.EmployeeModel;
using Demo.DAL.Models.Shared.Enums;
using Demo.PL.ViewModels.EmployeeViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class EmployeeController(
        IEmployeeService _employeeService,
        ILogger<HomeController> _logger,
        IWebHostEnvironment _environment
        ) : Controller
    {
        public IActionResult Index()
        {
            var employees = _employeeService.GetAll();
            return View(employees);
        }

        #region Create
        [HttpGet]
        public IActionResult Create(/*[FromServices] IDepartmentServices _departmentService*/)
        {
            //ViewData["Departments"] = _departmentService.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // To make sure the request is coming from the site only
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                { 
                    var createdEmployeeDto = new CreatedEmployeeDto
                    {
                        Name = employeeViewModel.Name,
                        Salary = employeeViewModel.Salary,
                        HiringDate = employeeViewModel.HiringDate,
                        Address = employeeViewModel.Address,
                        PhoneNumber = employeeViewModel.PhoneNumber,
                        Email = employeeViewModel.Email,
                        Age = employeeViewModel.Age,
                        IsActive = employeeViewModel.IsActive,
                        EmployeeType = employeeViewModel.EmployeeType,
                        Gender = employeeViewModel.Gender,
                        DepartmentId = employeeViewModel.DepartmentId
                    };
                    int insertResult = _employeeService.AddEmployee(createdEmployeeDto);
                    if (insertResult > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Failed to create employee. Please try again.");
                        // return the view model the view expects
                        return View(employeeViewModel);
                    }
                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                        return View(employeeViewModel);
                    }
                    else
                    {
                        _logger.LogError(ex.Message);
                        return View(employeeViewModel);
                    }
                }
            }
            else return View(employeeViewModel);
        }
        #endregion

        #region Details
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!(id.HasValue) || id <= 0) return BadRequest(); 
            var employee = _employeeService.GetById(id.Value);
            if (employee == null) return NotFound(); 
            return View(employee);
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!(id.HasValue) || id <= 0) return BadRequest(); 
            var employee = _employeeService.GetById(id.Value);
            if (employee == null) return NotFound(); 

            // Map EmployeeDetailsDto -> EmployeeViewModel for the Edit view
            var editViewModel = new EmployeeViewModel
            {
                Name = employee.Name,
                Salary = employee.Salary,
                HiringDate = employee.HiringDate,
                Address = employee.Address,
                PhoneNumber = employee.PhoneNumber,
                Email = employee.Email,
                Age = employee.Age ?? default,
                Gender = Enum.Parse<Gender>(employee.Gender),
                EmployeeType = Enum.Parse<EmployeeType>(employee.EmployeeType),
                IsActive = employee.IsActive,
                DepartmentId = employee.DepartmentId 
            };

            return View(editViewModel);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id , EmployeeViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);
            try
            {
                var updatedDTO = new UpdatedEmployeeDto
                {
                    Id = id,
                    Name = viewModel.Name,
                    Salary = viewModel.Salary,
                    HiringDate = viewModel.HiringDate,
                    Address = viewModel.Address,
                    PhoneNumber = viewModel.PhoneNumber,
                    Email = viewModel.Email,
                    Age = viewModel.Age,
                    Gender = viewModel.Gender,
                    EmployeeType = viewModel.EmployeeType,
                    IsActive = viewModel.IsActive,
                    DepartmentId = viewModel.DepartmentId
                };
                int updateResult = _employeeService.UpdateEmployee(updatedDTO);
                if (updateResult > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to update employee. Please try again.");
                    return View(viewModel);
                }
            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                    return View(viewModel);
                }
                else return View(viewModel);
            }
        }
        #endregion

        #region Delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest();
            try
            {
                bool isDeleted = _employeeService.DeleteEmployee(id);
                if (isDeleted) return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to delete employee. Please try again.");
                    return RedirectToAction(nameof(Delete), new { id });
                }
            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction("ErrorView", ex);
                }
            }
        }
        #endregion
    }
}
