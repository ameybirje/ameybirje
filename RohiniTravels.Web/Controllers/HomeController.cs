using Microsoft.Practices.Unity;
using System.Linq;
using System.Web.Mvc;
using RohiniTravels.Web.Models;

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


        public ActionResult SignUp()
        {
            

            return View();
        }
        

    }
}