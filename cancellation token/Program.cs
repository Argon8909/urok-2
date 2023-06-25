using System.Reflection;

namespace cancellation_token;

static class Program
{
    static readonly Card TransportCard1 = new(10, 50, "Card_1");
    static readonly Card TransportCard2 = new(5, 250, "Card_2");
    public static List<Dictionary<string, decimal>> HistoryAllCard = new();

    private static object _lockObject = new object();

/*
    private static CancellationTokenSource _cts = new CancellationTokenSource();
    private static CancellationToken _cancellationToken = _cts.Token;
    
    private static CancellationTokenSource _cts1 = new CancellationTokenSource();
    private static CancellationToken _token1 = _cts1.Token;
    
    private static CancellationTokenSource _cts2 = new CancellationTokenSource();
    private static CancellationToken _token2 = _cts2.Token;
*/
    // Создание общего токена отмены
    static CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
    static CancellationToken cancellationToken = cancellationTokenSource.Token;

// Создание отдельных токенов отмены для каждой задачи
    static CancellationTokenSource cancellationTokenSource1 =
        CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

    static CancellationToken cancellationToken1 = cancellationTokenSource1.Token;

    static CancellationTokenSource cancellationTokenSource2 =
        CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

    static CancellationToken cancellationToken2 = cancellationTokenSource2.Token;


    public static void Main()
    {
        SubscriptionEvent(TransportCard1);
        SubscriptionEvent(TransportCard2);
        
        Task readKeyBoard = Task.Run(() =>
        {
            OnStopWordOperation += StopWordHandler;

            while (true)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine("Процесс ввода команд остановлен!");
                    break;
                }

                Console.WriteLine("Введите команду  ");
                var stopWord = Console.ReadLine();
                if (stopWord != null) OnStopWordOperation?.Invoke(stopWord.Trim().ToLower());
            }

            OnStopWordOperation -= StopWordHandler;
        }, cancellationToken);

        Thread.Sleep(8000);

        // Создание экземпляров потоков
        Task write1 = Task.Run(() =>
        {
            //cancellationToken1.ThrowIfCancellationRequested();

            try
            {
                TripSet(TransportCard1, cancellationToken1, "");
            }
            // catch (OperationCanceledException)
            // {
            // Обработка отмены задачи 
            // Console.WriteLine("Задача 1 отменена.");
            // }
            catch (Exception e)
            {
                Console.WriteLine("Обработка исключения по карте №-1");
                Console.WriteLine(e);
            }
        }, cancellationToken1);

        Task write2 = Task.Run(() =>
        {
            //cancellationToken2.ThrowIfCancellationRequested();

            try
            {
                TripSet(TransportCard2, cancellationToken2, "");
            }
            //catch (OperationCanceledException)
            //{
            // Обработка отмены задачи 
            //  Console.WriteLine("Задача 2 отменена.");
            //}
            catch (Exception e)
            {
                Console.WriteLine("Обработка исключения по карте №-2");
                Console.WriteLine(e);
            }
        }, cancellationToken2);

        Thread.Sleep(8000);

        Task read1 = Task.Run(() => PrintHistory(cancellationToken1, ""), cancellationToken1);
        Task read2 = Task.Run(() => PrintHistory(cancellationToken2, ""), cancellationToken2);

        //SubscriptionEvent(TransportCard1);
        //SubscriptionEvent(TransportCard2);

        //write1.Start();
        //write2.Start();
        //Thread.Sleep(3000);
        //read1.Start();
        //read2.Start();

        TransportCard1.PrintPaymentsHistory();
        TransportCard2.PrintPaymentsHistory();

        UnsubscribeEvent(TransportCard1);
        UnsubscribeEvent(TransportCard2);
    }

    static void StopWordHandler(string stopWord)
    {
        Console.WriteLine("stopWord --->" + stopWord);
        switch (stopWord)
        {
            case "stop":
                cancellationTokenSource.Cancel();
                break;
            case "stop1":
                cancellationTokenSource1.Cancel();
                break;
            case "stop2":
                cancellationTokenSource2.Cancel();
                break;
        }
    }

    static void TripSet(Card card, CancellationToken cancellationToken, string item)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            // Получаем информацию о текущем методе
            MethodBase? currentMethod = MethodBase.GetCurrentMethod();

            // Получаем имя текущего метода
            string methodName = currentMethod.Name;

            Console.WriteLine($"Выполнение метода {methodName} остановлено!"); // Операция была отменена
            return;
        }

        card.RouteToTheOffice = CreatingRoute(card.RouteToTheOffice, cancellationToken, item, card.CardName) ?? throw new InvalidOperationException();
        card.Replenishment(new Random().Next(1, 300));
        Trip(card, cancellationToken, item);
    }

    static void PrintHistory(CancellationToken cancellationToken, string item)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            // Получаем информацию о текущем методе
            MethodBase? currentMethod = MethodBase.GetCurrentMethod();

            // Получаем имя текущего метода
            string methodName = currentMethod.Name;

            Console.WriteLine($"Выполнение метода {methodName} остановлено!"); // Операция была отменена
            return;
        }

        lock (_lockObject)
        {
            foreach (var history in HistoryAllCard)
            {
                Console.WriteLine($"{item} история операций общая: " + string.Join(", ", history.Keys));
            }
        }
    }

    static void Trip(Card card, CancellationToken cancellationToken, string item)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            // Получаем информацию о текущем методе
            MethodBase? currentMethod = MethodBase.GetCurrentMethod();

            // Получаем имя текущего метода
            string methodName = currentMethod.Name;

            Console.WriteLine($"Выполнение метода {methodName} остановлено!"); // Операция была отменена
            return;
        }

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

    static Queue<PublicTransport>? CreatingRoute(Queue<PublicTransport> queue, CancellationToken cancellationToken,
        string item, string cardName)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            // Получаем информацию о текущем методе
            MethodBase? currentMethod = MethodBase.GetCurrentMethod();

            // Получаем имя текущего метода
            string methodName = currentMethod.Name;

            Console.WriteLine($"Выполнение метода {methodName} остановлено!"); // Операция была отменена
            return null;
        }

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

    public delegate void StopWordOperation(string stopWord);

    /// <summary>
    /// Событие иввода стоп-слова.
    /// </summary>
    public static event StopWordOperation? OnStopWordOperation;
}

