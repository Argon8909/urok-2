using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class DataBaseController : Controller
{
    [HttpGet]
    [Route("GetAllPhoneBook")]
    public string GetAll()
    {
        using ApplicationDbContext dbContext = new();

        var phoneBooks = dbContext.PhoneBook
            //.AsNoTracking()
            .ToList();

        var booksDescription = phoneBooks
            .Select(x => x
                .Name + " " + x
                .Number + " " + x
                .Adress);

        var result = string.Join("\n", booksDescription);
        
        return result;
    }
    
    [HttpGet]
    [Route("GetAllPeople")]
    public string GetAllPeople()
    {
        using ApplicationDbContext dbContext = new();

        var peoples = dbContext.People
            //.AsNoTracking()
            .ToList();

        var peoplesDescription = peoples
            .Select(x => x
                .FirstName + " " + x
                .LastName + " " + x
                .City);

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