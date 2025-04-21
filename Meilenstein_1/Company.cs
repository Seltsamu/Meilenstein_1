namespace Meilenstein_1;

public class Company
{
    public string Name { get; }
    private string _adress;
    private int _mailCount = 0;
    private readonly Mailbox?[] _mailboxes = new Mailbox?[50];
    private int _freeSlot = 0;

    public Company(string name, string adress)
    {
        Name = name;
        _adress = adress;
    }

    public int FreeSlot => _freeSlot;
    public Mailbox?[] Mailboxes => _mailboxes;
    public int MailCount => _mailCount;

    public void RentMailbox(PostOffice postOffice, int amount = 1)
    {
        for (int i = 0; i < amount; i++)
        {
            _mailboxes[_freeSlot] = postOffice.RentMailbox(this);
            _freeSlot++;
        }

        Console.WriteLine($"\x1b[3mrented {amount} mailboxes at {postOffice.Name}\x1b[0m");
    }

    public void CancelMailbox(Mailbox? mailbox)
    {
        mailbox!.Manager.CancelMailbox(mailbox);
        _mailboxes[FindMailbox(mailbox)] = _mailboxes[_freeSlot - 1];
        _freeSlot--;
        _mailboxes[_freeSlot] = null;

        Console.WriteLine($"\x1b[3mcanceled mailbox at {mailbox.Manager.Name}\x1b[0m");
    }

    public void CancelMailbox(PostOffice postOffice)
    {
        postOffice.CancelMailbox(this);

        Console.WriteLine($"\x1b[3mcanceled mailbox at {postOffice.Name}\x1b[0m");
    }

    private int FindMailbox(Mailbox? mailbox)
    {
        for (int i = 0; i < _freeSlot; i++)
        {
            if (_mailboxes[i] == mailbox)
                return i;
        }

        throw new ArgumentException($"Mailbox {mailbox!.MailId} doesn`t belong to {this.Name}");
    }

    public void RecieveLetters(int mails)
    {
        _mailCount += mails;
    }

    public void EmptyMailboxes()
    {
        for (int i = 0; i < _freeSlot; i++)
        {
            _mailCount += _mailboxes[i]!.Manager.EmptyMailboxes(this);
        }

        Console.WriteLine($"\x1b[3mEmptied mails from company: {this.Name}\x1b[0m");
    }
}