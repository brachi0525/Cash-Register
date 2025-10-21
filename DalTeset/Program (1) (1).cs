
namespace DalTeset;

using Dal;
using DalApi;
using DO;
using Tools;



internal class Program
{

    private static IDal? s_dal = DalApi.Factory.Get;
    //private static IDal? s_dal = DalApi.;

    static void Main(string[] args)
    {
        //Initialization.Initialize();

        try
        {

            int select1 = printMainMenu();
            int select2;
            while (select1 != 0)
            {
                switch (select1)
                {
                    case 1:
                        ProductMenu();
                        break;
                    case 2:SaleMenu();
                        break;
                    case 3:
                        CustomerMenu();
                        break;

                    case 4:
                        LogManager.CleanOldLogs();
                        break;
                    default:
                        Console.WriteLine("wrong");
                        break;
                }
                select1 = printMainMenu();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
   
    private static void ProductMenu()
    {
        int select;
        select = printSubMenu("Product");
        while (select != 0)
        {
            switch (select)
            {
                case 1:
                    AddProduct();
                    break;
                case 2:
                    ReadOne(s_dal.Product);
                    break;
                case 3:
                    GetAll(s_dal.Product);
                    break;
                case 4:
                    UpdateProduct();
                        break;
                case 5:
                    Dalete(s_dal.Product);
                    break;  
                default:
                    Console.WriteLine("wrong");
                    break;
             }
            select = printSubMenu("Product");
        }
    }
    private static Product addP()
    {
            string name;
            double price;
            Category category;
            int count;
            Console.WriteLine("enter the name of the product");
            name = Console.ReadLine();
            Console.WriteLine("enter the category");
            int cat;
            if (!int.TryParse(Console.ReadLine(), out cat)) category = 0;
            else category = (Category)cat;
            Console.WriteLine("enter the price");
            if (double.TryParse(Console.ReadLine(), out price))
                Console.WriteLine("enter the count of product");
            if (!int.TryParse(Console.ReadLine(), out count)) count = 0;
            Product p = new Product(0, name, category, price, count);
            return p;
        
    }
    private static void AddProduct()
    {
        try
        {
            Product p = addP();
            int code = s_dal.Product.Create(p);
            p = p with { Code = code };
            Console.WriteLine(p);
        }catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

            }
    private static void ReadOne<T>(ICrud<T>crud)
    {
        try
        {
            Console.WriteLine("enter code");
            int code = int.Parse(Console.ReadLine());
            Console.WriteLine(crud.Read(code));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    private static void GetAll<T>(ICrud<T> crud)
    { 
        foreach (var p in crud.ReadAll())
            {
            Console.WriteLine(p);
            }
    }
    private static void Dalete<T>(ICrud<T> crud)
    {
        int code;
        Console.WriteLine("enter the code that you want to delete");
        if (!int.TryParse(Console.ReadLine(), out code))
            code = 0;
        crud.Delete(code);

       
    }
    private static void UpdateProduct()
    {
        try
        {
            Console.WriteLine("enter code");
            int code = int.Parse(Console.ReadLine());
            Product p = addP() with { Code = code };
            s_dal.Product.Update(p);
        }catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }


    private static void CustomerMenu()
    {
        int select;
        select = printSubMenu("Customer");
        while (select != 0)
        {
            switch (select)
            {
                case 1:
                    AddCustomer();
                    break;
                case 2:
                  ReadOne(s_dal.Customer);
                    break;
                case 3:
                    GetAll(s_dal.Customer);
                    break;
                case 4:
                    UpdateCustomer();
                    break;
                case 5:
                    Dalete(s_dal.Customer);
                    break;
                default:
                    Console.WriteLine("wrong");
                    break;
            }
            select = printSubMenu("Customer");
        }
    }
    private static Customer addC()
    {
        int id;
        string name;
        string addres;
        string phone;
        Console.WriteLine("enter the id of the customer");
        if (!int.TryParse(Console.ReadLine(), out id)) id = 0;
        Console.WriteLine("enter the name");
        name = Console.ReadLine();
        Console.WriteLine("enter the addres");
        addres = Console.ReadLine();
        Console.WriteLine("enter the phone");
         phone = Console.ReadLine();
        Customer c = new Customer(id, name, addres, phone);
        return c;
    }
    private static void AddCustomer()
    {
        try
        {
           Customer c = addC();
            s_dal.Customer.Create(c);
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
    }
    private static void ReadCustomer()
    {
        try
        {
            Console.WriteLine("enter id");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine(s_dal.Customer.Read(id));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    private static void GetAllCustomer()
    {
        foreach (var c in s_dal.Customer.ReadAll())
        {
            Console.WriteLine(c);
        }
    }
    private static void DaleteCustomer()
    
    {
        int id;
        Console.WriteLine("enter the id that you want to delete");
        if (!int.TryParse(Console.ReadLine(), out id))
            id = 0;
        s_dal.Customer.Delete(id);
    }
    private static void UpdateCustomer()
    {
        try
        {
            Customer c = addC();
            s_dal.Customer.Update(c);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }


    private static void SaleMenu()
    {
        int select;
        select = printSubMenu("Sale");
        while (select != 0)
        {
            switch (select)
            {
                case 1:
                    AddSale();
                    break;
                case 2:
                    ReadOne(s_dal.Sale);
                    break;
                case 3:
                    GetAll(s_dal.Sale);
                    break;
                case 4:
                    UpdateSale();
                    break;
                case 5:
                    Dalete(s_dal.Sale);
                    break;
                default:
                    Console.WriteLine("wrong");
                    break;
            }
            select = printSubMenu("sale");
        }
    }
    private static Sale addS()
    {
        int id;
        int ProductID;
        int count;
        int cost;
        int phone;
        bool isClub;
        DateTime DateBeginSale;
        DateTime DateEndSale;
        Console.WriteLine("enter the id of the sale");
        if (!int.TryParse(Console.ReadLine(), out id)) id = 0;
        Console.WriteLine("enter the id of the product");
        if (!int.TryParse(Console.ReadLine(), out ProductID)) ProductID = 0;
        Console.WriteLine("enter the count");
        if (!int.TryParse(Console.ReadLine(), out count)) count = 0;
        Console.WriteLine("enter the cost");
        if (!int.TryParse(Console.ReadLine(), out cost)) cost = 0;
        Console.WriteLine("enter if is club");
        if (!bool.TryParse(Console.ReadLine(), out isClub)) isClub = false;

        Console.WriteLine("enter the DateBeginSale");
        if (!DateTime.TryParse(Console.ReadLine(), out DateBeginSale)) DateBeginSale =DateTime.Now;
        Console.WriteLine("enter the DateEndSale");
        if (!DateTime.TryParse(Console.ReadLine(), out DateEndSale)) DateEndSale = DateTime.Now;
        Sale s = new Sale(id,ProductID, count, cost, isClub, DateBeginSale, DateEndSale);
        return s;
    }
    private static void AddSale()
    {
        try
        {
            Sale s = addS();
            s_dal.Sale.Create(s);
            Console.WriteLine(s);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
    private static void UpdateSale()
    {
        try
        {
            Sale s = addS();
            s_dal.Sale.Update(s);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
  //private static void DaleteSale()
  //  {
        
  //          int id;
  //          Console.WriteLine("enter the id that you want to delete");
  //          if (!int.TryParse(Console.ReadLine(), out id))
  //              id = 0;
  //          s_dal.Sale.Delete(id);
        
  //  }

   
    public static int printMainMenu()
        {
            Console.WriteLine("for Products press 1");
            Console.WriteLine("for Sales press 2");
            Console.WriteLine("for Customers press 3");
            Console.WriteLine("to exit press 0");
            int select;
            if (!int.TryParse(Console.ReadLine(), out select))
                select = -1;
            return select;


        }
    public static int printSubMenu(string item)
        {
            Console.WriteLine($"to add {item} press 1");
            Console.WriteLine($"to read on {item} press 2");
            Console.WriteLine($"to read all {item} press 3");
            Console.WriteLine($"to update {item} press 4");
            Console.WriteLine($"to delete {item} press 5");
        int select;
        if (!int.TryParse(Console.ReadLine(), out select))
            select = -1;
        return select;
    }
    }
