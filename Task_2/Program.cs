// See https://aka.ms/new-console-template for more information

string consolRead;

Console.WriteLine("Введите выражение");
consolRead = Console.ReadLine();
Console.WriteLine(ReadValue(consolRead));
Console.ReadKey();

string ReadValue(string value)
{
    string output = "";
    value = value.Replace(",", ".").Replace(" ", "");


    foreach (char C in value)
    {
        if (Char.IsNumber(C))
        {
            output += C;
        }
    }

    string[] words = value.Split(new char[] {'+', '-', '/', '*'});
    
    foreach (string C in words)
    {
        Console.WriteLine(C);
    }

    return output;
}

/*
foreach (string VAR in Chars)
    {
        value = value.Replace(VAR, "");
    }

for (int i = 0; i <= value.Length; i++)
    {
        char VAR = value[i];

        if (VAR != '0' || VAR != '1' || VAR != '2' || VAR != '3' || VAR != '4' || VAR != '5' || VAR != '6' ||
            VAR != '7' || VAR != '8' || VAR != '9' ||
            VAR != '+' || VAR != '-' || VAR != '*' || VAR != '/')
        {
            VAR = ' ';
        }

        value[i] = VAR;

    } 
    
    */