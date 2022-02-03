using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniORM.Data_Access_Layer
{
    public interface ISqlDataAccess<T> where T : class
    {
        int Delete(int id);
        int Delete(T item);
        int Insert(T item);
        int Update(T item);
    }
}
