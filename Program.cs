namespace math_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            menu();
        }
        static void menu()
        {
            int menuOption;
            do
            {
                Console.WriteLine("Choose your operation:\n1) Addition, 2) Subtraction, 3) Multiplication, 4) Division");
                menuOption = Convert.ToInt32(Console.ReadLine());

                if (menuOption < 1 || menuOption > 4)
                {
                    Console.WriteLine("Inavlid option, please try again.");
                }

            } while (menuOption < 1 || menuOption > 5);

            if (menuOption == 1)
            {
                calculations(1);
            }
            if (menuOption == 2)
            {
                calculations(2);
            }
            if (menuOption == 3)
            {
                calculations(3);
            }
            if (menuOption == 4)
            {
                calculations(4);
            }

        }
        static void calculations(int operation)
        {

            // print out 5 math questions
            var random = new Random();
            int userAnswer;
            int correctAnswer = 0;
            string operationSign = ",";

            for (int i = 0; i < 5; i++)
            {
                int number1 = (int)random.NextInt64(0, 100);
                int number2 = (int)random.NextInt64(0, 100);

                int additionAnswer = number1 + number2;
                int subtractionAnswer = number1 - number2;
                int multiplicationAnswer = number1 * number2;
                int divisionAnswer = number1 / number2;

                if (operation == 1)
                {
                    operationSign = "+";
                    correctAnswer = additionAnswer;
                }
                if (operation == 2)
                {
                    operationSign = "-";
                    correctAnswer = subtractionAnswer;
                }
                if (operation == 3)
                {
                    operationSign = "x";
                    correctAnswer = multiplicationAnswer;
                }
                if (operation == 4)
                {
                    operationSign = "÷";
                    correctAnswer = divisionAnswer;
                }

                Console.WriteLine(number1 + operationSign + number2);
                userAnswer = Convert.ToInt32(Console.ReadLine());

                if (userAnswer == correctAnswer)
                {
                    Console.WriteLine("Correct!");
                } else
                {
                    Console.WriteLine("Wrong");
                }
            }
        }

        
    }
}
