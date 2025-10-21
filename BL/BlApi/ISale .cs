using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public interface ISale
    {
        int Create(BO.Sale item);//create new entity object in Dal
        BO.Sale? Read(int id);//Read entity object by its id
        List<BO.Sale?> ReadAll(Func<BO.Sale, bool>? filter = null);//stage 1 only,reads all entity objects
        void Update(BO.Sale item);//updates entity object
        void Delete(int id);//deletes an object by its id
        BO.Sale? Read(Func<BO.Sale, bool> filter = null);
    }
}
