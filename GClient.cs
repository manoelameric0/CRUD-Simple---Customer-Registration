using System;
using Microsoft.VisualBasic;

namespace CustomerRegistration;

public class GClient
{
    private List<Client> _clients = new List<Client>();
    public List<Client> Clients
    {
        get
        {
            return _clients;
        }
    }


    public void AddClient()
    {
        Console.Write("Name: ");
        string name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            System.Console.WriteLine("It is not possible to add a person without a name!");
        }
        if (int.TryParse(name, out int a))
        {
            System.Console.WriteLine("It is not possible to have a name with numeric values! Only characters are allowed.");
        }

        Console.Write("Email: ");
        string email = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(email))
        {
            System.Console.WriteLine("It is not possible to add an email without characters!");
        }
        if (int.TryParse(email, out int b))
        {
            System.Console.WriteLine("It is not possible to have a numeric email! Only characters are allowed.");
        }

        Console.Write("CPF: ");
        string cpfString = Console.ReadLine();
        if (!int.TryParse(cpfString, out int cpf))
        {
            System.Console.WriteLine("Enter a numeric value");
        }
        var client = new Client(name, email, cpf);
        _clients.Add(client);

        Console.WriteLine();
    }

    public void EditClient()
    {
        Console.Write("Write CPF: ");
        string cpfString = Console.ReadLine();
        if (!int.TryParse(cpfString, out int cpf))
        {
            System.Console.WriteLine("Enter a numeric value");
        }

        Client client = Clients.Find(c => c.CPF == cpf);

        Console.Write("What's new name? ");
        string newName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(newName))
        {
            System.Console.WriteLine("It is not possible to add a person without a name!");
        }
        if (int.TryParse(newName, out int a))
        {
            System.Console.WriteLine("It is not possible to have a name with numeric values! Only characters are allowed.");
        }

        Console.Write("Change email (Y or N)? ");
        string yesOrNoString = Console.ReadLine();
        if (!char.TryParse(yesOrNoString, out char yesOrNo))
        {
            System.Console.WriteLine("Type only ‘y’ or ‘n’");
        }
        yesOrNo = char.ToLower(yesOrNo);

        if (yesOrNo == 'y')
        {
            Console.Write("What's new email? ");
            string newEmail = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newName))
            {
                System.Console.WriteLine("It is not possible to add a person without a name!");
            }
            if (int.TryParse(newName, out int b))
            {
                System.Console.WriteLine("It is not possible to have a name with numeric values! Only characters are allowed.");
            }
            Console.Write("Name and email updated successfully!: ");
            client.Name = newName;
            client.Email = newEmail;
        }
        else if (yesOrNo == 'n')
        {
            Console.Write("Name updated successfully!: ");
            client.Name = newName;
        }
        else
        {
            Console.WriteLine("Something went wrong. Please try again.");
        }

    }

    public void ViewClient()
    {
        foreach (Client client in Clients)
        {
            Console.WriteLine($"Name: {client.Name}");
            Console.WriteLine($"Email: {client.Email}");
            Console.WriteLine($"CPF: {client.CPF}");

            Console.WriteLine();

        }
    }

    public void RemoveClient()
    {
        Console.Write("Write CPF: ");
        string cpfString = Console.ReadLine();
        if (!int.TryParse(cpfString, out int cpf))
        {
            System.Console.WriteLine("Enter a numeric value");
        }

        Client client = Clients.Find(c => c.CPF == cpf);

        Console.Write("He is sure? (Y or N) ");
        string yesOrNoString = Console.ReadLine();
        if (!char.TryParse(yesOrNoString, out char yesOrNo))
        {
            System.Console.WriteLine("Type only ‘y’ or ‘n’");
        }
        yesOrNo = char.ToLower(yesOrNo);

        if (yesOrNo == 'y')
        {
            if (client != null)
            {
                Clients.Remove(client);
                System.Console.WriteLine("Customer removed successfully!");
            }
            else
            {
                Console.WriteLine("User not found");
            }
        }
        else if (yesOrNo == 'n')
        {
            Console.WriteLine("The user will not be removed.");
        }
        else
        {
            Console.WriteLine("Option invalid");
        }
    }
}
