namespace DO;

/// <summary>
/// חריגה זו נזרקת כאשר קובץ מבוקש לא נמצא במערכת.
/// </summary>
[Serializable]
public class FileNotFound : Exception
{
    public FileNotFound()
        : base("The requested file was not found.") { }

    public FileNotFound(string message)
        : base(message) { }
}
[Serializable]
public class ProductNotFoundException : Exception
{
    public ProductNotFoundException(string message) : base(message) { }
}
[Serializable]

public class ErrorInReed : Exception
{
    public ErrorInReed()
        : base("can't raed.") { }

    public ErrorInReed(string message)
        : base(message) { }
}

/// <summary>
/// חריגה זו נזרקת כאשר קוד שסופק אינו תקף או אינו קיים במערכת.
/// </summary>
[Serializable]
public class CodeNotValid : Exception
{
    public CodeNotValid()
        : base("The code isn't exist.") { }

    public CodeNotValid(string message)
        : base(message) { }
}

/// <summary>
/// חריגה זו נזרקת כאשר משתמש מנסה להירשם, אך כבר קיים במערכת.
/// </summary>
[Serializable]
public class UserAlreadyExistsException : Exception
{
    public UserAlreadyExistsException()
        : base("The customer already exists in the system.") { }

    public UserAlreadyExistsException(string message)
        : base(message) { }
}
[Serializable]
public class ProductAlreadyExistsException : Exception
{
    public ProductAlreadyExistsException()
        : base("The prosuct already exists in the system.") { }

    public ProductAlreadyExistsException(string message)
        : base(message) { }
}
/// <summary>
/// חריגה זו נזרקת כאשר מתקבל פרמטר שאינו חוקי, למשל ערך ריק, מספר שלילי, או סוג שגוי.
/// </summary>
[Serializable]
public class InvalidParameterException : Exception
{
    public InvalidParameterException()
        : base("Invalid parameter provided.") { }

    public InvalidParameterException(string message)
        : base(message) { }
}

/// <summary>
/// חריגה זו נזרקת כאשר פריט מבוקש אינו נמצא במערכת.
/// </summary>
[Serializable]
public class ItemNotFoundException : Exception
{
    public ItemNotFoundException()
        : base("The requested item was not found in the system.") { }

    public ItemNotFoundException(string message)
        : base(message) { }
}

/// <summary>
/// חריגה זו נזרקת כאשר מתרחש כשל בעדכון פריט במערכת.
/// </summary>
[Serializable]
public class UpdateFailedException : Exception
{
    public UpdateFailedException()
        : base("Failed to update the item.") { }

    public UpdateFailedException(string message)
        : base(message) { }
}

/// <summary>
/// חריגה זו נזרקת כאשר מתרחש כשל במחיקת פריט במערכת.
/// </summary>
[Serializable]
public class DeleteFailedException : Exception
{
    public DeleteFailedException()
        : base("Failed to delete the item.") { }

    public DeleteFailedException(string message)
        : base(message) { }
}

[Serializable]
public class SaleNotFoundException : Exception
{
    public SaleNotFoundException(string message) : base(message) { }
}
[Serializable]

public class SaleAlreadyExistsException : Exception
{
    public SaleAlreadyExistsException(string message) : base(message) { }
}
