public class Message
{
    public int Id { get; set; }
    public string? Content { get; set; }
    public DateTime Timestamp { get; set; }
    public int ThreadId { get; set; } 
    public MessageThread? MessageThread { get; set; }
}

public class MessageThread
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public List<Message> Messages { get; set; } = new List<Message>();
}