using Microsoft.Practices.Unity;
using RohiniTravels.BAL.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading;
using System.Threading.Tasks;
using RohiniTravels.BAL.Models;

namespace RohiniTravels.Api.Controllers
{
   [RoutePrefix("Api/V1/Payment")]
    public class PaymentApiController : BaseApiController
    {

        private PaymentProcess _paymentProcess;
        public PaymentApiController(IUnityContainer container) : base(container)
        {
            _paymentProcess = container.Resolve<PaymentProcess>();
        }

        [Route("BalancePayment")]
        [HttpGet]
        public async Task<IHttpActionResult> GetBalancePayment()
        {
           var data = await Task.Run(() =>_paymentProcess.GetBalancePaymentData());

            return Json(data);

        }


        //[Route("Masters")]
        //[HttpGet]
        //public async Task<IHttpActionResult> GetMasters()
        //{
        //Task<List<GenericValues>> studentResult =  Task.Factory.StartNew(() => _paymentProcess.StudentPaymentList());
        //Task<List<GenericValues>> serviceResult = Task.Factory.StartNew(() => _paymentProcess.SevicesList());
        //Task<List<GenericValues>> edInstituateResult = Task.Factory.StartNew(() => _paymentProcess.EducationInstituteMaster());

        //await Task.WhenAll(studentResult, serviceResult, edInstituateResult);

        //return Json(new { 
        //        Student = studentResult.Result,
        //        Services = serviceResult.Result,
        //        EdInstituate = edInstituateResult.Result
        //});

        //}


        [Route("Masters")]
        [HttpGet]
        public IHttpActionResult GetMasters()
        {

            var result = _paymentProcess.MastersData();

            return Json(new
            {
                Student = result[0],
                Services = result[1],
                EducationdInstituate = result[2],
                Months = result[3]
            });

        }

    }
}
