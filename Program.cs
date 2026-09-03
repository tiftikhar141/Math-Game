namespace math_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int menuOption;
            do
            {
                Console.WriteLine("Choose your operation:\n1) Addition, 2) Subtraction, 3) Multiplication, 4) Division, 5) Previous Results");
                menuOption = Convert.ToInt32(Console.ReadLine());

                if (menuOption < 1 || menuOption > 5)
                {
                    Console.WriteLine("Inavlid option, please try again.");
                }

            } while (menuOption < 1 || menuOption > 5);

            if (menuOption == 1) 
            {
                Console.WriteLine("Addition");
            }
            if (menuOption == 2) 
            {
                Console.WriteLine("Subtraction");
            }
            if (menuOption == 3)
            {
                Console.WriteLine("Multiplication");
            }
            if (menuOption == 4)
            {
                Console.WriteLine("Division");
            }
            if (menuOption == 5)
            {
                Console.WriteLine("Past Results");
            }



        }
    }
}
