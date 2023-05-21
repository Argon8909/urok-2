namespace ДЗ___11___2;

public class PublicTransport
{
    public int Fare { get; private set; }
}

public class Bus : PublicTransport
{
    public Bus()
    {
        Fare = 40;
    }
}