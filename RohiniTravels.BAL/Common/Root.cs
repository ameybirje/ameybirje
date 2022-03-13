using Microsoft.Practices.Unity;
using RohiniTravels.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RohiniTravels.BAL.Common
{
   public class Root
   {

        private IUnityContainer _container;
        private IRepository _repository;

        protected IRepository repository
        {
            get
            {
                if (_repository == null)
                    _repository = _container.Resolve<IRepository>();
                return _repository;
            }
        }
        public Root(IUnityContainer container)
        {
            _container = container;
        }

        public BaseDB baseDb { get; set; }
    }
}
