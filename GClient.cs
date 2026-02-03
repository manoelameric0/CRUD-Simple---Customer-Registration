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
                System.Console.WriteLine("\nAdded successfully!\n");
                break;
            }
        }


    }




    public void EditClient()
    {
        string newEmail = null, newName = null, cpf = null, escolha = null;

        while (escolha != "-1")
        {
            if (cpf == null)
            {
                System.Console.WriteLine("\nEnter the CPF to change the name and email, or -1 to exit.");
                System.Console.Write("CPF: ");
                cpf = Console.ReadLine();
                escolha = cpf;
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
                if (client == null)
                {
                    System.Console.WriteLine("CPF not found!");
                    cpf = null;
                    continue;
                }

                Console.Clear();
                System.Console.Write($"\nUser : {client.Name}\n\n1- change New Name\n2- change New Email\n3- Back to menu\n\ntype 1 - 2 or 3: ");
                string nameOremail = Console.ReadLine();

                switch (nameOremail)
                {
                    case "1":
                        while (escolha != "-1")
                        {
                            if (newName == null)
                            {
                                System.Console.WriteLine("Enter the new name or -1 to go back.");
                                System.Console.Write("New Name: ");
                                newName = Console.ReadLine();
                                escolha = newName;
                            }
                            if (!VName(newName))
                            {
                                System.Console.WriteLine("Invalid New Name!");
                                newName = null;
                                continue;
                            }
                            System.Console.WriteLine("Do you want to change the email? 'y' or 'n'");
                            string yesOrnoString = Console.ReadLine();
                            if (!char.TryParse(yesOrnoString, out char yOrn))
                            {
                                System.Console.WriteLine("Invalid type only 'y' or 'n'\n");
                                continue;
                            }



                            if ((yOrn = char.ToLower(yOrn)) == 'y')
                            {
                                if (newEmail == null)
                                {
                                    System.Console.WriteLine("Enter the new Email or -1 to go back.");
                                    System.Console.Write("New Email: ");
                                    newEmail = Console.ReadLine();
                                    escolha = newEmail;
                                }
                                if (!VEmail(newEmail))
                                {
                                    System.Console.WriteLine("Invalid New Email!");
                                    newEmail = null;
                                    continue;
                                }
                                client.Name = newName;
                                client.Email = newEmail;
                            }
                            if ((yOrn = char.ToLower(yOrn)) == 'n')
                            {
                                client.Name = newName;
                            }
                            System.Console.WriteLine($"\nSucessfuly!\nNew name: {client.Name}\nNew Email: {client.Email}\nCPF: {client.CPF}");
                            break;
                        }
                        break;
                    case "2":
                        if (newEmail == null)
                        {
                            System.Console.WriteLine("Enter the new Email or -1 to go back.");
                            System.Console.Write("New Email: ");
                            newEmail = Console.ReadLine();
                            escolha = newEmail;
                        }
                        if (!VEmail(newEmail))
                        {
                            System.Console.WriteLine("Invalid New Name!");
                            newEmail = null;
                            continue;
                        }
                        System.Console.WriteLine("Do you want to change the name? 'y' or 'n'");
                        string yesOrnoC = Console.ReadLine();
                        if (!char.TryParse(yesOrnoC, out char yOrn2))
                        {
                            System.Console.WriteLine("Invalid type only 'y' or 'n'");
                            continue;
                        }


                        if ((yOrn2 = char.ToLower(yOrn2)) == 'y')
                        {
                            if (newName == null)
                            {
                                System.Console.WriteLine("Enter the new name or -1 to go back.");
                                System.Console.Write("New Name: ");
                                newName = Console.ReadLine();
                                escolha = newName;
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
                        if ((yOrn2 = char.ToLower(yOrn2)) == 'n')
                        {
                            client.Email = newEmail;
                        }
                        System.Console.WriteLine($"\nSucessfuly!\nNew name: {client.Name}\nNew Email: {client.Email}\nCPF: {client.CPF}");
                        break;

                    case "3":
                        break;
                    default:
                        System.Console.WriteLine("\nInvalid Options");
                        continue;
                }
                break;



            }


        }
    }

    public void ViewClient()
    {
        foreach (var item in _clients)
        {
            Console.Clear();
            System.Console.WriteLine($"\nName: {item.Name} ");
            System.Console.WriteLine($"Email: {item.Email}");
            System.Console.WriteLine($"CPF: {item.CPF}\n");
        }
    }

    public void RemoveClient()
    {
        string escolha = null;

        while (escolha != "-1")
        {
            System.Console.WriteLine("\nEnter the CPF to remove, or -1 to exit.");
            System.Console.Write("CPF: ");
            string cpfString = Console.ReadLine();
            escolha = cpfString;

            if (escolha != "-1")
            {
                if (!VCpf(cpfString))
            {
                System.Console.WriteLine("\nInvalid CPF!");
                continue;
            }

            Client client = Clients.Find(c => c.CPF == cpfString);
            if (client == null)
            {
                System.Console.WriteLine("\nClient not found!");
            }
            else
            {
                Clients.Remove(client);
                System.Console.WriteLine("\nRemove Sucessfuly");
                break;
            }
            }
        }
    }

}
