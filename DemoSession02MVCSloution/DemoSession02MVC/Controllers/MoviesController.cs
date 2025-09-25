using Microsoft.AspNetCore.Mvc;

namespace DemoSession02MVC.Controllers
{
    public class MoviesController : Controller
    {
        public string Index()
        {
            return "Hello from Movies Controller - Index Action";
        }

        #region Example 01
        //// URL: BaseURL/Movies/GetMovie?id=12&name=filmname
        //[HttpGet]
        //public ContentResult GetMovie(int? id, string name)
        //{
        //    //ContentResult result = new ContentResult();
        //    //result.Content = $"Movie ID: {id}, Movie Name: {name}";
        //    //return result;
        //    return Content($"Movie ID: {id}, Movie Name: {name}");
        //}

        //// to prevent this method from being treated as an action method
        //[NonAction]
        //public ContentResult CompanySecret()
        //{
        //    return new ContentResult
        //    {
        //        Content = "This is a company secret and should not be accessible as an action."
        //    };
        //}
        #endregion

        #region Example 02
        // URL: BaseURL/Movies/GetMovie?id=12&name=filmname
        [HttpGet]
        public IActionResult GetMovie(int id, string name)
        {
            if (id <= 0)
                return BadRequest("Invalid movie ID.");
            else if (id < 10)
                return NotFound("Movie not found.");
            else 
                return Content($"Movie ID: {id}, Movie Name: {name}");
        }

        [HttpGet]
        public IActionResult TestRedirectToAction()
        {
            #region RedirectToAction
            // return Redirect("https://www.google.com/"); // External URL
            return RedirectToAction(nameof(GetMovie)); // Internal URL in the same controller
            // return RedirectToAction("GetMovie", "Home"); // Internal URL but diff controller
            #endregion
            #region RedirectToRoute
            // return RedirectToRoute("Default",new { controller = "Movies", action = "GetMovie" , id = 20 , name = "Test"});
            #endregion
        }
        #endregion

    }
}
