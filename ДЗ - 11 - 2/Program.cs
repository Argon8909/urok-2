//using ДЗ___11___2;

using System.Collections;
using System.Net.Sockets;
using ДЗ_12;
using EventHandler = ДЗ_12.EventHandler;

static class Program
{
    // private static readonly Card TransportCard = new();

    static Queue<Card> _queueCard = new();
    static List<Card> _listCards = new();

    public static void Main()
    { 
        //SubscriptionEvent();

       //UnsubscribeEvent();
    }

    static List<Card> ListInit(List<Card> card, int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            card.Add(new Card());
        }
    }

    static void QueueInit(Queue queue, int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            // queue.Enqueue (Card TransportCard );
        }
    }

    static void SubscriptionEvent(Card card)
    {
        card.OnMoneyOperation += EventHandler.OnMoneyOperationHandler;
        card.OnCashbackChange += EventHandler.OnCashbackChangeHandler;
        card.OnNotEnoughMoney += EventHandler.OnNotEnoughMoneyHandler;
        card.OnErrorOperations += EventHandler.OnErrorOperationsHandler;
    }

    static void UnsubscribeEvent(Card card)
    {
        card.OnMoneyOperation -= EventHandler.OnMoneyOperationHandler;
        card.OnCashbackChange -= EventHandler.OnCashbackChangeHandler;
        card.OnNotEnoughMoney -= EventHandler.OnNotEnoughMoneyHandler;
        card.OnErrorOperations -= EventHandler.OnErrorOperationsHandler;
    }
}


/*
 for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("-----------------------------");
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
*/