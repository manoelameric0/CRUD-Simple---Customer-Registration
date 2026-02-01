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

            int operation = int.Parse(Console.ReadLine()!);
            

            switch (operation)
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
                    Console.WriteLine("Option invalid!");
                    break;
            }
        }
        
    }
}