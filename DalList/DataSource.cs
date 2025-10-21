

namespace Dal;
using DO;

static internal class DataSource
{
 static internal  List<Customer?> Customers=new List<Customer?>();
    static internal List<Product?> Products = new List<Product?>();
    static internal List<Sale?> Sales = new List<Sale?>();

internal static  class Config
{
    internal const int NextProductID = 100;
    internal const int NextSailID = 200;
    private static int ProductIndex = NextProductID;
    private static int Saleindex = NextSailID;

/// <summary>
/// פונקציה המחזירה שיחזיר את ערך השדה
///ומקדמת אותו אוטומטית
/// </summary>
public static int ProductNumber
{
    get { return ProductIndex++; }
}
/// <summary>
/// פונקציה המחזירה שיחזיר את ערך השדה
///ומקדמת אותו אוטומטית
/// </summary>
public static int SailNumber
{
    get { return Saleindex++;}
}
    }
}
