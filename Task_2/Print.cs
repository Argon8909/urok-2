namespace HomeworkGenerics;

public static class Print
{
    public static void PrintInfo(string message, int? val = null)
    {
        Console.WriteLine($"=={message}== >{val}<");
    }
}