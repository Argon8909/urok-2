namespace WebApp;

public class PhoneRecord
{
    public  string Name;
    public  string Number;
    public  string? Adress;

    public PhoneRecord(string name, string number, string? adress = null)
    {
        Name = name;
        Number = number;
        Adress = adress;
    }
}