using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RohiniTravels.BAL.Common
{
    public class CommonMethod
    {

        public static string GenerateRandomNumber(int NumberCount)
        {
            string numbers = "1234567890";

            string characters = numbers;

            string OTP = string.Empty;
            for (int i = 0; i < NumberCount; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (OTP.IndexOf(character) != -1);
                OTP += character;
            }
            return OTP;

        }
    }
}
