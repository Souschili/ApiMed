using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Repository
{
   public interface IDataRepository
    {
        Task<string> GetData();
    }
}
