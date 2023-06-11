namespace TransportCard_Task;


public class PublicTransport
{
    internal Random random = new Random();

    public delegate void TransportTrip(decimal moneyPay, decimal moneyBalance, string message);

    /// <summary>
    /// Событие поездки на траспорте.
    /// </summary>
    public event TransportTrip OnTransportTrip;

    public decimal Fare { get; set; }

    //private byte _number = default;
    public byte ID { get; set; }
}

public class Bus : PublicTransport
{
    public Bus()
    {
        Fare = 40;
        ID = (byte) random.Next(1, 99);
    }
}

public class Metro : PublicTransport
{
    public Metro()
    {
        Fare = 100;
        ID = (byte) random.Next(1, 99);
    }
}

public class Minibus : PublicTransport
{
    public Minibus()
    {
        Fare = 60;
        ID = (byte) random.Next(1, 99);
    }
}

public class Tram : PublicTransport
{
    public Tram()
    {
        Fare = 30;
        ID = (byte) random.Next(1, 99);
    }
}

public class Trolleybus : PublicTransport
{
    public Trolleybus()
    {
        Fare = 35;
        ID = (byte) random.Next(1, 99);
    }
}