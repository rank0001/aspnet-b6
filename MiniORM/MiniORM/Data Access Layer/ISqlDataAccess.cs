using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniORM.Data_Access_Layer
{
    public interface ISqlDataAccess<T> where T : class
    {
        void Delete(int id);
        void Delete(T item);
        void Insert(T item);
        void Update(T item);
        List<T> GetById(int id);
        List<T> GetAll();


    }
}
