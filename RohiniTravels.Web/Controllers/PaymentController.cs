using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using System.Web.Mvc;
using RohiniTravels.Web.Models;
using RohiniTravels.BAL.Process;

namespace RohiniTravels.Web.Controllers
{
    public class PaymentController : BaseController
    {
        // GET: Payment
        private PaymentProcess _paymentProcess { get; set; }
        public PaymentController(IUnityContainer container) : base(container) {

            _paymentProcess = container.Resolve<PaymentProcess>();

        }
     
        public ActionResult Index()
        {
            return View();
        }

        //Working Code
        [HttpGet]
        public JsonResult GetPaymentList()
        {

            var lstPayment =  _paymentProcess.GetBalancePaymentData();

            return Json(new { Result = lstPayment, Success = true }, JsonRequestBehavior.AllowGet);

        }
    }
}