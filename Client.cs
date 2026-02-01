public class Client
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int CPF { get; private set; }

    public Client(string name, string email, int cpf)
    {
        Name = name;
        Email = email;
        CPF = cpf;
    }

}