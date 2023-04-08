using System.Text;
namespace InputLib;

public class AuxiliaryMethods
{
    public  string InputIsDigit(string? comment = null)
    {
        if (comment != null)
        {
            Console.WriteLine(comment);
        }

        string input = Console.ReadLine().Trim();

        while (!input.All(c => Char.IsDigit(c)))
        {
            Console.WriteLine(
                $"Ошибка ввода! Строка не должна содержать букв, знаков или других символов. Введите заново!");
            input = Console.ReadLine().Trim();
        }

        return input;
    }
    
    public string ParseOrRerun(string? inputValue)
    {
        int result;
        var parsed = int.TryParse(inputValue, out result);

        if (!parsed)
        {
            Console.WriteLine("Ошибка ввода! Введите заново");
            return ParseOrRerun(Console.ReadLine());
        }

        return result.ToString();
    }
}