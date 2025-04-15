namespace Meilenstein_1;

public class Company
{
    private string _name;
    private string _adress;

    public Company(string name, string adress)
    {
        _name = name;
        _adress = adress;
    }

    public void RentMailbox(PostOffice postOffice, int amount = 1)
    {
        for (int i = 0; i < amount; i++)
            postOffice.RentMailbox(this);
    }
    
    public void CancelMailbox(PostOffice postOffice, Mailbox mailbox)
    {
        postOffice.CancelMailbox(mailbox);
    }

    public void CancelMailbox(PostOffice postOffice)
    {
        postOffice.CancelMailbox(this);
    }

    public int EmptyMailbox(Mailbox mail)
    {
        return mail.Contents;
    }
}