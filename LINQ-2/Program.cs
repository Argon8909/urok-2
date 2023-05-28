using LINQ_2;


Task_1();

//Task_2();

//Task_3();


/*
 *  Дано целое число K (> 0) и целочисленная последовательность A. Найти теоретико-множественную
разность двух фрагментов A: первый содержит все четные числа, а второй — все числа с порядковыми
номерами, большими K. В полученной последовательности (не содержащей одинаковых элементов)
поменять порядок элементов на обратный.
 */
void Task_1()
{
    Console.WriteLine("========Первая часть==================================");
    int K = 7;
    var A = new List<int>()
    {
        200, 3, 44, 86, 7, 9, 6, 9, 4, 8, 6, 10, 3, 13, 4, 55, 4, 86, 4, 14, 6, 3, 13, 44, 6, 2, 3, 8, 6, 7, 9, 6, 3, 12,
        5,
        6
    };
    Console.WriteLine($"==========изначальное================= K == {K}");
    foreach (var number in A)
    {
        Console.Write(number + ", ");
    }

    Console.ForegroundColor = ConsoleColor.Green;
    var A11 = A
        .Where(x => x % 2 == 0);
    
    Console.WriteLine("===Чётные====");
    foreach (var VARIABLE in A11)
    {
        Console.Write($"{VARIABLE} ");
    }
    Console.ForegroundColor = ConsoleColor.Yellow;
    var A22 = A.Where((x, i) => { return i > K; });
    
    Console.WriteLine("===Больше К===");

    foreach (var VARIABLE in A22)
    {
        Console.Write($"{VARIABLE} ");
    }


    var A1 = A11.Except(A22)
        .Distinct()
        .Reverse()
        .ToList();


    Console.WriteLine("\n=============Итог=====================");

    foreach (var number in A1)
    {
        Console.Write(number + ", ");
    }
}

/*
 * Даны целые числа K1 и K2 и целочисленные последовательности A и B. Получить последовательность,
содержащую все числа из A, большие K1, и все числа из B, меньшие K2. Отсортировать полученную
последовательность по возрастанию.
 */
void Task_2()
{
    Console.WriteLine(@"

========Вторая часть==================================");

    int K1 = 20;
    int K2 = 15;

    var a = new List<int>() {2, 3, 4, 63, 7, 9, 6, 97, 54, 8, 6, 10, 33, 173, 4, 55, 47,};
    var b = new List<int>() {13, 6, 55, 4, 86, 1, 14, 0, 2, 13, 4, 3, 2, 1, 8, 10, 7, 9, 6, 5, 12, 5, 6};

    Console.WriteLine(@$"========Дано:=====================
K1 - {K1}, K2 - {K2}");
    Console.WriteLine(@"========Последовательность а ==================================");

    foreach (var number in a)
    {
        Console.Write(number + ", ");
    }

    Console.WriteLine(@"
========Последовательность b ==================================");
    foreach (var number in b)
    {
        Console.Write(number + ", ");
    }

    var ab = a
        .Where(x => x > K1)
        .Union(b.Where(x => x < K2))
        .OrderBy(x => x)
        .ToList();

    Console.WriteLine(@"
========Последовательность итоговая ==================================");

    foreach (var number in ab)
    {
        Console.Write(number + ", ");
    }
}

/*
 *  Исходная последовательность содержит сведения об абитуриентах. Каждый элемент
последовательности включает следующие поля:
<Фамилия> <Год поступления> <Номер школы>
 */
void Task_3()
{
    Console.WriteLine(@"

========Третяя часть==================================");

    var abiturients = new List<Abiturient>();
//var schools = new List<School>();

    abiturients.Add(new Abiturient() {LastName = "Иванов", Year = 2020, SchoolNum = 10});
    abiturients.Add(new Abiturient() {LastName = "Петров", Year = 2022, SchoolNum = 15});
    abiturients.Add(new Abiturient() {LastName = "Сидоров", Year = 2019, SchoolNum = 10});
    abiturients.Add(new Abiturient() {LastName = "Ткачёв", Year = 2021, SchoolNum = 15});
    abiturients.Add(new Abiturient() {LastName = "Мишустин", Year = 2020, SchoolNum = 7});
    abiturients.Add(new Abiturient() {LastName = "Медведев", Year = 2021, SchoolNum = 15});
    abiturients.Add(new Abiturient() {LastName = "Чубайс", Year = 2022, SchoolNum = 15});
    abiturients.Add(new Abiturient() {LastName = "Кудрин", Year = 2020, SchoolNum = 10});
    abiturients.Add(new Abiturient() {LastName = "Зюганов", Year = 2019, SchoolNum = 7});
    abiturients.Add(new Abiturient() {LastName = "Кличко", Year = 2019, SchoolNum = 9});

    Console.WriteLine("Список абитуриентов");
    foreach (var var in abiturients)
    {
        Console.WriteLine($@"Абитуриент: {var.SchoolNum}, {var.Year}, {var.LastName}");
    }

    var abitEnum = abiturients
        .GroupBy(x => x.SchoolNum)
        .Select(x => x
            .OrderBy(o => o.Year))
        .Select(x => new School()
        {
            SchoolNum = x
                .First().SchoolNum,
            Quantity = x
                .Count(),
            LastName = x
                .First().LastName
        });


    Console.WriteLine("Список абитуриентов");
    foreach (var school in abitEnum)
    {
        Console.WriteLine(
            $@"номер школы: {school.SchoolNum}, всего учеников: {school.Quantity}, фамилия первого ученика: {school.LastName}");
    }
}