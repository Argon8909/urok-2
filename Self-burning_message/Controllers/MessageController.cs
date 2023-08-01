using Microsoft.AspNetCore.Mvc;
using Self_burning_message.Models;


namespace Self_burning_message.Controllers;

[ApiController]
[Route("api/messages")]
public class MessageController : ControllerBase
{
    private string _baseUrl = "https://localhost:44383/api/messages/";
    private string _urlFromLink = "GetMessageFromDb?link=";

    [HttpPost]
    [Route("CreateMessageToDb")]
    public IActionResult CreateMessageToDb(string content)
    {
        Console.WriteLine("пришло от клиента => " + content);
        var message = new Message
        {
            // Генерируем уникальную ссылку для сообщения
            uniquelink = Guid.NewGuid().ToString(),
            isread = false,
            content = content,
            creation_time = DateTime.Now // Задаем текущее время
        };

        // Добавляем сообщение в список
        using ApplicationDbContext dbContext = new();
        dbContext.messages.Add(message);
        dbContext.SaveChanges();

        // Возвращаем уникальную ссылку
        //return Ok(_baseUrl + _urlFromLink + message.uniquelink);
        return Ok(message.uniquelink);
    }

    [HttpGet]
    [Route("GetMessageFromDb")]
    public IActionResult GetMessageFromDb(string link)
    {
        using ApplicationDbContext dbContext = new();

        // Находим сообщение по уникальной ссылке
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

        // Удаляем сообщение из списка (самоуничтожение)
        dbContext.Remove(messageFromDb);
        dbContext.SaveChanges();

        // Возвращаем содержимое сообщения
        return Ok(messageFromDb.content);
    }
}

/*
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
    
    select * from Messages;
select last_value from messages_id_seq;
select count(*) from Messages;

*/