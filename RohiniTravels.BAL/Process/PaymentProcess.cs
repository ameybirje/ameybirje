using Microsoft.Practices.Unity;
using RohiniTravels.BAL.Common;
using RohiniTravels.BAL.Models;
using RohiniTravels.DAL;
using RohiniTravels.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RohiniTravels.BAL.Process
{
    public class PaymentProcess : Root
    {

        public PaymentProcess(IUnityContainer container) : base(container)
        {
            baseDb = new BaseDB(container);         
        }

     
        //public List<GenericValues> StudentPaymentList()
        //{
        //    return repository.SetReadOnly<StudentMaster>()
        //                 .Select(x => new GenericValues { Id = x.Id, Value = x.FirstName + " " + x.LastName })
        //                 .ToList();
        //}
        //public List<GenericValues> SevicesList()
        //{
        //    return repository.SetReadOnly<ServicesMaster>()
        //                 .Select(x => new GenericValues { Id = x.Id, Value = x.Name })
        //                 .ToList();
        //}
        //public List<GenericValues> EducationInstituteMaster()
        //{
        //    return repository.SetReadOnly<InstituteMaster>()
        //                 .Select(x => new GenericValues { Id = x.Id, Value = x.Name })
        //                 .ToList();
        //}


        public List<IEnumerable> MastersData()
        {
           
            return baseDb.GetMultipleResults("Usp_GetMasters")
                         .WithEntity<GenericValues>()
                         .WithEntity<GenericValues>()
                         .WithEntity<GenericValues>()
                          .WithEntity<GenericValuesString>()
                         .Execute();
        }

        public List<Payment> GetBalancePaymentData()
        {

            var result = repository.ExecuteStoredProcedureList<StudentPaymentList>("Usp_BalancePaymentList").ToList();

            var distinctStudent = result.GroupBy(x => x.StudentId)
                                        .Select(g => g.First()).ToList();

            List<Payment> lstPayment = new List<Payment>();

            foreach (var item in distinctStudent)
            {

                Payment payment = new Payment();

                var data = result.Where(x => x.StudentId == item.StudentId)
                                   .Select(y => new StudentService
                                   {
                                       Amount = y.Amount,
                                       EducationalInstitute = y.EducationalInstitute,
                                       Standard = y.Standard,
                                       Service = y.Service,
                                       StudentId = y.StudentId,
                                       StudentServiceId = y.StudentServiceId
                                   })
                                   .ToList();

                payment.Services = data;
                payment.StudentName = item.StudentName;
                payment.StudentId = item.StudentId;
                payment.TotalAmount = item.TotalAmount;

                lstPayment.Add(payment);

            }


            return lstPayment;

        }


    }
}
