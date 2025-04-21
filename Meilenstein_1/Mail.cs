namespace Meilenstein_1;

public class Mail
{
    private string _content;
    public Company Sender { get; }
    public Company Receiver { get; }

    public Mail(string content, Company sender, Company receiver)
    {
        Receiver = receiver;
        Sender = sender;
        _content = content;
    }
}