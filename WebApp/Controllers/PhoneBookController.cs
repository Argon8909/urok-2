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
        //if (_book.Count == 0) _book = FileSaver.ReadBookFromFile();
        // StringBuilder sb = new StringBuilder($"Всего записей {_book.Count} ");
        CheckingForRepeat();

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
        CheckingForRepeat();

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
    public string PostContact(string name, string number, string adress = "none")
    {
        //if (_book.Count == 0) _book = FileSaver.ReadBookFromFile();
        CheckingForRepeat();
        PhoneRecord record = new PhoneRecord(name.Trim(), number.Trim(), adress.Trim());
        _book.Add(record);
        FileSaver.SaveBookToFile(_book);
        return name + " is record" + $"  Всего записей {_book.Count} ";
    }

    [HttpDelete]
    [Route("DeletePhoneBook")]
    public string DeleteContact(string name)
    {
        CheckingForRepeat();
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
    public string PatchContact(string name, string? newName, string? newNumber, string? newAdress)
    {
        CheckingForRepeat();
        if (_book != null)
        {
            var q = _book.Where(t => t.Name == name.Trim());
            foreach (var t in q)
            {
                if (newName != null) t.Name = newName.Trim();
                if (newNumber != null) t.Number = newNumber.Trim();
                if (newAdress != null) t.Adress = newAdress.Trim();
                FileSaver.SaveBookToFile(_book);
                Console.WriteLine(name + " изменён ");
                return name + " " + Param();
            }
        }

        return name + " is not found :-(";

        string Param()
        {
            StringBuilder sb = new StringBuilder();
            if (newName != null) sb.Append("изменено имя, ");
            if (newNumber != null) sb.Append("изменён номер, ");
            if (newAdress != null) sb.Append("изменён адрес ");
            return sb.ToString();
        }
    }


    [HttpPut]
    [Route("PutPhoneBook")]
    public string PutContact(string name, string newName = "none", string newNumber = "none", string newAdress = "none")
    {
        //if (_book != null && _book.Count == 0) _book = FileSaver.ReadBookFromFile();
        CheckingForRepeat();
        if (_book != null)
            foreach (var t in _book.Where(t => t.Name == name.Trim()))
            {
                t.Name = newName.Trim();
                t.Number = newNumber.Trim();
                t.Adress = newAdress.Trim();
                FileSaver.SaveBookToFile(_book);
                Console.WriteLine(name + " заменён на " + newName);
                return name + " заменён на " + newName;
            }

        return name + " is not found :-(";
    }

    private void CheckingForRepeat()
    {
        if (_book.Count == 0) _book = FileSaver.ReadBookFromFile();
        
         //Если успею, то доделаю
         
        var hasDuplicates = _book
            .GroupBy(x => x
                .Name)
            .Where(x => x
                .Count() > 1)
            .Select(x => x
                .Select(x => x
                    .Name = x
                    .Name + " " + _random
                    .Next(1, 100)));
    }

    private Random _random = new Random();

    private string NameModificator(string name)
    {
        return name + " " + _random.Next(1, 100);
    }
}