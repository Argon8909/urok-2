namespace ДЗ_2;

/// <summary>
/// Метод расширения для дз. Как применить - не знаю.
/// </summary>
public static class InputParse
{
    private static int ParseStringToInt(this string? inputValue)
    {
        int result;
        bool parsed;

        do
        {
            parsed = int.TryParse(inputValue, out result);
            Console.WriteLine("Wrong input. Try again please");
            inputValue = Console.ReadLine();
        } while (!parsed);

        return result;
    }
}