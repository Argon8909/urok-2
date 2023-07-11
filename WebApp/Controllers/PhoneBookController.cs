using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class PhoneBook : Controller
{
    public PhoneBook()
    {
        Console.WriteLine("Вызов конструктора");
    }

    private static List<PhoneRecord>? _book = new List<PhoneRecord>();


    [HttpGet]
    [Route("GetAllPhoneBook")]
    public string GetAll()
    {
        if (_book.Count == 0) _book = FileSaver.ReadBookFromFile();
        // StringBuilder sb = new StringBuilder($"Всего записей {_book.Count} ");
        var str = _book
            .Select(x => x
                .Name + " " + x
                .Number + " " + x
                .Adress);
        var result = string.Join("\n", str);

        Console.WriteLine(result);
        return result;
    }

    [HttpGet]
    [Route("GetContact")]
    public string GetContact(string name)
    {
        if (_book.Count == 0) _book = FileSaver.ReadBookFromFile();

        for (int i = 0; i < _book.Count; i++)
        {
            if (_book[i].Name == name.Trim())
            {
                var contact = _book.Where(x => x.Name == name.Trim()).Select(x => x
                    .Name + " " + x
                    .Number + " " + x
                    .Adress);
                var result = string.Join("\n", contact);
                return result;
            }
        }

        return name + " is not found :-(";
    }

    [HttpPost]
    [Route("PostPhoneBook")]
    public string PostContact(string name, string number, string? adress = null)
    {
        if (_book.Count == 0) _book = FileSaver.ReadBookFromFile();

        PhoneRecord record = new PhoneRecord(name.Trim(), number.Trim(), adress.Trim());
        _book.Add(record);
        FileSaver.SaveBookToFile(_book);
        return name + " is record" + $"  Всего записей {_book.Count} ";
    }

    [HttpDelete]
    [Route("DeletePhoneBook")]
    public string DeleteContact(string name)
    {
        if (_book.Count == 0) _book = FileSaver.ReadBookFromFile();

        for (int i = 0; i < _book.Count; i++)
        {
            if (_book[i].Name == name.Trim())
            {
                _book.Remove(_book[i]);
                Console.WriteLine(name + " is delete");
                FileSaver.SaveBookToFile(_book);
                return name + " is delete";
            }
        }

        return name + " is not found :-(";
    }

    [HttpPatch]
    [Route("PatchPhoneBook")]
    public string PatchContact(string name, string? mewName, string? newNumber, string? newAdress)
    {
        if (_book.Count == 0) _book = FileSaver.ReadBookFromFile();

        for (int i = 0; i < _book.Count; i++)
        {
            if (_book[i].Name == name.Trim())
            {
                if (mewName != null) _book[i].Name = mewName.Trim();
                if (newNumber != null) _book[i].Number = newNumber.Trim();
                if (newAdress != null) _book[i].Adress = newAdress.Trim();
                FileSaver.SaveBookToFile(_book);
                Console.WriteLine(name + " заменён на " + mewName);
                return name + " заменён на " + mewName;
            }
        }

        return name + " is not found :-(";
    }


    [HttpPut]
    [Route("PutPhoneBook")]
    public string PutContact(string name, string mewName = "none", string newNumber = "none", string newAdress = "none")
    {
        if (_book.Count == 0) _book = FileSaver.ReadBookFromFile();

        for (int i = 0; i < _book.Count; i++)
        {
            if (_book[i].Name == name.Trim())
            {
                _book[i].Name = mewName.Trim();
                _book[i].Number = newNumber.Trim();
                _book[i].Adress = newAdress.Trim();
                FileSaver.SaveBookToFile(_book);
                Console.WriteLine(name + " заменён на " + mewName);
                return name + " заменён на " + mewName;
            }
        }

        return name + " is not found :-(";
    }
}