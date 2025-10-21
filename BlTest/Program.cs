


using DalTeset;

namespace BlTest
{
    internal class Program
    {
        static readonly BlApi.IBl s_bl = BlApi.Factory.Get();


        public static void newOrder(bool isClient)
        {
            try
            {
                BO.Order o = s_bl.Order.createOrder();
               o.IsClient = isClient;

                int select1 = printMainMenu();
                while (select1 != 0)
                {
                    switch (select1)
                    {
                        case 1:
                            addProductToOrder(o);
                            break;
                        case 2:
                            finishOrder(o);
                            break;

                        default:
                            Console.WriteLine("wrong");
                            break;
                    }
                    select1 = printMainMenu();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message+"-----------------");
            }
        }

        public static int printMainMenu()
        {
            Console.WriteLine("for add product to order press 1");
            Console.WriteLine("for finish order press 2");
            Console.WriteLine("to exit press 0");
            int select;
            if (!int.TryParse(Console.ReadLine(), out select))
                select = -1;
            return select;


        }
        public static void addProductToOrder(BO.Order ord)
        {
            Console.WriteLine("enter the id of the product");

            int producrId;
            if (!int.TryParse(Console.ReadLine(), out producrId))
                producrId = 0;
            Console.WriteLine("enter the amount for the product");
            int count;
            if (!int.TryParse(Console.ReadLine(), out count))
                count = -1;
            s_bl.Order.AddProductToOrder(ord, producrId, count);
            Console.WriteLine("the FinallCost:");
            Console.WriteLine(ord.FinallCost);
            foreach (var item in ord.ProductInOrderList)
            {
                Console.WriteLine(item.SaleList);
            }

        }
        public static void finishOrder(BO.Order ord)
        {
            Console.WriteLine("if you want new order  press 1 if you want to exit press 2");
            int choose;
            if (!int.TryParse(Console.ReadLine(), out choose))
                choose = 1;
            if (choose == 1)
            { 
                newOrder(ord.IsClient);
              
            }
           



        }
        static void Main(string[] args)
            
        {
            Initialization.Initialize();

            Console.WriteLine("enter the id of the user");
            int userId;
            if (!int.TryParse(Console.ReadLine(), out userId))
                userId = -1;
           
            bool isClient= s_bl.client.CheckIfClientExist(userId);



            newOrder(isClient);
        }
    }
}