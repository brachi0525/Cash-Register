using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlApi
{
    public interface IClient
    {
      
            int Create(BO.Client item);//create new entity object in Dal
            BO.Client? Read(int id);//Read entity object by its id
            List<BO.Client?> ReadAll(Func<BO.Client, bool>? filter = null);//stage 1 only,reads all entity objects
            void Update(BO.Client item);//updates entity object
            void Delete(int id);//deletes an object by its id
            BO.Client? Read(Func<BO.Client, bool> filter = null);
            bool CheckIfClientExist (int id);//check if customer exist
        
    }
}
