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

    public bool VName(string name)
    {

        if (string.IsNullOrWhiteSpace(name) || int.TryParse(name, out int b))
        {

            return false;
        }
        return true;
    }
    public bool VEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email) || int.TryParse(email, out int b))
        {
            return false;
        }
        return true;
    }
    public bool VCpf(string cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf) || !double.TryParse(cpf, out double b))
        {
            return false;
        }
        if (b < 0)
        {
            return false;
        }
        return true;
    }

    public void AddClient()
    {

        string name = null, email = null, cpf = null;
        while (true)
        {
            if (name == null)
            {
                System.Console.Write("Name: ");
                name = Console.ReadLine();
            }

            if (!VName(name))
            {
                System.Console.WriteLine("\nInvalid Name!");
                name = null;
                continue;
            }

            if (email == null)
            {
                System.Console.Write("Email: ");
                email = Console.ReadLine();
            }

            if (!VEmail(email))
            {
                System.Console.WriteLine("\nInvalid Email!");
                email = null;
                continue;
            }

            if (cpf == null)
            {
                System.Console.Write("CPF: ");
                cpf = Console.ReadLine();
            }

            if (!VCpf(cpf))
            {
                System.Console.WriteLine("\nInvalid CPF!");
                cpf = null;
                continue;
            }


            if (VName(name) && VEmail(email) && VCpf(cpf))
            {
                var client = new Client(name, email, cpf);
                _clients.Add(client);
                System.Console.WriteLine("\nAdd Sucess");
                break;
            }
        }


    }




    public void EditClient()
    {
        System.Console.Write("CPF: ");
        string cpf = Console.ReadLine();

        Client client = _clients.Find(c => c.CPF == cpf);

        System.Console.Write("New Name: ");
        string newName = Console.ReadLine();

        System.Console.WriteLine("Edit Email? 'y' or 'n'");
        string yesOrno = Console.ReadLine();

        yesOrno.ToLower();

        if (yesOrno == "y")
        {
            System.Console.Write("New Email: ");
            string newEmail = Console.ReadLine();
            client.Name = newName;
            client.Email = newEmail;
        }
        else if (yesOrno == "n")
        {

        }
        {
            client.Name = newName;
        }
        System.Console.WriteLine($"Sucessfuly!\nNew name: {client.Name}\nNew Email: {client.Email}\nCPF: {client.CPF}");
    }

    public void ViewClient()
    {
        foreach (var item in _clients)
        {
            System.Console.WriteLine($"\nName: {item.Name} ");
            System.Console.WriteLine($"Email: {item.Email}");
            System.Console.WriteLine($"CPF: {item.CPF}\n");
        }
    }

    public void RemoveClient()
    {
        System.Console.Write("CPF: ");
        string cpfString = Console.ReadLine();

        Client client = Clients.Find(c => c.CPF == cpfString);
        Clients.Remove(client);
        System.Console.WriteLine("Remove Sucessfuly");
    }

}
