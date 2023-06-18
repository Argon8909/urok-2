using cancellation_token;
using System;
using System.Collections.Generic;
using System.Threading;

static class Program
{
    static readonly Card TransportCard1 = new(10, 5000, "Card_1");
    static readonly Card TransportCard2 = new(5, 2500, "Card_2");
    public static List<Dictionary<string, decimal>> HistoryAllCard = new();
    private static object _lockObject = new object();

    public static void Main()
    {
        // Создание экземпляров потоков
        Task write_1 = new Task(() => TripSet(TransportCard1, ""));
        Task write_2 = new Task(() =>
        {
            try
            {
                TripSet(TransportCard2, "");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        });
        
        Task read_1 = new Task(() => PrintHistory(""));
        Task read_2 = new Task(() => PrintHistory(""));

        SubscriptionEvent(TransportCard1);
        SubscriptionEvent(TransportCard2);

        write_1.Start();
        write_2.Start();
        Thread.Sleep(3000);
        read_1.Start();
        read_2.Start();

        TransportCard1.PrintPaymentsHistory();
        TransportCard2.PrintPaymentsHistory();

        UnsubscribeEvent(TransportCard1);
        UnsubscribeEvent(TransportCard2);
    }

    static void TripSet(Card card, string item)
    {
        card.RouteToTheOffice = CreatingRoute(card.RouteToTheOffice, item, card.CardName);
        card.Replenishment(new Random().Next(1, 300));
        Trip(card, item);
    }

    static void PrintHistory(string item)
    {
        lock (_lockObject)
        {
            foreach (var history in HistoryAllCard)
            {
                Console.WriteLine($"{item} история операций общая: " + string.Join(", ", history.Keys));
            }
        }
    }

    static void Trip(Card card, string item)
    {
        Console.WriteLine($"{item} Поездка из дома по карте {card.CardName}.");
        while (card.RouteToTheOffice.Count > 0)
        {
            var transport = card.RouteToTheOffice.Dequeue();
            if (!card.Pay(transport.Fare))
            {
                Console.WriteLine($"{item} Дальше пешком -- {card.CardName}!");
                card.RouteToTheOffice.Clear();
                return;
            }

            card.RouteHome.Push(transport);
        }

        Console.WriteLine($"{item} Поездка домой по карте {card.CardName}.");
        while (card.RouteHome.Count > 0)
        {
            if (!card.Pay(card.RouteHome.Pop().Fare))
            {
                card.RouteHome.Clear();
                Console.WriteLine($"{item} Дальше пешком -- {card.CardName}!");
                return;
            }
        }
    }

    static void SubscriptionEvent(Card card)
    {
        card.OnHistoryOperation += EventHandlers.OnHistoryOperationHandler;
        card.OnMoneyOperation += EventHandlers.OnMoneyOperationHandler;
        card.OnNotEnoughMoney += EventHandlers.OnNotEnoughMoneyHandler;
        card.OnErrorOperations += EventHandlers.OnErrorOperationsHandler;
    }

    static void UnsubscribeEvent(Card card)
    {
        card.OnHistoryOperation -= EventHandlers.OnHistoryOperationHandler;
        card.OnMoneyOperation -= EventHandlers.OnMoneyOperationHandler;
        card.OnNotEnoughMoney -= EventHandlers.OnNotEnoughMoneyHandler;
        card.OnErrorOperations -= EventHandlers.OnErrorOperationsHandler;
    }

    static Queue<PublicTransport> CreatingRoute(Queue<PublicTransport> queue, string item, string cardName)
    {
        Random random = new Random();
        int count = random.Next(5, 17); // Генерация случайного числа количества пересадок
        Console.WriteLine($"{item} Составлен маршрут для {cardName}: ");
        for (int i = 0; i < count; i++)
        {
            int randomNumber = random.Next(1, 6);
            PublicTransport transport = null;

            switch (randomNumber)
            {
                case 1:
                    transport = new Bus();
                    break;
                case 2:
                    transport = new Metro();
                    break;
                case 3:
                    transport = new Minibus();
                    break;
                case 4:
                    transport = new Tram();
                    break;
                case 5:
                    transport = new Trolleybus();
                    break;
                default:
                    break;
            }

            if (transport != null)
            {
                queue.Enqueue(transport);
                Console.WriteLine(
                    $"{item} Транспортное средство для {cardName}: {transport.GetType().Name}, № - {transport.ID}");
            }
        }

        Console.WriteLine("");
        return queue;
    }
}