namespace Factorial;

static class Program
{
    private static List<Task> _tasks = new List<Task>();

    private const int ArrCapacity = 10;
    private static List<int> Arr = new();
    private static Random _random = new();

    public static void Main()
    {
       // List<Task> tasks = new List<Task>();
       _tasks.Add(() => new Task());
       
       
        for (int i = 0; i < ArrCapacity; i++)
        {
            int q = _random.Next(0, 999);
            Arr.Add(q);
        }

        foreach (var integer in Arr)
        {
            Console.Write(integer + ", ");
        }


/*
        foreach (var val in Arr)
        {
            tasks.Add(Task.Run(() => Console.WriteLine(CalculateFactorialAsync(val))));
            //tasks.Add(new Task(() => Console.WriteLine(CalculateFactorialAsync(val))));
        }
*/


        // Task.WaitAll(tasks.ToArray());
    }

    static void TasksdDistributor(List<int> arr)
    {
        Queue<int> queueIntegerToFactorial = new();
        foreach (var integer in arr)
        {
           queueIntegerToFactorial.Enqueue(integer); 
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