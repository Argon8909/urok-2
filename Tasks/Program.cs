namespace Tasks;

using Tasks;

static class Program
{
    static readonly Card TransportCard = new();
    static Queue<PublicTransport> _routeToTheOffice = new();
    static Stack<PublicTransport> _routeHome = new();
    public static List<Dictionary<string, decimal>> _historyDictionary = new();


    public static void Main()
    {
        // Создание экземпляров потоков
        Task read_1 = new Task(() => PrintHistory("поток 1 =>"));
        Task read_2 = new Task(() => PrintHistory("поток 2 =>"));
        Task write_1 = new Task(() => Trip("поток 1 =>"));
        Task write_2 = new Task(() => Trip("поток 2 =>"));


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
            // Console.WriteLine($"{item} - {history.Keys}");
            Console.WriteLine($"{item} история операций: " + string.Join(", ", history.Keys));
        }
    }

    static object lockObject = new object();

    static void Trip(Card card, string item)
    {
        Console.WriteLine($"{item} Поездка из дома.");
        lock (lockObject)
        {
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
        }

        Console.WriteLine($"{item} Поездка домой.");
        lock (lockObject)
        {
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
    }

    [Obsolete]
    static void Trip1(Card card, string item)
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
        card.OnHistoryOperation += EventHandlers.OnHistoryOperationHandler;
        card.OnMoneyOperation += EventHandlers.OnMoneyOperationHandler;
        card.OnCashbackChange += EventHandlers.OnCashbackChangeHandler;
        card.OnNotEnoughMoney += EventHandlers.OnNotEnoughMoneyHandler;
        card.OnErrorOperations += EventHandlers.OnErrorOperationsHandler;
    }

    static void UnsubscribeEvent(Card card)
    {
        card.OnHistoryOperation -= EventHandlers.OnHistoryOperationHandler;
        card.OnMoneyOperation -= EventHandlers.OnMoneyOperationHandler;
        card.OnCashbackChange -= EventHandlers.OnCashbackChangeHandler;
        card.OnNotEnoughMoney -= EventHandlers.OnNotEnoughMoneyHandler;
        card.OnErrorOperations -= EventHandlers.OnErrorOperationsHandler;
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