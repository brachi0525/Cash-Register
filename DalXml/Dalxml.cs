using DalApi;

namespace Dal
{
    public sealed class DalXml : IDal
    {
        // יצירת מופעים קבועים לכל ישות
        public IProduct Product { get; } = new ProductImplementation();
        public ICustomer Customer { get; } = new CustomerImplementation();

      

        public ISale Sale =>  new SaleImplementation();

        public static DalXml Instance { get; } = new DalXml();

        private DalXml()
        {

        }
    }
}
