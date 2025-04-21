namespace Meilenstein_1;

public class Mailbox
{
    public Company Owner { get; }
    public PostOffice Manager { get; }
    private readonly int _mailId;
    private static int _nextId = 1;
    private readonly Mail[]? _mail = new Mail[5];
    private int _freeslot = 0;

    public int MailId => _mailId;


    public Mailbox(Company owner, PostOffice manager)
    {
        Owner = owner;
        Manager = manager;
        _mailId = _nextId;
        _nextId++;
    }

    public void FileMail(Mail mail)
    {
        if (_freeslot >= _mail!.Length)
            throw new ArgumentException("Mailbox is full - can´t hold anymore mails");

        _mail[_freeslot] = mail;
        _freeslot++;
    }

    public Mail[]? Empty()
    {
        if (_freeslot == 0)
            return null;

        Mail[] mail = new Mail[_freeslot];
        for (int i = 0; i < _freeslot; i++)
        {
            mail[i] = _mail![i];
            _mail[i] = null!;
        }

        _freeslot = 0;

        return mail;
    }

    public static bool operator ==(Mailbox? mail1, Mailbox? mail2)
    {
        if (mail1!.MailId == mail2!._mailId)
            return true;
        return false;
    }

    public static bool operator !=(Mailbox mail1, Mailbox mail2)
    {
        return !(mail1 == mail2);
    }
}