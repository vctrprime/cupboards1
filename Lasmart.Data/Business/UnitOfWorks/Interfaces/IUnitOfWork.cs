using Lasmart.Data.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lasmart.Data.Business.UnitOfWorks.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICupboardRepository Cupboards();
    }
}