/*
 Task write1 = new Task(() =>
        {
            cancellationToken1.ThrowIfCancellationRequested();

            try
            {
                TripSet(TransportCard1, cancellationToken1, "");
            }
            catch (OperationCanceledException)
            {
                // Обработка отмены задачи 
                Console.WriteLine("Задача 1 отменена.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Обработка исключения по карте №-1");
                Console.WriteLine(e);
            }
        }, cancellationToken1);

        Task write2 = new Task(() =>
        {
            cancellationToken2.ThrowIfCancellationRequested();

            try
            {
                TripSet(TransportCard2, cancellationToken2, "");
            }
            catch (OperationCanceledException)
            {
                // Обработка отмены задачи 
                Console.WriteLine("Задача 2 отменена.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Обработка исключения по карте №-2");
                Console.WriteLine(e);
            }
        }, cancellationToken2);
 
 Task write1 = new Task(() =>
        {
            _cancellationToken.ThrowIfCancellationRequested();

            try
            {
                TripSet(TransportCard1, _cancellationToken, "");
            }
            catch (OperationCanceledException)
            {
                // Обработка отмены задачи 
                Console.WriteLine("Задача 1 отменена.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Обработка исключения по карте №-1");
                Console.WriteLine(e);
            }
        }, _cancellationToken);


        Task write2 = new Task(() =>
        {
            _cancellationToken.ThrowIfCancellationRequested();

            try
            {
                TripSet(TransportCard2, _cancellationToken, "");
            }
            catch (OperationCanceledException)
            {
                // Обработка отмены задачи 
                Console.WriteLine("Задача 2 отменена.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Обработка исключения по карте №-2");
                Console.WriteLine(e);
            }
        }, _cancellationToken);
 
 
 *  Task write2 = new Task(() =>
        {
            try
            {
                TripSet(TransportCard2, _cancellationToken, "");
            }
            catch (Exception e)
            {
                Console.WriteLine("Обработка исключения по карте №-2");
                Console.WriteLine(e);
            }
        }, _cancellationToken);
*/