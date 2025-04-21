namespace Meilenstein_1;

public class PostOffice
{
    public string Name { get; }
    private string _adress;
    private readonly Mailbox?[] _mailbox;
    private int _freeSlot = 0;
    public int MailboxCapacity { get; }

    public int Freeslot => _freeSlot;


    public PostOffice(string name, string adress, int mailboxCapacity)
    {
        Name = name;
        _adress = adress;
        MailboxCapacity = mailboxCapacity;
        _mailbox = new Mailbox[MailboxCapacity];
    }

    public Mailbox? this[int index]
    {
        get => _mailbox[index];
        private set => _mailbox[index] = value;
    }

    public Mailbox? RentMailbox(Company owner)
    {
        if (_freeSlot > MailboxCapacity)
            throw new ArgumentException("Mailbox capacity reached - cannot create a new one");

        _mailbox[_freeSlot] = new Mailbox(owner, this);
        _freeSlot++;

        return _mailbox[_freeSlot - 1];
    }

    public void CancelMailbox(Company owner)
    {
        int i = FindMailbox(owner);

        if (i == -1)
            throw new ArgumentException($"No Mailbox from {owner} not found");

        _mailbox[i] = _mailbox[_freeSlot - 1];
        _freeSlot--;
    }

    public void CancelMailbox(Mailbox? mailbox)
    {
        int i = FindMailbox(mailbox);

        if (i == -1)
            throw new ArgumentException($"Mailbox {mailbox!.MailId} not found");

        _mailbox[i] = _mailbox[_freeSlot - 1];
        _freeSlot--;
    }

    private int FindMailbox(Mailbox? mailbox)
    {
        for (int i = 0; i < _freeSlot; i++)
        {
            if (_mailbox[i] == mailbox)
                return i;
        }

        return -1;
    }

    private int FindMailbox(Company owner)
    {
        for (int i = 0; i < _freeSlot; i++)
        {
            if (_mailbox[i]!.Owner == owner)
                return i;
        }

        return -1;
    }

    public int EmptyMailboxes(Company owner)
    {
        int mailCount = 0;
        for (int i = 0; i < _freeSlot; i++)
        {
            if (_mailbox[i]!.Owner == owner)
            {
                Mail[]? mail = _mailbox[i]!.Empty();
                if (mail != null)
                    mailCount += mail.Length;
            }
        }

        return mailCount;
    }

    public int PostmanDelivery(int i, out Company owner)
    {
        owner = _mailbox[i]!.Owner;
        return EmptyMailboxes(owner); 
    }

    public void FileMail(Mail mail)
    {
        int i = FindMailbox(mail.Receiver);

        if (i == -1)
            Console.WriteLine("This Post office doesn`t manage a mailbox of the receiving Company. Try a different");
        else
        {
            _mailbox[i]!.FileMail(mail);
            Console.WriteLine($"\x1b[3mMail filed at {Name} for company: {mail.Receiver.Name}\x1b[0m");
        }
    }
}