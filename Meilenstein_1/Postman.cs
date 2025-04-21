namespace Meilenstein_1;

public class Postman
{
    private int _postmanId;
    private static int _nextId = 1;
    private string _name;

    public Postman(string name)
    {
        _name = name;
        _postmanId = _nextId;
        _nextId++;
    }

    public void Deliver(PostOffice postOffice)
    {
        for (int i = 0; i < postOffice.Freeslot; i++)
        {
            int mails = postOffice.PostmanDelivery(i, out Company owner);
            owner.RecieveLetters(mails);
        }

        Console.WriteLine($"\x1b[3mdelivered mails from {postOffice.Name}\x1b[0m");
    }
}