namespace cancellation_token;

public class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message) : base(message)
    {
    }
}

public class ExcessiveBalanceException : Exception
{
    public ExcessiveBalanceException(string message) : base(message)
    {
    }
}