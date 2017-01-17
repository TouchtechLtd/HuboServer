using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubo.EntityFramework.Repositories
{
    public interface IShiftRepository : IRepository
    {
        int StartShift(Shift shift);
    }
}
