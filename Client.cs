public class Client
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string CPF { get; private set; }

    public Client(string name, string email, string cpf)
    {
        Name = name;
        Email = email;
        CPF = cpf;
    }
}