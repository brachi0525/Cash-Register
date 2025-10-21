namespace DO;


/// <summary>
/// פרטי לקוח
/// </summary>
/// <param name="Id">תעודת זהות</param>

/// <param name="CustomerName">שם לקוח</param>
/// <param name="Address">כתובת</param>
/// <param name="">טלפון</param>

public record Customer(int Id, string CustomerName,
    string Address, string PhoneNumber)
{
    public Customer():this(0,"brachi","chafetz chaim","5276828445")
    {
    }
}

