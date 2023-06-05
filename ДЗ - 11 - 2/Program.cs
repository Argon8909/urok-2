using System.Collections;
using System.Net.Sockets;
using HV_Lock;
using EventHandler = HV_Lock.EventHandler;

namespace HV_Lock;

static class Program
{
    static readonly Card TransportCard = new();
    static Queue<PublicTransport> _routeToTheOffice = new();
    static Stack<PublicTransport> _routeHome = new();
    static List<Card> _listCards = new();
    static Queue<Card> _queueCard = new();
    public static List<Dictionary<string, decimal>> _historyDictionary = new();

    //private static List<Thread> _threadsOperration = new List<Thread>();


    public static void Main()
    {
        // Создание экземпляров потоков с нужными именами
        Thread read_1 = new Thread(() => PrintHistory("поток 1"));
        Thread read_2 = new Thread(() => PrintHistory("поток 2"));
        Thread write_1 = new Thread(() => Trip("поток 1"));
        Thread write_2 = new Thread(() => Trip("поток 2"));


        SubscriptionEvent(TransportCard);

        write_1.Start();
        write_2.Start();
        Thread.Sleep(3000);
        read_1.Start();
        read_2.Start();

        UnsubscribeEvent(TransportCard);
    }

    static void Trip(string item)
    {
        _routeToTheOffice = CreatingRoute(_routeToTheOffice, item);
        TransportCard.Replenishment(new Random().Next(1, 300));
        Trip(TransportCard, item);
    }

    static void PrintHistory(string item)
    {
        foreach (var history in _historyDictionary)
        {
            Console.WriteLine($"{item} - {history.Keys}");
        }
    }

    static void Trip(Card card, string item)
    {
        Console.WriteLine($"{item} Поездка из дома.");
        while (_routeToTheOffice.Count > 0)
        {
            var transport = _routeToTheOffice.Dequeue();
            if (!card.Pay(transport.Fare))
            {
                Console.WriteLine($"{item} Дальше пешком!");
                _routeToTheOffice.Clear();
                return;
            }

            _routeHome.Push(transport);
        }

        Console.WriteLine($"{item} Поездка домой.");
        while (_routeHome.Count > 0)
        {
            if (!card.Pay(_routeHome.Pop().Fare))
            {
                _routeHome.Clear();
                Console.WriteLine($"{item} Дальше пешком!");
                return;
            }
        }
    }

    static void SubscriptionEvent(Card card)
    {
        card.OnHistoryOperation += EventHandler.OnOnHistoryOperationHandler;
        card.OnMoneyOperation += EventHandler.OnMoneyOperationHandler;
        card.OnCashbackChange += EventHandler.OnCashbackChangeHandler;
        card.OnNotEnoughMoney += EventHandler.OnNotEnoughMoneyHandler;
        card.OnErrorOperations += EventHandler.OnErrorOperationsHandler;
    }

    static void UnsubscribeEvent(Card card)
    {
        card.OnHistoryOperation -= EventHandler.OnOnHistoryOperationHandler;
        card.OnMoneyOperation -= EventHandler.OnMoneyOperationHandler;
        card.OnCashbackChange -= EventHandler.OnCashbackChangeHandler;
        card.OnNotEnoughMoney -= EventHandler.OnNotEnoughMoneyHandler;
        card.OnErrorOperations -= EventHandler.OnErrorOperationsHandler;
    }

    static Queue<PublicTransport> CreatingRoute(Queue<PublicTransport> queue, string item)
    {
        Random random = new Random();
        int count = random.Next(5, 11); // Генерация случайного числа от 5 до 10
        Console.WriteLine($"{item} Составлен маршрут: ");
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
                Console.WriteLine($"{item} Транспортное средство: {transport.GetType().Name}, № - {transport.ID}");
            }
        }

        Console.WriteLine("");
        return queue;
    }
}


/*
 
   // Создание экземпляров потоков с нужными именами
        Thread read_1 = new Thread(ReadOperation);
        Thread read_2 = new Thread(ReadOperation);
        Thread write_1 = new Thread(WriteOperation);
        Thread write_2 = new Thread(WriteOperation);

// Добавление потоков в коллекцию
        _threadsOperration.Add(read_1);
        _threadsOperration.Add(read_2);
        _threadsOperration.Add(write_1);
        _threadsOperration.Add(write_2);
 
 static void QueueInit(Queue queue, int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            // queue.Enqueue (Card TransportCard );
        }
    }
 
   static List<Card> ListInit(List<Card> card, int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            card.Add(new Card());
        }
    }
 
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