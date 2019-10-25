using Lasmart.Data.Business.Interfaces;
using Lasmart.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lasmart.Data.Business.Services
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly SqlConnection _db;

        protected Repository(SqlConnection sqlConnection)
        {
            _db = sqlConnection;
        }

        public void Dispose()
        {
        }

        protected SqlConnection Db
        {
            get { return _db; }
        }
    }
}
