using Microsoft.AspNetCore.Mvc;
using Self_burning_message.Models;


namespace Self_burning_message.Controllers;

[ApiController]
[Route("api/messages")]
public class MessageController : ControllerBase
{
    private static readonly List<Message> Messages = new List<Message>();

    [HttpPost]
    [Route("CreateMessage")]
    public IActionResult CreateMessage(Message message)
    {
        // Генерируем уникальную ссылку для сообщения
        message.uniquelink = Guid.NewGuid().ToString();
        message.isread = false;

        // Добавляем сообщение в список
        Messages.Add(message);
        Console.WriteLine("Сообщение: " + message.content);
        Console.WriteLine("Линк: " + message.uniquelink);
        Console.WriteLine("Всего сообщений " + Messages.Count);
        // Возвращаем уникальную ссылку
        return Ok(message.uniquelink);
    }

    [HttpPost]
    [Route("CreateMessageToDb")]
    public IActionResult CreateMessageToDb(Message message)
    {
        // Генерируем уникальную ссылку для сообщения
        message.uniquelink = Guid.NewGuid().ToString();
        message.isread = false;

        // Добавляем сообщение в список
        Messages.Add(message);

        using ApplicationDbContext dbContext = new();
        dbContext.messages.Add(message);
        dbContext.SaveChanges();

        Console.WriteLine("Сообщение: " + message.content);
        Console.WriteLine("Линк: " + message.uniquelink);
        Console.WriteLine("Всего сообщений " + Messages.Count);
        // Возвращаем уникальную ссылку
        return Ok(message.uniquelink);
    }


    [HttpGet]
    [Route("GetMessage")]
    public IActionResult GetMessage(string link)
    {
        // Находим сообщение по уникальной ссылке
        var message = Messages.FirstOrDefault(m => m.uniquelink == link);

        if (message == null)
        {
            return NotFound();
        }

        // Если сообщение не прочитано, отмечаем его как прочитанное
        if (!message.isread)
        {
            message.isread = true;
        }

        Console.WriteLine("Сообщение выдано: " + message.content);
        //Console.WriteLine("Линк: " + message.uniquelink);

        // Удаляем сообщение из списка (самоуничтожение)
        Messages.Remove(message);
        Console.WriteLine("Всего сообщений " + Messages.Count);
        // Возвращаем содержимое сообщения
        return Ok(message.content);
    }

    [HttpGet]
    [Route("GetMessageFromDb")]
    public IActionResult GetMessageFromDb(string link)
    {
        // Находим сообщение по уникальной ссылке
        //var message = Messages.FirstOrDefault(m => m.uniquelink == link);

        using ApplicationDbContext dbContext = new();
        var messageFromDb = dbContext.messages.FirstOrDefault(x => x.uniquelink == link);

        if (messageFromDb == null)
        {
            return NotFound();
        }

        // Если сообщение не прочитано, отмечаем его как прочитанное
        if (!messageFromDb.isread)
        {
            messageFromDb.isread = true;
        }

        Console.WriteLine("Сообщение выдано: " + messageFromDb.content);

        // Удаляем сообщение из списка (самоуничтожение)
        // Messages.Remove(messageFromDb);
        dbContext.Remove(messageFromDb);
        dbContext.SaveChanges();

        Console.WriteLine("Всего сообщений " + Messages.Count);
        // Возвращаем содержимое сообщения
        return Ok(messageFromDb.content);
    }
}