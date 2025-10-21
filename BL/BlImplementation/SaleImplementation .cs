using BlApi;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation
{
    internal class SaleImplementation : ISale
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        //create new entity object in Dal
        public int Create(BO.Sale item)

        {
            try
            {
                return _dal.Sale.Create(item.convertToDOSale());
            }
            catch (Exception ex)
            {
                throw new BO.BlException(ex.Message);
            }
        }
        //Read entity object by its id
        public BO.Sale? Read(int id)
        {
            try
            {
                return _dal.Sale.Read(id).convertToBOSale();
            }
            catch (Exception ex)
            {
                throw new BO.BlException(ex.Message);
            }
        }
        //stage 1 only,reads all entity objects
        public BO.Sale? Read(Func<BO.Sale, bool> filter = null)
        {
            try
            {
                return _dal.Sale.Read(s => filter(s.convertToBOSale())).convertToBOSale();

            }
            catch (Exception ex)
            {
                throw new BO.BlException(ex.Message);
            }
        }
        public List<BO.Sale?> ReadAll(Func<BO.Sale, bool>? filter = null)
        {
            try
            {
                return _dal.Sale.ReadAll()
 .Select(c => BO.Tools.convertToBOSale(c))
 .Where(p => filter == null || filter(p))
 .ToList();
                // return _dal.Sale.ReadAll(Sale => filter(BO.Tools.convertToBOSale(Sale)))
                //.Select(c => BO.Tools.convertToBOSale(c)).ToList();
            }
            catch (Exception ex)
            {
                throw new BO.BlException(ex.Message);
            }


        }
        //updates entity object
        public void Update(BO.Sale item)
        {
            try
            {
                _dal.Sale.Update(item.convertToDOSale());
            }
            catch (DO.SaleNotFoundException ex)
            {
                throw new BO.BlException($"לא ניתן לעדכן – מבצע עם מזהה {item.Id} לא נמצא", ex);
            }
            catch (Exception ex)
            {
                throw new BO.BlException(ex.Message);
            }

        }

        //deletes an object by its id
        public void Delete(int id)
        {
            try
            {
                _dal.Sale.Delete(id);
            }
            catch (Exception ex)
            {
                throw new BO.BlException(ex.Message);
            }
        }
       

    }
}
