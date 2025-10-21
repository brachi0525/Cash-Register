using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi
{
    public interface ICrud<T>
    {
        int Create(T item);//create new entity object in Dal
        T? Read(int id);//Read entity object by its id
        List<T?> ReadAll(Func<T,bool>?filter=null);//stage 1 only,reads all entity objects
        void Update(T item);//updates entity object
        void Delete(int id);//deletes an object by its id
        T? Read(Func<T,bool> filter=null);
    }
}
