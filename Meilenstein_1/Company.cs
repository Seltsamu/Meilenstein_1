namespace Meilenstein_1;

public class Company
{
    private string _name;
    private string _adress;
    private int _letters = 0;
    // TODO create Mailbox array for the company

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

    public void RecieveLetters(int letters)
    {
        _letters += letters;
    }

    public void EmptyMailbox(Mailbox mail)
    {
        if (mail.Owner == this)
            _letters += mail.Contents;
        throw new ArgumentException("This Mailbox doesn`t belong to you");
    }
}