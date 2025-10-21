using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public interface IProduct
    {
        int Create(BO.Product item);//create new entity object in Dal
        BO.Product? Read(int id);//Read entity object by its id

        List<BO.Product?> ReadAll(Func<BO.Product, bool>? filter = null);//stage 1 only,reads all entity objects
        void Update(BO.Product item);//updates entity object
        void Delete(int id);//deletes an object by its id
        BO.Product? Read(Func<BO.Product, bool> filter = null);
        List<BO.SaleInProduct> GetListSale(int code, bool isClient);
    }
}
