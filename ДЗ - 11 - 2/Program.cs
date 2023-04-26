using ДЗ___11___2;

static class Program
{
    private static readonly Card TransportCard = new Card();

    public static void Main()
    {
        TransportCard.OnPayMessage += ShowOperation;
        TransportCard.Replenishment(new Random().Next(1, 60));
        TransportCard.Pay(x => x >= 30);
        Console.WriteLine($"Кешбек: {TransportCard.GetCashback()} р.");
        Console.WriteLine("История платежей:");

        foreach (var payment in TransportCard.PaymentsHistory)
        {
            Console.WriteLine(payment);
        }

        void ShowOperation(string message)
        {
            Console.WriteLine(message);
        }

        Console.WriteLine("");
        Console.ReadKey();
        TransportCard.OnPayMessage -= ShowOperation;
        Main();
    }
}


/*

*/