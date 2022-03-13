using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RohiniTravels.Api.Controllers
{
    public class BaseApiController : ApiController
    {

        private IUnityContainer _container;
        public BaseApiController(IUnityContainer container)
        {
            _container = container;
        }
    }
}
