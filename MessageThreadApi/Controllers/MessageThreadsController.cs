using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class MessageThreadsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public MessageThreadsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/MessageThreads
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MessageThread>>> GetMessageThreads()
    {
    return await _context.MessageThreads.Include(mt => mt.Messages).ToListAsync();
    }

    // GET: api/MessageThreads/5
    [HttpGet("{id}")]
    public async Task<ActionResult<MessageThread>> GetMessageThread(int id)
    {
        var messageThread = await _context.MessageThreads.Include(mt => mt.Messages)
            .FirstOrDefaultAsync(mt => mt.Id == id);

        if (messageThread == null)
        {
            return NotFound();
        }

        return messageThread;
    }

    // POST: api/MessageThreads
    [HttpPost]
    public async Task<ActionResult<MessageThread>> CreateMessageThread(MessageThread messageThread)
    {
        _context.MessageThreads.Add(messageThread);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMessageThread), new { id = messageThread.Id }, messageThread);
    }

    // POST: api/MessageThreads/5/messages
    [HttpPost("{id}/messages")]
    public async Task<ActionResult<Message>> AddMessage(int id, Message message)
    {
        var messageThread = await _context.MessageThreads.FindAsync(id);
        if (messageThread == null)
        {
            return NotFound();
        }

        message.ThreadId = id;
        message.Timestamp = DateTime.Now;
        _context.Messages.Add(message);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMessageThread), new { id = messageThread.Id }, message);
    }
}