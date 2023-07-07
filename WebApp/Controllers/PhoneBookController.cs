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

    private static List<PhoneRecord> _book = new List<PhoneRecord>();


    [HttpGet]
    [Route("GetPhoneBook")]
    public string GetAll()
    {
        // StringBuilder sb = new StringBuilder($"Всего записей {_book.Count} ");
        var str = _book
            .Select(x => x.Name + " " + x.Number + " " + x.Adress);
        var result = string.Join("\n", str);

        Console.WriteLine(result);
        return result;
    }

    [HttpPost]
    [Route("PostPhoneBook")]
    public string PostContact(string name, string number, string? adress = null)
    {
        PhoneRecord record = new PhoneRecord(name, number, adress);
        _book.Add(record);
        return name + " is record" + $"  Всего записей {_book.Count} ";
    }

    [HttpDelete]
    [Route("DeletePhoneBook")]
    public string DeleteContact(string name)
    {
        //var del = _book.Where(x => x.Name == name);

        for (int i = 0; i < _book.Count; i++)
        {
            if (_book[i].Name == name.Trim())
            {
                _book.Remove(_book[i]);
                Console.WriteLine(name + " is delete");
                return name + " is delete";
            }
        }

        return "Not Found :-(";
    }

    [HttpPatch]
    [Route("PatchPhoneBook")]
    public string PatchContact()
    {
        return "";
    }

    [HttpPut]
    [Route("PutPhoneBook")]
    public string PutContact()
    {
        return "";
    }
}