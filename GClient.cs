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
        string newEmail = null, newName = null, cpf = null;

        while (true)
        {
            if (cpf == null)
            {
                System.Console.Write("Digite o CPF para alterar o Nome e Email.");
                cpf = Console.ReadLine();
            }
            if (!VCpf(cpf))
            {
                System.Console.WriteLine("Invalid CPF!");
                cpf = null;
                continue;
            }
            if (VCpf(cpf))
            {
                Client client = _clients.Find(c => c.CPF == cpf);

                System.Console.Write($"\nUser : {client.Name}\n\n1- change New Name\n2- change New Email\n\ntype 1 or 2: ");
                string nameOremail = Console.ReadLine();

                switch (nameOremail)
                {
                    case "1":
                        if (newName == null)
                        {
                            System.Console.Write("New Name: ");
                            newName = Console.ReadLine();
                        }
                        if (!VName(newName))
                        {
                            System.Console.WriteLine("Invalid New Name!");
                            newName = null;
                            continue;
                        }
                         System.Console.WriteLine("Change Email? 'y' or 'n'");
                        string yesOrno = Console.ReadLine();

                        yesOrno.ToLower();

                        if (yesOrno == "y")
                        {
                            if (newEmail == null)
                            {
                                System.Console.Write("New Email: ");
                                newEmail = Console.ReadLine();
                            }
                            if (!VEmail(newEmail))
                            {
                                System.Console.WriteLine("Invalid New Email!");
                                newEmail = null;
                                continue;
                            }
                            client.Name = newName;
                            client.Email= newEmail;
                        }
                        else if (yesOrno == "n")
                        {
                            client.Name = newName;
                        }
                        System.Console.WriteLine($"Sucessfuly!\nNew name: {client.Name}\nNew Email: {client.Email}\nCPF: {client.CPF}");
                        break;
                    case "2":
                        if (newEmail == null)
                        {
                            System.Console.Write("New Email: ");
                            newEmail = Console.ReadLine();
                        }
                        if (!VEmail(newEmail))
                        {
                            System.Console.WriteLine("Invalid New Name!");
                            newEmail = null;
                            continue;
                        }
                        System.Console.WriteLine("Change Name? 'y' or 'n'");
                        string yesOrnoN = Console.ReadLine();

                        yesOrnoN.ToLower();

                        if (yesOrnoN == "y")
                        {
                            if (newName == null)
                            {
                                System.Console.Write("New Name: ");
                                newName = Console.ReadLine();
                            }
                            if (!VName(newName))
                            {
                                System.Console.WriteLine("Invalid New Name!");
                                newName = null;
                                continue;
                            }
                            client.Name = newName;
                            client.Email = newEmail;
                        }
                        else if (yesOrnoN == "n")
                        {
                            client.Email = newEmail;
                        }
                        System.Console.WriteLine($"Sucessfuly!\nNew name: {client.Name}\nNew Email: {client.Email}\nCPF: {client.CPF}");
                        break;
                    default:
                        System.Console.WriteLine("Invalid Options");
                        break;
                }
                break;



            }


        }
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
