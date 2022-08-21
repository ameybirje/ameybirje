using Microsoft.Practices.Unity;
using System.Linq;
using System.Web.Mvc;
using RohiniTravels.Web.Models;
using RohiniTravels.Web.ViewModel;
using System.Collections.Generic;
using RohiniTravels.BAL.Models;
using RohiniTravels.Web.Helpers;
using RohiniTravels.BAL.Process;
using System;

namespace RohiniTravels.Web.Controllers
{
    public class HomeController : BaseController
    {
        HomeProcess _HomeProcess;
        public HomeController(IUnityContainer container) : base(container) 
        {
            _HomeProcess = container.Resolve<HomeProcess>();
        }
        #region Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AjaxValidateAntiForgeryToken]
        public JsonResult CheckLoginDetails(string Username,string Password)
        {
            var LoginStatus = _HomeProcess.CheckLogin(Username, Password);

            return Json(new
            {
                success = true,
                LoginStatus
            });
        }
        #endregion
        #region SignUp
        [HttpPost]
        [AjaxValidateAntiForgeryToken]
        public JsonResult SignUp(SignUpClass objSignUp)
        {
            List<GenericValuesString> objErrors = null;

            if (ModelState.IsValid)
            {
                _HomeProcess.SignupDetails(objSignUp);
            }
            else
            {
                objErrors = GetModelStateErrors();
            }


            return Json(new
            {
                ValidationError = objErrors,
                success = objErrors != null ? false : true
            });
        }

        #endregion

        #region ForgotPassword
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AjaxValidateAntiForgeryToken]
        public JsonResult CheckMobileNo(string MobileNo,string Type)
        {
            string OTPStatus = "";
            var objRegId= _HomeProcess.GetOTP(MobileNo, Type);
            //Send OTP on registered mobile number
            if (objRegId != 0)
            {
                Session["RegId"] = Convert.ToInt32(objRegId);
                OTPStatus = "Success";
            }
            return Json(new
            {
                success =  true,
                OTPStatus
            });
        }


        [HttpPost]
        [AjaxValidateAntiForgeryToken]
        public JsonResult CheckOTP(string OTP, string Type)
        {
            bool OTPStatus = false;
            int RegId = Convert.ToInt32(Session["RegId"]);
            int objId = _HomeProcess.ValidateOTP(OTP, Type, RegId);
            if (objId != 0)
            {
                OTPStatus =true;
            }
            else
            {
                OTPStatus =false;
            }
            return Json(new
            {
                success = true,
                OTPStatus
            });
        }


        [HttpPost]
        [AjaxValidateAntiForgeryToken]
        public JsonResult UpdateNewPassword(string Password)
        {
          
            int RegId = Convert.ToInt32(Session["RegId"]);
            _HomeProcess.UpdatePassword(Password, RegId);
         
            return Json(new
            {
                success = true
            });
        }

        [HttpPost]
        [AjaxValidateAntiForgeryToken]
        public JsonResult ResendOTP()
        {

            int RegId = Convert.ToInt32(Session["RegId"]);
            string objResentOTPStatus = _HomeProcess.ResendOTP(RegId);

            return Json(new
            {
                success = true,
                objResentOTPStatus
            });
        }
        #endregion




    }
}