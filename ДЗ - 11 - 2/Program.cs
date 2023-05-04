//using ДЗ___11___2;

using ДЗ_12;
using EventHandler = ДЗ_12.EventHandler;


static class Program
{
    private static readonly CardNew TransportCard = new();
    
    public static void Main()
    {
        TransportCard.OnMoneyOperation += EventHandler.OnMoneyOperationHandler;
        TransportCard.OnCashbackChange += EventHandler.OnCashbackChangeHandler;
        
        TransportCard.Replenishment(new Random().Next(1, 60));
        TransportCard.Pay(x => x >= 30, 30);
        
        
        
        TransportCard.OnMoneyOperation -= EventHandler.OnMoneyOperationHandler;
        TransportCard.OnCashbackChange -= EventHandler.OnCashbackChangeHandler;
        Console.ReadKey();
        Main();
    }
}


/*
TransportCard.OnPayMessage += ShowOperation;
        TransportCard.Replenishment(new Random().Next(1, 60));
        TransportCard.Pay(x => x >= 30, 30);
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
*/