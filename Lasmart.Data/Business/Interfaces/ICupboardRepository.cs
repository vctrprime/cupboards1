using Lasmart.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lasmart.Data.Business.Interfaces
{
    public interface ICupboardRepository : IRepository<Cupboard>
    {
        IEnumerable<Cupboard> GetAll();
    }
}
