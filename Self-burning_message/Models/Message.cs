namespace Self_burning_message.Models;

public class Message
{
    public int id { get; set; }
    public string content { get; set; }
    
    public DateTime expirationdate { get; set; }
    public bool isread { get; set; }
    public string uniquelink { get; set; }
}
