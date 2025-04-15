using System.IO.Enumeration;
using System.Reflection.Metadata.Ecma335;

namespace Meilenstein_1;

public class PostOffice
{
    private string _name;
    private string _adress;
    private Mailbox[] _mailbox;
    private int _freeSlot = 0;
    private int _mailboxCapacity;


    public PostOffice(string name, string adress, int mailboxCapacity)
    {
        _name = name;
        _adress = adress;
        _mailboxCapacity = mailboxCapacity;
        _mailbox = new Mailbox[_mailboxCapacity];
    }

    public Mailbox this[uint index]
    {
        get => _mailbox[index];
        private set => _mailbox[index] = value;
    }

    public void RentMailbox(Company owner)
    {
        if (_freeSlot > _mailboxCapacity)
            throw new ArgumentException("Mailbox capacity reached - cannot create a new one");

        _mailbox[_freeSlot] = new Mailbox(owner);
        _freeSlot++;
    }

    public void CancelMailbox(Company owner)
    {
        int i = FindMailbox(owner);

        if (i == -1)
            throw new ArgumentException($"No Mailbox from {owner} not found");

        int id = _mailbox[i].MailId;
        _mailbox[i] = _mailbox[_freeSlot - 1];
        _freeSlot--;
        Console.WriteLine($"Mailbox from {owner} with id {id} canceled");
    }
    public void CancelMailbox(Mailbox mailbox)
    {
        int i = FindMailbox(mailbox);

        if (i == -1)
            throw new ArgumentException($"Mailbox {mailbox.MailId} not found");
        
        _mailbox[i] = _mailbox[_freeSlot - 1];
        _freeSlot--;
        Console.WriteLine("Mailbox " + mailbox.MailId + " canceled");
    }

    private int FindMailbox(Mailbox mailbox)
    {
        for (int i = 0; i < _freeSlot; i++)
        {
            if (_mailbox[i]== mailbox)
                return i;
        }

        return -1;
    }
    
    private int FindMailbox(Company owner)
    {
        for (int i = 0; i < _freeSlot; i++)
        {
            if (_mailbox[i].Owner == owner)
                return i;
        }

        return -1;
    }

    public int EmptyMailbox(Mailbox mailbox)
    {
        int i = FindMailbox(mailbox);

        if (i == -1)
            throw new ArgumentException($"Mailbox {mailbox.MailId} not found");

        int contents = _mailbox[i].Contents;
        _mailbox[i].Contents = 0;
        return contents;
    }
}