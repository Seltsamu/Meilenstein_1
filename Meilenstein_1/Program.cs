using System.Diagnostics;
using System.Threading.Channels;

namespace Meilenstein_1;
class Program()
{
    private static void Main()
    {
        int input = -1;

        while (input != 0)
        {
            Console.WriteLine("0 - Quit");
            Console.WriteLine("1 - Create post office");
            Console.WriteLine("2 - Create company");
            Console.WriteLine("3 - Create postman");
            Console.WriteLine("4 - Rent a Mailbox");
            Console.WriteLine("5 - Cancel a Mailbox");
            Console.WriteLine("6 - Empty a Mailbox");
            Console.WriteLine("7 - Postman delivers letters");
            input = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            
            switch (input)
            {
                case 0: 
                    Console.Write("Quitting");
                    break;
                case 1:
                    Console.Write("Enter a name for your post office: ");
                    string name = Console.ReadLine()!;
                    Console.Write("\nEnter an adress for your post office: ");
                    string adress = Console.ReadLine()!;
                    Console.Write("\nEnter the maximum amount on mailboxes the post office can manage: ");
                    int capacity = Convert.ToInt32(Console.ReadLine()!);
                    
                    
                    break;
            }

        }
    }
}

