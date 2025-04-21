namespace Meilenstein_1;

static class Program
{
    private static void Main()
    {
        int mailboxNum = 2;

        PostOffice po1 = new PostOffice("Post office nuernberg", "bspStraße", 10);
        PostOffice po2 = new PostOffice("Post office erlangen", "bspStraße 2", 5);
        Company comp1 = new Company("BA", "irgendwo");
        Company comp2 = new Company("Nokia", "Somewhere");
        Postman postman1 = new Postman("Alex");
        Mail mail1 = new Mail("This is the first mail", comp1, comp2);
        Mail mail2 = new Mail("This is the second mail", comp2, comp1);

        PrintFreeMailboxes(po1);
        comp1.RentMailbox(po1, mailboxNum);
        comp2.RentMailbox(po1);
        PrintFreeMailboxes(po1);

        Console.WriteLine($"Owner of mailbox {mailboxNum}: {po1[mailboxNum - 1]!.Owner.Name}");

        comp1.RentMailbox(po2);
        PrintCompanyMailboxAmount(comp1);

        comp1.CancelMailbox(po1);
        PrintCompanyMailboxAmount(comp1);
        PrintFreeMailboxes(po1);

        po1.FileMail(mail1);
        po2.FileMail(mail2);

        Console.WriteLine($"{comp1.Name} mails: {comp1.MailCount}");
        comp1.EmptyMailboxes();
        Console.WriteLine($"{comp1.Name} mails: {comp1.MailCount}");

        postman1.Deliver(po1);
        Console.WriteLine($"{comp2.Name} mails: {comp2.MailCount}");
    }

    private static void PrintCompanyMailboxAmount(Company comp1)
    {
        Console.WriteLine($"Amount of mailboxes owned by {comp1.Name}: {comp1.FreeSlot}");
    }

    private static void PrintFreeMailboxes(PostOffice po1)
    {
        Console.WriteLine($"Free Mailboxes in {po1.Name}: " +
                          $"{po1.MailboxCapacity - po1.Freeslot}");
    }
}