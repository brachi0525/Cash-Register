namespace BO;

/// <summary>
/// חריגה זו נזרקת כאשר לקוח אינו נמצא במערכת.
/// </summary>
[Serializable]
public class BlClientDoesNotExistException : Exception
{
    public BlClientDoesNotExistException()
        : base("The client does not exist.") { }

    public BlClientDoesNotExistException(string message, Exception innerException)
        : base(message, innerException) { }
}

/// <summary>
/// חריגה זו נזרקת כאשר קוד שסופק אינו תקף או אינו קיים במערכת.
/// </summary>
[Serializable]
public class BlInvalidCodeException : Exception
{
    // ברירת מחדל - הודעה קבועה
    public BlInvalidCodeException()
        : base("The provided code is not valid.") { }

    // הודעה מותאמת אישית
    public BlInvalidCodeException(string message)
        : base(message) { }

    // הודעה מותאמת + שגיאה פנימית
    public BlInvalidCodeException(string message, Exception innerException)
        : base(message, innerException) { }
}

/// <summary>
/// חריגה זו נזרקת כאשר מוצר מסוים אינו נמצא במערכת.
/// </summary>
[Serializable]
public class BlProductDoesNotExistException : Exception
{
    public BlProductDoesNotExistException()
        : base("The product does not exist.") { }

    public BlProductDoesNotExistException(string? message) : base(message)
    {
    }

    public BlProductDoesNotExistException(string message, Exception innerException)
        : base(message, innerException) { }
}

/// <summary>
/// חריגה זו נזרקת כאשר אין מספיק מלאי למוצר מסוים.
/// </summary>
[Serializable]
public class BlOutOfStockException : Exception
{
    public BlOutOfStockException()
        : base("Not enough stock available.") { }

    public BlOutOfStockException(string? message) : base(message)
    {
    }

    public BlOutOfStockException(string message, Exception innerException)
        : base(message, innerException) { }
}
[Serializable]

public class BlErrorInReed : Exception
{
    public BlErrorInReed()
        : base("can't raed.") { }

    public BlErrorInReed(string message)
        : base(message) { }
}
[Serializable]
public class BlUpdateFailedException : Exception
{
    public BlUpdateFailedException()
        : base("The product does not exist.") { }

    public BlUpdateFailedException(string? message) : base(message)
    {
    }

    public BlUpdateFailedException(string message, Exception innerException)
        : base(message, innerException) { }
}


[Serializable]
public class BlException : Exception
{
    public BlException()
        : base("Error in Bl.") { }

    public BlException(string? message) : base(message)
    {
    }

    public BlException(string message, Exception innerException)
        : base(message, innerException) { }
}

[Serializable]

public class BlProductAlreadyExistsException : Exception
{
    public BlProductAlreadyExistsException()
        : base("The prosuct already exists in the system.") { }

    public BlProductAlreadyExistsException(string message)
        : base(message) { }
}

[Serializable]
public class BlProductNotFoundException : Exception
{
    public BlProductNotFoundException(string message) : base(message) { }
}