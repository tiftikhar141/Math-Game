namespace math_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //menu();
            //calculations(1);

            // print out 5 math questions
            var random = new Random();

            for (int i = 0; i < 5; i++)
            {
                int number1 = (int)random.NextInt64(0, 100);
                int number2 = (int)random.NextInt64(0, 100);

                int additionAnswer = number1 + number2;
                int subtractionAnswer = number1 - number2;
                int multiplicationAnswer = number1 * number2;
                int divisionAnswer = number1 / number2;

                int userAnswer;

                Console.WriteLine(number1 + " + " + number2);
                userAnswer = Convert.ToInt32(Console.ReadLine());

                if (userAnswer == additionAnswer) {
                    Console.WriteLine("correct");
                } else {
                    Console.WriteLine("wrong");
                }

            }
            


        }

        static int calculations(int operation)
        {
            var random = new Random();
            int number = (int)random.NextInt64(0, 100);



            return 0;

        }

        static void menu()
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
