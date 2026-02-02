using CustomerRegistration;

public class Program
{
    
    static void Main()
    {
        var adm = new GClient();
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

            string operation = Console.ReadLine();
            if (!int.TryParse(operation, out int a))
            {
                System.Console.WriteLine("Invalid\nWrite 1 at 5");
            }
            

            switch (a)
            {
                case 1:
                    adm.AddClient();
                    break;
                case 2:
                    adm.EditClient();
                    break;
                case 3:
                    adm.ViewClient();
                    break;
                case 4:
                    adm.RemoveClient();
                    break;
                case 5:
                    execution = false;
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("\nOption invalid!");
                    break;
            }
            
        }
        
    }
}