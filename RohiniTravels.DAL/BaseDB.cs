using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace RohiniTravels.DAL
{
    public class BaseDB
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

        public BaseDB(IUnityContainer container)
        {
            _container = container;
        }

        public EfMRSHelper GetMultipleResults(string procedureName, SqlParameter[] parameters = null, bool useTransaction = false)
        {
            return repository.ExecuteMRSStoredProcedure(procedureName, parameters, useTransaction);
        }

        public DataSet GetDataSet(string ProcedureName, Dictionary<string, object> ParamatersDictonary)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["strcon"].ConnectionString.ToString());
            SqlCommand sqlComm = new SqlCommand(ProcedureName, con);
            foreach (var item in ParamatersDictonary)
            {
                sqlComm.Parameters.AddWithValue(item.Key, item.Value);
            }
            DataSet ds = new DataSet();
            sqlComm.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlComm;
            da.Fill(ds);

            return ds;
        }

        public IEnumerable<T> GetList<T>(string procName)
        {
            return repository.ExecuteStoredProcedureList<T>(procName).ToList();
        }

    }
}
