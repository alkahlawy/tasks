using Demo.BLL.Services;
using Microsoft.AspNetCore.Mvc;
namespace Demo.PL.Controllers
{
    public class DepartmentController : Controller
    {
        public DepartmentController(DepartmentServices departmentServices)
        {
            
        } // Ask CLR to Inject DepartmentServices Instance
    }
}
