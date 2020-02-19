using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ANM.Example.Application.Abstractions.Services
{
    public interface IUnitOfWork
    {
        Task<int> Save();
    }
}
