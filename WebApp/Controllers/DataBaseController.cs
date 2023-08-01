using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Model;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class DataBaseController : Controller
{
    [HttpGet]
    [Route("GetAllPeople")]
    public IActionResult GetAllPeople()
    {
        using ApplicationDbContext dbContext = new();

        var peoples = dbContext.people
            //.AsNoTracking()
            .ToList();

        var peoplesDescription = peoples
            .Select(x => x
                .id + " " + x
                .firstname + " " + x
                .lastname + " " + x
                .city);

        var result = string.Join("\n", peoplesDescription);

        return Ok(result);
    }

    [HttpGet]
    [Route("SelectPeople")]
    public IActionResult SelectPeople(string firstname, string? lastName, string? city)
    {
        using ApplicationDbContext dbContext = new ApplicationDbContext();

        var query = dbContext.people.Where(x => x.firstname.Trim().ToLower() == firstname.Trim().ToLower());

        if (!string.IsNullOrEmpty(lastName))
        {
            query = query.Where(x => x.lastname.Trim().ToLower() == lastName.Trim().ToLower());
        }

        if (!string.IsNullOrEmpty(city))
        {
            query = query.Where(x => x.city.Trim().ToLower() == city.Trim().ToLower());
        }

        var peoples = query.ToList();

        var peoplesDescription = peoples.Select(x => $"{x.id} {x.firstname} {x.lastname} {x.city}");

        var result = string.Join("\n", peoplesDescription);

        return Ok(result);
    }


    [HttpPost]
    [Route("InsertToPeople")]
    public IActionResult InsertToPeople(string firstName = "none", string lastName = "none", string city = "none",
        string street = "none", string houseNumber = "none", string phoneNumber = "none")
    {
        var persona = new People
        {
            firstname = firstName.Trim(),
            lastname = lastName.Trim(),
            city = city.Trim(),
            street = street.Trim(),
            housenumber = houseNumber.Trim(),
            phonenumber = phoneNumber.Trim()
        };

        using ApplicationDbContext dbContext = new();
        dbContext.people.Add(persona);
        dbContext.SaveChanges();

        return Ok();
    }

    [HttpPatch]
    [Route("UpdateToPeople")]
    public IActionResult UpdateToPeople(int selectId, string? newFirstName, string? newLastName, string? newCity,
        string? newStreet, string? newHouseNumber, string? newPhoneNumber)
    {
        using ApplicationDbContext dbContext = new();

        var persona = dbContext.people.FirstOrDefault(x => x.id == selectId);
        if (persona == null) return NotFound();

        if (newFirstName != null) persona.firstname = newFirstName.Trim();
        if (newCity != null) persona.city = newCity.Trim();
        if (newStreet != null) persona.street = newStreet.Trim();
        if (newHouseNumber != null) persona.housenumber = newHouseNumber.Trim();
        if (newPhoneNumber != null) persona.phonenumber = newPhoneNumber.Trim();

        dbContext.people.Update(persona);
        dbContext.SaveChanges();

        return Ok(persona);
    }

    [HttpDelete]
    [Route("DeletePeople")]
    public IActionResult DeletePeople(int selectId)
    {
        using ApplicationDbContext dbContext = new();

        var persona = dbContext.people.FirstOrDefault(x => x.id == selectId);
        if (persona != null)
        {
            dbContext.people.Remove(persona);
            dbContext.SaveChanges();
            return Ok();
        }

        return NotFound();
    }
}

/*
  public IActionResult SelectPeople(string firstname, string? city, string? NewLastName)
    {
        using ApplicationDbContext dbContext = new();

        var peoples = dbContext.people.Where(x => x
                .firstname == firstname && x
                .city == city && x
                .lastname == NewLastName)
            //.AsNoTracking()
            .ToList();

        var peoplesDescription = peoples
            .Select(x => x
                .firstname + " " + x
                .lastname + " " + x
                .city);

        var result = string.Join("\n", peoplesDescription);

        return Ok(result);
    }
 
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