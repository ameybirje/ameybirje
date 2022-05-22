using Microsoft.Practices.Unity;
using RohiniTravels.BAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RohiniTravels.Web.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base


        private const string _applicationTitle = "Rohini Travels - ";

        private IUnityContainer _container;
        //private RohiniTravels.DAL.IRepository _repository;

        //protected RohiniTravels.DAL.IRepository repository
        //{
        //    get
        //    {
        //        if (_repository == null)
        //            _repository = _container.Resolve<RohiniTravels.DAL.IRepository>();
        //        return _repository;
        //    }
        //}

        public BaseController(IUnityContainer container)
        {
            _container = container;
        }


        public List<GenericValuesString> GetModelStateErrors()
        {
            //ViewData.ModelState.Keys
            //ViewDataDictionary mdt

            List<GenericValuesString> lst = new List<GenericValuesString>();

            foreach (var modelStateKey in ViewData.ModelState.Keys)
            {
                var modelStateVal = ViewData.ModelState[modelStateKey];
                foreach (var error in modelStateVal.Errors)
                {
                    var key = modelStateKey;
                    var errorMessage = error.ErrorMessage;
                    var exception = error.Exception;

                    lst.Add(new GenericValuesString() { Id = key, Value = errorMessage });
                }
            }


            return lst;
        }

       
    }
}