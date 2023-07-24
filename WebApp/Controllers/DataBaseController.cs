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
        //.Take(7);
        var booksDescription = phoneBooks
            .Select(x => x
                .Name + " " + x
                .Number + " " + x
                .Adress);

        var result = string.Join("\n", booksDescription);
        phoneBooks.First().Name = "Изменено из EF 222";


        var p = dbContext.PhoneBook.Add(new Model.PhoneBook()
        {
            Adress = "EF",
            Number = "98679698679",
            Name = "Asya"
        }).Entity;

        dbContext.SaveChanges();
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