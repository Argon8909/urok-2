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
        message.UniqueLink = Guid.NewGuid().ToString();
        message.IsRead = false;

        // Добавляем сообщение в список
        Messages.Add(message);
        Console.WriteLine("Сообщение: " + message.Content);
        Console.WriteLine("Линк: " + message.UniqueLink);
        Console.WriteLine("Всего сообщений " + Messages.Count);
        // Возвращаем уникальную ссылку
        return Ok(message.UniqueLink);
    }


    [HttpGet]
    [Route("GetMessage")]
    public IActionResult GetMessage(string link)
    {
        // Находим сообщение по уникальной ссылке
        var message = Messages.FirstOrDefault(m => m.UniqueLink == link);

        if (message == null)
        {
            return NotFound();
        }

        // Если сообщение не прочитано, отмечаем его как прочитанное
        if (!message.IsRead)
        {
            message.IsRead = true;
        }

        Console.WriteLine("Сообщение выдано: " + message.Content);
        //Console.WriteLine("Линк: " + message.UniqueLink);
        
        // Удаляем сообщение из списка (самоуничтожение)
        Messages.Remove(message);
        Console.WriteLine("Всего сообщений " + Messages.Count);
        // Возвращаем содержимое сообщения
        return Ok(message.Content);
    }
}