using Microsoft.AspNetCore.Mvc;
using System.Text;
namespace WebApp.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class PhoneBook : Controller
{
    private List<PhoneRecord> _book = new List<PhoneRecord>();


    [HttpGet]
    [Route("GetPhoneBook")]
    public string GetAll()
    {
        StringBuilder sb = new StringBuilder("Запись: ");
        // var str = _book
           // .Select(x => x.Name).ToString();
           foreach (var record in _book)
           {
               sb.Append(record.Name + record.Number + record.Adress + "\n");
           }

        return sb.ToString();
    }

    [HttpPost]
    [Route("PostPhoneBook")]
    public string PostContact(string name, string number, string? adress = null)
    {
        PhoneRecord record = new PhoneRecord(name, number, adress);
        _book.Add(record);
        return name + " is record";
    }

    [HttpDelete]
    [Route("DeletePhoneBook")]
    public string DeleteContact(string name)
    {
        //var del = _book.Where(x => x.Name == name);

        for (int i = 0; i < _book.Count; i++)
        {
            if (_book[i].Name == name)
            {
                _book.Remove(_book[i]);
            }

            return name + " Delete";
        }

        return "Not Found :-(";
    }
}