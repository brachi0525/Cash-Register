
namespace DalTeset;
using DO;
using DalApi;
using Dal;
using System.Xml.Serialization;

public abstract class Initialization
{
    //private static IProduct? _dalProduct;
    // private static ICustomer? _dalCustomer;
    //private static ISale? _dalSale;
    private static IDal? s_dal;
    public static void createCustomer()
    {

        s_dal.Customer.Create(new Customer());

    }
    public static void createProduct()
    {
        s_dal.Product.Create(new Product());
    }
    public static void createSale()
    {
        s_dal.Sale.Create(new Sale());
    }
    // public static void Initialize(IProduct prod)

    public static void Initialize()//IProduct prod, ISale sale,ICustomer cust)
    {

        //_dalProduct = prod;
        //_dalSale = sale;
        //_dalCustomer = cust;
        s_dal = DalApi.Factory.Get;
        createProduct();
        createSale();
        createCustomer();

    }
}