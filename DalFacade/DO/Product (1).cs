namespace DO;

/// <summary>
/// פרטי מוצר
/// </summary>
/// <param name="Code">קוד המוצר</param>
/// <param name="ProductNane">שם המוצר</param>
/// <param name="Category">קטגוריה של המוצר</param>
/// <param name="Cost">מחיר</param>
/// <param name="Count">כמות במלאי</param>
public record Product(int Code, string ProductNane,
    Category Category, double Cost, int Count)
{
   public Product():this(100,"נעל בנות", Category.נשים,23,2)
    {

    }

}
