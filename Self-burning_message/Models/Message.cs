namespace Self_burning_message.Models;

public class Message
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime ExpirationDate { get; set; }
    public bool IsRead { get; set; }
    public string UniqueLink { get; set; }
}
