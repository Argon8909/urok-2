using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class DataBaseController : Controller
{
    private ApplicationDBbContext _dbContext = new();


    [HttpGet]
    [Route("GetAllPhoneBook")]
    public string GetAll()
    {
        var phoneBook = _dbContext.PhoneBook.ToList();
        var result = string.Join("\n", phoneBook);
        return result;
    }
}

/*
 * // GET
    public IActionResult Index()
    {
        return View();
    }
*/