using Demo.BLL.Services.Departments;
using Microsoft.AspNetCore.Mvc;
namespace Demo.PL.Controllers
{
    public class DepartmentController(IDepartmentServices _departmentServices) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentServices.GetAll();
            return View(departments);
        }
    }
}
