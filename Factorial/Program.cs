using System.Diagnostics;

namespace Factorial;

/*
 * Написать программу. Дан список чисел(одномерный массив). Нужно в количестве равном N создать таски, внутри которых
 * будет расчет факториалов для каждого числа из заданного списка. То есть параллельно пробежаться по списку чисел и
 * распораллелить вычисление факториалов. Измерить время выполнения для однопоточной обработки списка(N=1) и для N=4(степень параллелизма) 
 */
static class Program
{
    private static Stopwatch _stopwatch = new Stopwatch();
    private static List<Task> _tasks = new List<Task>();
    private static int TaskQuantity = 4;
    private const int ArrCapacity = 25;
    private static List<int> Arr = new();
    private static Random _random = new();
    private static Queue<int> _queueIntegerToFactorial = new();

    public static void Main()
    {
        Stopwatch stopwatch = new Stopwatch();

        // Запуск секундомера
        stopwatch.Start();
        QueueGen();
        TasksGen();
        TaskStart();
        Task.WaitAll(_tasks.ToArray());
        // Остановка секундомера
        stopwatch.Stop();

        // Получение прошедшего времени
        TimeSpan elapsedTime = stopwatch.Elapsed;

        Console.WriteLine($"Время выполнения задачи с помощью {TaskQuantity} тасок: " + elapsedTime);

        stopwatch.Reset();

        TaskQuantity = 1;
        _tasks.Clear();
        // Запуск секундомера
        stopwatch.Restart();
        QueueGen();
        TasksGen();
        TaskStart();
        Task.WaitAll(_tasks.ToArray());
        // Остановка секундомера
        stopwatch.Stop();

        // Получение прошедшего времени
        elapsedTime = stopwatch.Elapsed;

        Console.WriteLine($"Время выполнения задачи с помощью {TaskQuantity} тасок: " + elapsedTime);
    }

    static void TaskStart()
    {
        foreach (var task in _tasks)
        {
            task.Start();
        }
    }

    static void TasksGen()
    {
        for (int i = 0; i < TaskQuantity; i++)
        {
            int i1 = i;
            //_tasks.Add(new Task(() => TasksWorker(i1)));
            _tasks.Add(new Task(() => TasksWorker(i1), TaskCreationOptions.LongRunning));
        }
    }

    static void QueueGen()
    {
        for (int i = 0; i < ArrCapacity; i++)
        {
            int q = _random.Next(0, 10);
            //Arr.Add(q);
            _queueIntegerToFactorial.Enqueue(q);
            Console.Write(q + ", ");
        }

        Console.WriteLine("");
    }

    static void TasksWorker(int i)
    {
        Console.WriteLine($"Task {i} start");
        while (_queueIntegerToFactorial.TryDequeue(out int x))
        {
            Console.WriteLine($"i = {i} : " + CalculateFactorial(x));
        }
    }

    public static int CalculateFactorial(int n)
    {
        if (n < 0)
            throw new ArgumentException("Входные данные должны быть неотрицательным целым числом.", nameof(n));

        if (n == 0 || n == 1)
            return 1;

        int factorial = 1;

        for (int i = 2; i <= n; i++)
        {
            factorial *= i;
        }

        return factorial;
    }
}