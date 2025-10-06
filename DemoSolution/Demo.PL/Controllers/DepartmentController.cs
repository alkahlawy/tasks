using Demo.BLL.DTOs.Departments;
using Demo.BLL.Services.Departments;
using Demo.PL.ViewModels.DepartmentViewModel;
using Microsoft.AspNetCore.Mvc;
namespace Demo.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentServices _departmentServices;
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _environment;

        public DepartmentController(IDepartmentServices _departmentServices,
                                    ILogger<HomeController> _logger,
                                    IWebHostEnvironment _environment)
        {
            this._departmentServices = _departmentServices;
            this._logger = _logger;
            this._environment = _environment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentServices.GetAll();
            return View(departments);
        }

        #region Create
        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(CreatedDepartmentDTO createdDepartmentDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int insertResult = _departmentServices.AddDepartment(createdDepartmentDTO);
                    if (insertResult > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Failed to create department. Please try again.");
                        return View(createdDepartmentDTO);
                    }
                }
                catch (Exception ex)
                {
                    // Log Exception
                    if (_environment.IsDevelopment())
                    {
                        // 1) In Development Environment, log Errors in the console and return the same view with the error message
                        ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                        return View(createdDepartmentDTO);
                    }
                    else
                    {
                        // 2) In Production Environment, log Errors in a file | table and return a the same view with error message
                        // _logger.LogError(ex.Message);
                        return View(createdDepartmentDTO);
                    }
                }
            }
            else return View(createdDepartmentDTO);
        }
        #endregion

        #region Details
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!(id.HasValue) || id <= 0)
                return BadRequest(); // 400
            var department = _departmentServices.GetById(id.Value);
            if (department == null)
                return NotFound(); // 404
            return View(department);
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            // At the first we map from Department Details DTO to Updated Department DTO
            //if (!(id.HasValue) || id <= 0) return BadRequest(); // 400
            //var department = _departmentServices.GetById(id.Value); // returns => Department Details DTO
            //if (department == null) return NotFound(); // 404
            //return View(department);  // view here needs Updated Department DTO

            // So for the best practice we create a new ViewModel called DepartmentEditViewModel
            // then we map from Department Details DTO to DepartmentEditViewModel
            if (!(id.HasValue) || id <= 0) return BadRequest(); // 400
            var department = _departmentServices.GetById(id.Value); // returns => Department Details DTO
            if (department == null) return NotFound(); // 404
            var editViewModel = new DepartmentEditViewModel
            {
                Code = department.Code,
                Name = department.Name,
                CreatedAt = department.DateOfCreation,
                Description = department.Description
            };
            return View(editViewModel); // Maps Details DTO to Edit ViewModel
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id /* id here from the route values only */,
                                  DepartmentEditViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);
            try
            {
                var updatedDTO = new UpdatedDepartmentDTO
                {
                    Id = id,
                    Code = viewModel.Code,
                    Name = viewModel.Name,
                    CreatedAt = viewModel.CreatedAt,
                    Description = viewModel.Description
                };
                int updateResult = _departmentServices.UpdateDepartment(updatedDTO);
                if (updateResult > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to update department. Please try again.");
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
        //[HttpGet]
        //public IActionResult Delete(int? id)
        //{
        //    if (!(id.HasValue) || id <= 0) return BadRequest();
        //    var department = _departmentServices.GetById(id.Value);
        //    if (department == null) return NotFound();
        //    return View(department);
        //}

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id < 10) return BadRequest();
            try
            {
                bool isDeleted = _departmentServices.DeleteDepartment(id);
                if (isDeleted) return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to delete department. Please try again.");
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