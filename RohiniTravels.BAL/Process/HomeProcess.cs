using Microsoft.Practices.Unity;
using RohiniTravels.BAL.Common;
using RohiniTravels.BAL.Models;
using RohiniTravels.DAL;
using RohiniTravels.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace RohiniTravels.BAL.Process
{
    public class HomeProcess : Root
    {

        public HomeProcess(IUnityContainer container) : base(container)
        {
            baseDb = new BaseDB(container);
        }

        #region LoginDetails
        public dynamic CheckLogin(string Username, string Password)
        {
            var parameters = new[]
            {
                new SqlParameter("@Username", Username),
                  new SqlParameter("@Password", Password)

             };
            return baseDb.GetMultipleResults("spStudentLogin", parameters)
                         .WithEntity<string>()
                         .Execute();
        }
        #endregion
        #region Signup
        public void SignupDetails(SignUpClass objSignUp)
        {
            var parameters = new[]
           {
                new SqlParameter("@FirstName", objSignUp.FirstName),
                  new SqlParameter("@LastName", objSignUp.LastName),
                  new SqlParameter("@MobileNumber", objSignUp.MobileNumber),
                  new SqlParameter("@Email", objSignUp.EmailAddress),
                    new SqlParameter("@Password", objSignUp.Password),

             };
            repository.ExecuteSqlCommand("spSignup", parameters);
        }
        #endregion
        #region ForgotPassword

        
        public dynamic GetOTP(string MobileNo, string Type)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    string objOTP = "";

                      var parameters = new[]
                      {
                          new SqlParameter("@MobileNumber",MobileNo),
                      };

                    int RegId = repository.ExecuteStoredProcedureScalar<int>("spGetRegisteredId", parameters);

                    if (RegId != 0)
                    {
                         objOTP = CommonMethod.GenerateRandomNumber(6);
                        var OTPparameters = new[]
                        {
                         new SqlParameter("@OTPValue", objOTP),
                           new SqlParameter("@RegId", RegId),
                           new SqlParameter("@Type", Type)


                        };
                        repository.ExecuteSqlCommand("spInsertOTP", OTPparameters);
                    }

                    transaction.Complete();
                    return RegId;
                 
                }
                catch (Exception ex)
                {
                    transaction.Dispose();
                    throw ex;
                }
            }
        }
        public dynamic ValidateOTP(string OTP,string Type,int RegId)
        {
            var parameters = new[]
            {
               new SqlParameter("@OTP",OTP),
               new SqlParameter("@Type",Type),
                new SqlParameter("@RegId",RegId)
            };

          int  Id = repository.ExecuteStoredProcedureScalar<int>("spValidateOTP", parameters);
            return Id;
        }

        public void UpdatePassword(string Password, int RegId)
        {
            var parameters = new[]
            {
               new SqlParameter("@Password",Password),
               new SqlParameter("@RegId",RegId)
            };

            repository.ExecuteSqlCommand("spChangePassword", parameters);
        }

        public dynamic ResendOTP(int RegId)
        {

            string OTPValue = CommonMethod.GenerateRandomNumber(6);
            var parameters = new[]
            {
               new SqlParameter("@OTPValue",OTPValue),
               new SqlParameter("@RegId",RegId)
            };

           
            string objStatus = repository.ExecuteStoredProcedureScalar<string>("spResendOTP", parameters);
            return objStatus;
        }
        #endregion

    }
}
