using Microsoft.Practices.Unity;
using System.Web.Mvc;
using System.Linq;
using RohiniTravels.Web.Models;


namespace RohiniTravels.Web.Controllers
{
    public class AdminController : BaseController
    {

        public AdminController(IUnityContainer container) : base(container) { }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AcceptRequest()
        {


            
            return View();
        }


        //public JsonResult GetPenStudRegData()
        //{

        //    var Result = (from e in repository.SetReadOnly<REGISTRATION_MST_T>()
        //                  select new StudentsDetails
        //                  {
        //                      FirstName = e.RMT_STUD_FIRST_NAME
        //                      //MiddleName = e.RMT_STUD_MIDDLE_NAME,
        //                      //LastName = e.RMT_STUD_LAST_NAME,
        //                      //Gender = e.RMT_STUD_GENDER,
        //                      //ParentName = e.RMT_PARENT_NAME,
        //                      //ParentMobile = e.RMT_PARENT_MOB,
        //                      //Address = e.RMT_STUD_ADD,
        //                      //Pincode = (int)e.RMT_STUD_PINCODE

        //                  }).ToList();

        //    var newresut = (from d in Result select new { d.FirstName }).ToList();


        //    return new JsonResult
        //    {
        //        Data = new { ErrorMessage = "Secuss", Success =  true, StudendData = newresut },
        //        ContentEncoding = System.Text.Encoding.UTF8,
        //        JsonRequestBehavior = JsonRequestBehavior.DenyGet
        //    };

        //}


        //public JsonResult GetPenStudRegData([DataSourceRequest]DataSourceRequest request)
        //{
        //    //var Result = new List<IEnumerable>();

        //    //IEnumerable<StudentsDetails> Result = (from e in repository.SetReadOnly<REGISTRATION_MST_T>()
        //    //          select new StudentsDetails
        //    //          {
        //    //              FirstName = e.RMT_STUD_FIRST_NAME
        //    //          }).ToList();


        //    var Result = (from e in repository.SetReadOnly<REGISTRATION_MST_T>()
        //                  select new StudentsDetails
        //                  {
        //                      FirstName = e.RMT_STUD_FIRST_NAME,
        //                      MiddleName = e.RMT_STUD_MIDDLE_NAME,
        //                      LastName = e.RMT_STUD_LAST_NAME,
        //                      Gender = e.RMT_STUD_GENDER,
        //                      ParentName = e.RMT_PARENT_NAME,
        //                      ParentMobile = e.RMT_PARENT_MOB,
        //                      Address = e.RMT_STUD_ADD,
        //                      Pincode = (int)e.RMT_STUD_PINCODE

        //                  }).ToList();


        //    Student st = new Student();

        //    st.LstStudentDetails = Result;

        //    return Json(Result.ToList().ToDataSourceResult(request));
        //}
    }
}