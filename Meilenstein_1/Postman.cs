using System.Runtime.CompilerServices;

namespace Meilenstein_1;

public class Postman
{
    private int _postmanId;
    private static int _nextId = 1;

    public Postman()
    {
        _postmanId = _nextId;
        _nextId++;
    }

    public static void Deliver(int items)
    {
        throw new NotImplementedException();
    }
}