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
    string Name;

     public bool Validation()
    {
         System.Console.Write("Name: ");
        string name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name) || int.TryParse(name, out int b))
        {
            System.Console.WriteLine("Invalid Name!");
            return false;
        }
        Name = name;
        return true;
    }
    
    public void AddClient()
    {
        
        Validation();
        
        System.Console.Write("Email: ");
        string emailString = Console.ReadLine();

        System.Console.Write("CPF: ");
        string cpfString = Console.ReadLine();

        var client = new Client(Name, emailString, cpfString);
        _clients.Add(client);
        System.Console.WriteLine("Sucess");
    }
    
    
   

    public void EditClient()
    {
        System.Console.Write("CPF: ");
        string cpf = Console.ReadLine();

        Client client = _clients.Find(c => c.CPF == cpf);

        System.Console.Write("New Name: ");
        string newName =Console.ReadLine();

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
            System.Console.WriteLine($"Name: {item.Name} ");
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
