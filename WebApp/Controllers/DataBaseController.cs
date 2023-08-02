using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Model;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class DataBaseController : Controller
{
   

    [HttpGet]
    [Route("SelectPeople")]
    public IActionResult SelectPeople(string? firstname, string? lastName, string? city)
    {
        using ApplicationDbContext dbContext = new ApplicationDbContext();
       // var query = dbContext.people.Find();
       if (string.IsNullOrEmpty(firstname)) return BadRequest("Вы должны указать имя!");
        
        var query = dbContext.people
            .Where(x => x
                .firstname
                .Trim()
                .ToLower() == firstname
                .Trim()
                .ToLower());

        if (!string.IsNullOrEmpty(lastName))
        {
            query = query
                .Where(x => x
                    .lastname
                    .Trim()
                    .ToLower() == lastName
                    .Trim()
                    .ToLower());
        }

        if (!string.IsNullOrEmpty(city))
        {
            query = query
                .Where(x => x
                    .city
                    .Trim()
                    .ToLower() == city
                    .Trim()
                    .ToLower());
        }

        var peoples = query.ToList();
        var foundPeopleCount  = peoples.Count;
        
        var peoplesDescription = peoples.Select(x =>
            $"{x.id}\n" +
            $"Last Name: {x.lastname}\n" +
            $"First Name: {x.firstname}\n" +
            $"Phone Number: {x.phonenumber}\n" +
            $"City: {x.city}\n" +
            $"Street: {x.street}\n" +
            $"House Number: {x.housenumber}\n"
        );

        var result = string.Join("\n", peoplesDescription);

        return Ok($"Найдено {foundPeopleCount} человек. " + "\n" + result);
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

        try
        {
            using ApplicationDbContext dbContext = new();
            dbContext.people.Add(persona);
            dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ошибка базы данных: " + ex.Message);
        }


        return Ok();
    }

    [HttpPatch]
    [Route("UpdateToPeople")]
    public IActionResult UpdateToPeople(int selectId, string? newFirstName, string? newLastName, string? newCity,
        string? newStreet, string? newHouseNumber, string? newPhoneNumber)
    {
        using ApplicationDbContext dbContext = new();

        var persona = dbContext.people.FirstOrDefault(x => x.id == selectId);

        if (persona == null) return NotFound("Объект с таким ID не найден!");

        if (!string.IsNullOrEmpty(newFirstName)) persona.firstname = newFirstName.Trim();
        if (!string.IsNullOrEmpty(newLastName)) persona.lastname = newLastName.Trim();
        if (!string.IsNullOrEmpty(newCity)) persona.city = newCity.Trim();
        if (!string.IsNullOrEmpty(newStreet)) persona.street = newStreet.Trim();
        if (!string.IsNullOrEmpty(newHouseNumber)) persona.housenumber = newHouseNumber.Trim();
        if (!string.IsNullOrEmpty(newPhoneNumber)) persona.phonenumber = newPhoneNumber.Trim();

        try
        {
            dbContext.people.Update(persona);
            dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ошибка базы данных: " + ex.Message);
        }


        return Ok(persona);
    }

    [HttpDelete]
    [Route("DeletePeople")]
    public IActionResult DeletePeople(int selectId)
    {
        using ApplicationDbContext dbContext = new();

        try
        {
            var persona = dbContext.people.FirstOrDefault(x => x.id == selectId);
            if (persona != null)
            {
                dbContext.people.Remove(persona);
                dbContext.SaveChanges();
                return Ok(persona.id + "Удалён!");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ошибка базы данных: " + ex.Message);
        }

        return NotFound("Объект с таким ID не найден!");
    }

    [HttpPost]
    [Route("FillingInDb")]
    public IActionResult FillingInDb(int quantity)
    {
        using ApplicationDbContext dbContext = new();
        DataGenerator dataGenerator = new();
        var persones = new List<People>();

        for (int i = 0; i < quantity; i++)
        {
            var persona = new People
            {
                firstname = dataGenerator.GenerateRandomFirstName(),
                lastname = dataGenerator.GenerateRandomLastName(),
                city = dataGenerator.GenerateRandomCity(),
                street = dataGenerator.GenerateRandomStreet(),
                housenumber = dataGenerator.GenerateRandomHouseNumber(),
                phonenumber = dataGenerator.GenerateRandomPhoneNumber()
            };
            persones.Add(persona);
        }

        try
        {
            foreach (var persone in persones)
            {
                dbContext.people.Add(persone);
            }

            dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ошибка базы данных: " + ex.Message);
        }

        return Ok();
    }
}


/*
 // [HttpGet]
   // [Route("GetAllPeople")]
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
                    .city + " " + x
                    .street + " " + x
                    .housenumber + " " + x
                    .phonenumber
            );

        var result = string.Join("\n", peoplesDescription);

        return Ok(result);
    }
 
 
 [HttpPost]
      [Route("FillingInDb")]
      public IActionResult FillingInDb(int quantity)
      {
          using ApplicationDbContext dbContext = new();
          DataGenerator dataGenerator = new();
          var persones = new List<People>();
          
          for (int i = 0; i < quantity; i++)
          {
                var persona = new People
                      {
                          firstname = dataGenerator.GenerateRandomFirstName(),
                          lastname = dataGenerator.GenerateRandomLastName(),
                          city = dataGenerator.GenerateRandomCity(),
                          street = dataGenerator.GenerateRandomStreet(),
                          housenumber = dataGenerator.GenerateRandomHouseNumber(),
                          phonenumber = dataGenerator.GenerateRandomPhoneNumber()
                      };
                persones.Add(persona);
          }
        
  
          try
          {
              foreach (var persone in persones) dbContext.people.Update(persone);
  
              dbContext.SaveChanges();
          }
          catch (Exception ex)
          {
              return StatusCode(500, "Ошибка базы данных: " + ex.Message);
          }
  
          return Ok();
      }
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