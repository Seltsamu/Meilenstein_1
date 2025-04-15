namespace Meilenstein_1;

public class Mailbox
{
    private readonly int _mailId;
    private static int _nextId = 1;
    private Company _owner;
    private int _contents;

    public int Contents
    {
        get => _contents;
        set => _contents = value;
    }

    public int MailId => _mailId;

    public Company Owner => _owner;
    public Mailbox(Company owner)
    {
        _owner = owner;
        _mailId = _nextId;
        _nextId++;
    }
}