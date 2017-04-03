using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetBot.Data.Repositories
{
    public interface ISession : IDisposable
    {
        IQueryable<T> All<T>() where T : class, new();
    }
}
