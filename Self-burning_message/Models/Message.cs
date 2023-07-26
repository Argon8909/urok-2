using System.ComponentModel.DataAnnotations.Schema;

namespace Self_burning_message.Models;

public class Message
{
    public int id { get; set; }
    public string? content { get; init; }

    [Column(TypeName = "timestamp")] public DateTime creation_time { get; set; }
    public bool isread { get; set; }
    public string uniquelink { get; set; }
}