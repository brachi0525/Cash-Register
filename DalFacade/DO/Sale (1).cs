namespace DO;


    /// <summary>
    /// פרטי המבצע
    /// </summary>
    /// <param name="Id">מס' מזהה המבצע</param>
    /// <param name="ProductID">מס' מזהה של המוצר</param>
    /// <param name="Count">כמות נדרשת לקבלת המבצע</param>
    /// <param name="cost">מחיר כולל במבצע</param>
    /// <param name="IsClub">האם המבצע מיועד לכלל הלקוחות או רק ללקוחות מועדון</param>
    /// <param name="DateBeginSale">תאריך תחילת המבצע</param>
    /// <param name="DateEndSale">תאריך סיום המבצע</param>
    public record Sale(int Id, int ProductID, int Count, double cost,
     bool IsClub, DateTime DateBeginSale, DateTime DateEndSale)
    {
    public Sale():this(0,0,0,0.0,false,DateTime.Now,DateTime.Now)
    {

    }

}

