using Microsoft.Practices.Unity;
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


     

       
    }
}