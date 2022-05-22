using Microsoft.Practices.Unity;
using System.Linq;
using System.Web.Mvc;
using RohiniTravels.Web.Models;
using RohiniTravels.Web.ViewModel;
using System.Collections.Generic;
using RohiniTravels.BAL.Models;
using RohiniTravels.Web.Helpers;

namespace RohiniTravels.Web.Controllers
{
    public class HomeController : BaseController
    {

        public HomeController(IUnityContainer container) : base(container) { }

        public ActionResult Index()
        {
           // var Result = repository.SetReadOnly<REGISTRATION_MST_T>().ToList();

            return View();
        }


        public ActionResult IndexOld()
        {
            

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpPost]
        [AjaxValidateAntiForgeryToken]
        public JsonResult SignUp(SignUpVM model)
        {


            List<GenericValuesString> objErrors = null; 

            if (ModelState.IsValid)
            {

            }
            else
            {
                 objErrors  =  GetModelStateErrors();
                
            }


            return Json(new { ValidationError = objErrors, 
                            success = objErrors != null ? false :true  });
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }


    }
}