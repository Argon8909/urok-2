
Main();

void Main()
{
    Console.WriteLine("Введите первое число");
    double input1 = ParseOrRerun(Console.ReadLine());

    Console.WriteLine("Введите второе число");
    double input2 = ParseOrRerun(Console.ReadLine());

    Console.WriteLine("Результат:");
    Console.WriteLine($"Сложение:  {input1} + {input2} = {input1 + input2}");
    Console.WriteLine($"Вычитание: {input1} - {input2} = {input1 - input2}");
    Console.WriteLine($"Умножение: {input1} * {input2} = {input1 * input2}");
    Console.WriteLine($"Деление:   {input1} / {input2} = {input1 / input2}");
}


double ParseOrRerun(string? inputValue)
{
    double result;
    var parsed = double.TryParse(inputValue, out result);

    if (!parsed)
    {
        Console.WriteLine("Ошибка ввода! Введите заново");
        Main();
    }

    return result;
}