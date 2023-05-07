//using ДЗ___11___2;

using ДЗ_12;
using EventHandler = ДЗ_12.EventHandler;

static class Program
{
    private static readonly Card TransportCard = new();

    public static void Main()
    {
        for (int i = 0; i < 5; i++)
        {
            TransportCard.OnMoneyOperation += EventHandler.OnMoneyOperationHandler;
            TransportCard.OnCashbackChange += EventHandler.OnCashbackChangeHandler;
            TransportCard.OnNotEnoughMoney += EventHandler.OnNotEnoughMoneyHandler;
            TransportCard.OnErrorOperations += EventHandler.OnErrorOperationsHandler;

            TransportCard.Replenishment(new Random().Next(1, 60));
            TransportCard.Pay(x => x >= 30, 30);
            TransportCard.PrintPaymentsHistory();
            TransportCard.SetCasbackPercent(new Random().Next(1, 50));

            TransportCard.OnMoneyOperation -= EventHandler.OnMoneyOperationHandler;
            TransportCard.OnCashbackChange -= EventHandler.OnCashbackChangeHandler;
            TransportCard.OnNotEnoughMoney -= EventHandler.OnNotEnoughMoneyHandler;
            TransportCard.OnErrorOperations -= EventHandler.OnErrorOperationsHandler;
        }

        Console.ReadKey();
    }
}


/*

*/