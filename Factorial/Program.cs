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
        for (int i = 0; i < ArrCapacity; i++)
        {
            int q = _random.Next(0, 999);
            Arr.Add(q);
        }

        foreach (var VARIABLE in Arr)
        {
            Console.Write(VARIABLE + ", ");
        }
    }
}