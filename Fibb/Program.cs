
Console.WriteLine(ReturnTuple(10));
Console.WriteLine(Fibonacci(10));


int Fibonacci(int n)
{
    if (n == 0)
    {
        return 0;
    }
    else if (n == 1)
    {
        return 1;
    }
    else
    {
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }
}

(int, int) ReturnTuple(int n)
{
    int x = n * n;
    int y = n + n;
    
    return (x, y);
}