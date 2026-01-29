public class Program
{
    static List<Client> clients = new List<Client>();
    static void Main()
    {
        Console.WriteLine("Welcome!");
        Console.WriteLine();



        bool execution = true;

        while (execution)
        {

            Console.WriteLine("1 - Add");
            Console.WriteLine("2 - Edit");
            Console.WriteLine("3 - View");
            Console.WriteLine("4 - Remove");
            Console.WriteLine("5 - Nothing");

            int operation = int.Parse(Console.ReadLine()!);


            switch (operation)
            {
                case 1:
                    AddClient();
                    break;
                case 2:
                    ViewClient();
                    break;
                case 3:
                    EditClient();
                    break;
                case 4:
                    RemoveClient();
                    break;
                case 5:
                    execution = false;
                    break;

                default:
                    Console.WriteLine("Option invalid!");
                    break;
            }
        }
        static void AddClient()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine()!;

            Console.Write("Email: ");
            string email = Console.ReadLine()!;

            Console.Write("CPF: ");
            string cpf = Console.ReadLine()!;

            var client = new Client(name, email, cpf);
            clients.Add(client);

            Console.WriteLine();
        }

        static void EditClient()
        {
            Console.WriteLine("Name of client");
            string cpf = Console.ReadLine()!;

            Client client = clients.Find(c => c.CPF == cpf);

            Console.Write("What's new name? ");
            string newName = Console.ReadLine()!;

            Console.Write("Change email (Y or N)? ");
            char yesOrNo = char.Parse(Console.ReadLine()!);

            if (yesOrNo == 'Y' || yesOrNo == 'y' )
            {
                Console.Write("What's new email? ");
                string newEmail = Console.ReadLine()!;
                Console.Write("New Name and new Email: ");
                client.Name = newName;
                client.Email = newEmail;
            }
            else if (yesOrNo == 'N' || yesOrNo == 'n')
            {
                Console.Write("New name: ");
                client.Name = newName;
            }
            else
            {
                Console.WriteLine("Something went wrong. Please try again.");
            }

        }

        static void ViewClient()
        {
            foreach(Client client in clients)
            {
                Console.WriteLine($"Name: {client.Name}");
                Console.WriteLine($"Email: {client.Email}");
                Console.WriteLine($"CPF: {client.CPF}");

                Console.WriteLine();

            }
        }

        static void RemoveClient()
        {
            Console.WriteLine("Name of client");
            string cpf = Console.ReadLine()!;

            Client client = clients.Find(c => c.CPF == cpf);

            Console.Write("He is sure? (Y or N) ");
            char yesOrNo = char.Parse(Console.ReadLine()!);


            if (yesOrNo == 'Y' || yesOrNo == 'y')
            {
                if (client != null)
                {
                    clients.Remove(client);
                }
                else
                {
                    Console.WriteLine("User not found");
                }
            }
            else if (yesOrNo == 'N' || yesOrNo == 'n')
            {
                Console.WriteLine("The user will not be removed.");
            }
            else
            {
                Console.WriteLine("Option invalid");
            }
        }
    }
}