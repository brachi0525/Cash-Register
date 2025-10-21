using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;

namespace Dal
{
    sealed internal class DalList : IDal
    {
        public IProduct Product => new ProductImplememetation();
        public ISale Sale => new saleImplememetation();
        public ICustomer Customer => new CustomerImplememetion();

        public static  DalList Instance { get; } = new DalList();

        private DalList()
        {
            
        }

    }
}
