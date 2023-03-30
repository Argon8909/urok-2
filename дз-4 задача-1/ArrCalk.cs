namespace дз_4;

using System.Text;

public class ArrCalk
{
    public string Input(string? comment = null)
    {
        if (comment != null)
        {
            Console.WriteLine(comment);
        }

        string input = Console.ReadLine().Trim();

        while (!input.All(c => Char.IsDigit(c) || c == ' '))
        {
            Console.WriteLine(
                $"Ошибка ввода! Строка не должна содержать букв, знаков или других символов. Введите заново!");
            input = Console.ReadLine().Trim();
        }

        return input;
    }

    public void OutputResult(int[] Arr)
    {
        Print(SumElement(Arr), "Сумма всех элементов массива =");
        Print(ArithmeticMiddle(Arr), "Среднее арифметическое всех элементов массива =");
        Print(MinElement(Arr), "Минимальный элемент массива =");
        Print(EvenSum(Arr), "Количество чётных элементов массива =");
        Print(OutArrConvert(Positiv(Arr)), "Вывод положительных элементов массива =");
    }

    public void Print(object val, string comment)
    {
        Console.WriteLine($"{comment} {val}");
    }

    public string OutArrConvert(int[] arr)
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("[");

        foreach (int element in arr)
        {
            if (element > 0)
            {
                sb.Append(element.ToString());
                sb.Append(", ");
            }
        }

        if (sb.Length > 2)
        {
            sb.Length -= 2;
        }

        sb.Append("]");

        return sb.ToString();
    }

    public int[] Positiv(int[] A)
    {
        int[] B = new int[A.Length];
        int count = 0;

        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] > 0)
            {
                B[count] = A[i];
                count++;
            }
        }

        return B;
    }

    public int EvenSum(int[] arr)
    {
        int even = 0;
        foreach (var var in arr)
        {
            if (var % 2 == 0)
            {
                even++;
            }
        }

        return even;
    }

    public int MinElement(int[] arr)
    {
        int min = 0;
        if (arr.Length > 0)
        {
            min = arr[0];
        }
        else
        {
            Console.WriteLine("Ошибка!!! Массив пустой!!!");
            return 0;
        }

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] < min)
            {
                min = arr[i];
            }
        }

        return min;
    }

    public double ArithmeticMiddle(int[] arr)
    {
        double sum = SumElement(arr);
        return sum / arr.Length;
    }


    public int SumElement(int[] arr)
    {
        int sum = 0;

        foreach (int element in arr)
        {
            sum += element;
        }

        return sum;
    }

    public int ParseOrRerun(string? inputValue)
    {
        int result;
        var parsed = int.TryParse(inputValue, out result);

        if (!parsed)
        {
            Console.WriteLine("Ошибка ввода! Введите заново");
            return ParseOrRerun(Console.ReadLine());
        }

        return result;
    }
}