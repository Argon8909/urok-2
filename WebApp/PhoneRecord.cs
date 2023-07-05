namespace WebApp;

public class PhoneRecord
{
    public readonly string Name;
    public readonly string Number;
    public readonly string? Adress;

    public PhoneRecord(string name, string number, string? adress = null)
    {
        Name = name;
        Number = number;
        Adress = adress;
    }
}