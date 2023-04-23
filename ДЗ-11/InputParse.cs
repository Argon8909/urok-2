namespace ДЗ_11;

public static class InputParse
{
    private static int ParseStringToInt(string inputValue)
    {
        int result;
        var parsed = int.TryParse(inputValue, out result);

        if (!parsed)
        {
            Console.WriteLine("Wrong input. Try again please");
        }

        return result;
    }
}