using Microsoft.Practices.Unity;
using System.Linq;
using System.Web.Mvc;
using RohiniTravels.Web.Models;
using RohiniTravels.BAL.Process;
//using RohiniTravels.DAL;

namespace RohiniTravels.Web.Controllers
{
    public class RegistrationController : BaseController
    {

        // GET: Registration 
        // IRepository _repository;
        //RohiniTravelsEntities REdb = new RohiniTravelsEntities();

        private PaymentProcess _paymentProcess { get; set; }
        public RegistrationController(IUnityContainer container) : base(container) {

            _paymentProcess = container.Resolve<PaymentProcess>();
        }
        
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult getServices()
        //{

        //    var Result = repository.SetReadOnly<SERVICES_MST_T>()
        //                 .Where(x => x.SER_ACTIVE == true)
        //                 .Select(x => new {x.SER_ID, x.SER_SERVICE } ).ToList();


        //    return new JsonResult
        //    {
        //        Data = new { result = Result },
        //        ContentEncoding = System.Text.Encoding.UTF8,
        //        JsonRequestBehavior = JsonRequestBehavior.DenyGet
        //    };

        //}

        //public ActionResult SaveRegData(Student ObjReg)
        //{
        //    REGISTRATION_MST_T ObjRegMst = new REGISTRATION_MST_T();
        //    ObjRegMst.RMT_STUD_FIRST_NAME = ObjReg.PropStudentDetails.FirstName;
        //    ObjRegMst.RMT_STUD_MIDDLE_NAME = ObjReg.PropStudentDetails.MiddleName;
        //    ObjRegMst.RMT_STUD_LAST_NAME = ObjReg.PropStudentDetails.LastName;
        //    ObjRegMst.RMT_STUD_GENDER = ObjReg.PropStudentDetails.Gender;
        //    ObjRegMst.RMT_STUD_DOB = ObjReg.PropStudentDetails.DOB;
        //    ObjRegMst.RMT_STUD_STANDARED = ObjReg.PropStudentDetails.Standared;
        //    ObjRegMst.RMT_PARENT_NAME = ObjReg.PropStudentDetails.ParentName;
        //    ObjRegMst.RMT_PARENT_MOB = ObjReg.PropStudentDetails.ParentMobile;
        //    ObjRegMst.RMT_PARENT_OTHER_NO = ObjReg.PropStudentDetails.ParentOtherNo;
        //    ObjRegMst.RMT_PARENT_EMAIL = ObjReg.PropStudentDetails.ParentEmail;
        //    ObjRegMst.RMT_STUD_ADD = ObjReg.PropStudentDetails.Address;
        //    ObjRegMst.RMT_STUD_PINCODE = ObjReg.PropStudentDetails.Pincode;
        //    ObjRegMst.RMT_STUD_USERNAME = ObjReg.PropStudentDetails.LoginID;
        //    ObjRegMst.RMT_STUD_PASSWORD = ObjReg.PropStudentDetails.Password;
        //    repository.Add(ObjRegMst);
        //    repository.Save();
        //    return Json("Sucess", JsonRequestBehavior.AllowGet);
          
        //}

        //public JsonResult getServiesData(string SDType)
        //{
        //    var Services = (from EIMT in REdb.EDUCATIOAL_INSTITUTION_MST_T
        //                    where EIMT.EI_TYPE == SDType
        //                    select new  { EIMT.EI_ID , EIMT.EI_NAME}).ToList();
        //    return Json(new { Services, SDType },JsonRequestBehavior.AllowGet);
        //}
     

    }
}