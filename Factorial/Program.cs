/*
namespace Factorial
{
    static class Program
    {
        private const int ArrCapacity = 10;
        private static List<int> Arr = new();
        private static Random _random = new();

        public static async Task Main()
        {
            for (int i = 0; i < ArrCapacity; i++)
            {
                int q = _random.Next(0, 999);
                Arr.Add(q);
            }

            foreach (var val in Arr)
            {
                Console.WriteLine(await CalculateFactorialAsync(val));
            }
        }

        public static async Task<int> CalculateFactorialAsync(int n)
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
}





namespace Factorial
{
    static class Program
    {
        private const int ArrCapacity = 10;
        private static List<int> Arr = new();
        private static Random _random = new();

        public static void Main()
        {
            List<Task> tasks = new List<Task>();

            for (int i = 0; i < ArrCapacity; i++)
            {
                int q = _random.Next(0, 999);
                Arr.Add(q);
            }

            foreach (var val in Arr)
            {
                tasks.Add(Task.Run(() => Console.WriteLine(CalculateFactorialAsync(val))));
            }

            Task.WaitAll(tasks.ToArray());
        }

        public static async Task<int> CalculateFactorialAsync(int n)
        {
            if (n < 0)
                throw new ArgumentException("Входные данные должны быть неотрицательным целым числом.", nameof(n));

            if (n == 0 || n == 1)
                return 1;

            int factorial = 1;
            await Task.Yield();

            for (int i = 2; i <= n; i++)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}
*/

namespace Factorial;

static class Program
{
    // static Queue<PublicTransport> _routeToTheOffice = new();
    //static Stack<PublicTransport> _routeHome = new();

    private const int ArrCapacity = 10;
    private static List<int> Arr = new();
    private static Random _random = new();

    public static void Main()
    {
        List<Task> tasks = new List<Task>();

        for (int i = 0; i < ArrCapacity; i++)
        {
            int q = _random.Next(0, 999);
            Arr.Add(q);
        }
        
        foreach (var VARIABLE in Arr)
        {
            Console.Write(VARIABLE + ", ");
        }

        foreach (var val in Arr)
        {
            tasks.Add(Task.Run(() => Console.WriteLine(CalculateFactorialAsync(val))));
            //tasks.Add(new Task(() => Console.WriteLine(CalculateFactorialAsync(val))));
        }

        

        Task.WaitAll(tasks.ToArray());
    }

    public static async Task<int> CalculateFactorialAsync(int n)
    {
        if (n < 0)
            throw new ArgumentException("Входные данные должны быть неотрицательным целым числом.", nameof(n));

        if (n == 0 || n == 1)
            return 1;

        int factorial = 1;
        await Task.Yield(); // позволяет передать управление обратно вызывающему коду и продолжить выполнение асинхронно

        for (int i = 2; i <= n; i++)
        {
            factorial *= i;
        }

        return factorial;
    }


    public static async Task<int> CalculateFactorialAsync1(int n)
    {
        if (n < 0)
            throw new ArgumentException("The input must be a non-negative integer.", nameof(n));

        if (n == 0 || n == 1)
            return 1;

        int factorial = 1;
        for (int i = 2; i <= n; i++)
        {
            factorial *= i;
            // добавляем небольшую задержку для демонстрации асинхронности
            await Task.Delay(100);
        }

        return factorial;
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
