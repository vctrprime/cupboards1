using Lasmart.Data.Business.Interfaces;
using Lasmart.Data.Business.Services;
using Lasmart.Data.Business.UnitOfWorks.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lasmart.Data.Business.UnitOfWorks.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private ICupboardRepository _cupboardRepository;
        protected readonly SqlConnection Db;

        public UnitOfWork()
        {
            Db = SqlHelper.GetSqlConnection();
        }

        public virtual void Dispose()
        {
            if (_cupboardRepository != null)
                _cupboardRepository.Dispose();
        }

        public ICupboardRepository Cupboards()
        {
            return _cupboardRepository ?? (_cupboardRepository = new CupboardRepository(Db));
        }
    }
}
