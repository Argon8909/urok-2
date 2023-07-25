using Microsoft.AspNetCore.Mvc;
using Self_burning_message.Models;


namespace Self_burning_message.Controllers;

[ApiController]
[Route("api/messages")]
public class MessageController : ControllerBase
{
    private static readonly List<Message> Messages = new List<Message>();

    [HttpPost]
    public IActionResult CreateMessage(Message message)
    {
        // Генерируем уникальную ссылку для сообщения
        message.UniqueLink = Guid.NewGuid().ToString();
     
        // Добавляем сообщение в список
        Messages.Add(message);

        // Возвращаем уникальную ссылку
        return Ok(new { Link = message.UniqueLink });
    }

    [HttpGet("{link}")]
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

        // Удаляем сообщение из списка (самоуничтожение)
        Messages.Remove(message);

        // Возвращаем содержимое сообщения
        return Ok(new { Content = message.Content });
    }
}
