using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;

namespace RohiniTravels.BAL.Models
{
    public class Student
    {
        public string standared { get; set; }
        public int StudentId { get; set; }
        public StudentsDetails PropStudentDetails { get; set; }
        public List<StudentsDetails> LstStudentDetails { get; set; }
        public Services PropServices { get; set; }
        public EducatioalInstitution PropEducatioalInstitution { get; set; }
        public int RegistrationID { get; set; }


        //private IUnityContainer _container;

        //public string Test()
        //{

        //    DBcommon t = new DBcommon(_container);

        //    t.Getservices();

        //    return "";

        //}


    }
    //public class SaveRegData
    //{
    //    public string SaveData { get; set; }
    //}
}