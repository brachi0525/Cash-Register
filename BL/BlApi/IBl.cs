using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;

namespace BlApi
{
    public interface IBl
    {
        IProduct Product { get; }
        IClient client { get; }
        ISale Sale { get; }
        IOrder Order { get; }

    }
}
