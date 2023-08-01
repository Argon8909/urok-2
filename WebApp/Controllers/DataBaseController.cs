using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class DataBaseController : Controller
{
    
    
    [HttpGet]
    [Route("GetAllPeople")]
    public string GetAllPeople()
    {
        using ApplicationDbContext dbContext = new();

        var peoples = dbContext.people
            //.AsNoTracking()
            .ToList();

        var peoplesDescription = peoples
            .Select(x => x
                .firstname + " " + x
                .lastname + " " + x
                .city);

        var result = string.Join("\n", peoplesDescription);
        
        return result;
    }
    

    [HttpPost]
    [Route("PostToPeople")]
    public string PostToPeople(int quantity)
    {
        
        return "OK";
    }
    
}

/*
 phoneBooks.First().Name = "Изменено из EF 222";
  var p = dbContext.PhoneBook.Add(new Model.PhoneBook()
         {
             Adress = "EF",
             Number = "98679698679",
             Name = "Asya"
         }).Entity;
 dbContext.SaveChanges();
 * // GET
    public IActionResult Index()
    {
        return View();
    }
*/