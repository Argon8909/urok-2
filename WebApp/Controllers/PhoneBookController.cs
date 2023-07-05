using Microsoft.AspNetCore.Mvc;

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
        string? str = _book.Select(x => x.Name).ToString();
        return str;
    }
}