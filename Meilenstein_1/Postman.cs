using System.Runtime.CompilerServices;

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

    public static void Deliver(PostOffice postOffice)
    {
        for (int i = 0; i < postOffice.Freeslot; i++)
        {
           int letters = postOffice.PostmanDelivery(i, out Company owner);
           owner.RecieveLetters(letters);
        }
    }
}