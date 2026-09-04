namespace math_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameMenu();
        }
        static void GameMenu()
        {
            int menuOption;
            int numOfQuestions;
            do
            {
                Console.WriteLine("Choose your operation:\n1) Addition, 2) Subtraction, 3) Multiplication, 4) Division, 5) Random, 6) Previous Results");
                menuOption = Convert.ToInt32(Console.ReadLine());
            } while (menuOption < 1 || menuOption > 6);

            if (menuOption == 6)
            {
                DisplayResults();
            }

            Console.WriteLine("How many questions? ");
            numOfQuestions = Convert.ToInt32(Console.ReadLine());

            Calculations(menuOption, numOfQuestions);
        }
        static void Calculations(int operation, int numOfQuestions)
        {
            int number1, number2;
            int userAnswer;
            int correctAnswer = 0;
            int score = 0;
            string sign = "";
            string questionResult;
            string finalResult;

            string[] operationSigns = [" + ", " - ", " x ", " ÷ "];
            
            List<string> pastResults = new();
            
            for (int i = 0; i < numOfQuestions; i++)
            {
                do
                {
                    number1 = Random.Shared.Next(1, 101);
                    number2 = Random.Shared.Next(1, 101); // start range at 1 to avoid divide by 0 error
                } while (number1 % number2 != 0);

                int[] answers = [number1 + number2, number1 - number2, number1 * number2, number1 / number2];

                if (operation == 1)
                {
                    sign = operationSigns[0];
                    correctAnswer = answers[0];
                }
                if (operation == 2)
                {
                    sign = operationSigns[1];
                    correctAnswer = answers[1];
                }
                if (operation == 3)
                {
                    sign = operationSigns[2];
                    correctAnswer = answers[2];
                }
                if (operation == 4)
                {
                    sign = operationSigns[3];
                    correctAnswer = answers[3];
                }
                if (operation == 5)
                {
                    int randomValue = Random.Shared.Next(0, 4); // need same index so question and answer match
                    sign = operationSigns[randomValue];
                    correctAnswer = answers[randomValue];
                }

                string question = number1 + sign + number2 + " = ?";

                Console.WriteLine(question); 
                userAnswer = Convert.ToInt32(Console.ReadLine()); 

                if (userAnswer == correctAnswer)
                {
                    score++;
                    questionResult = "Correct!";
                    Console.WriteLine(questionResult);
                }
                else
                {
                    questionResult = "Incorrect! The correct answer is " + correctAnswer;
                    Console.WriteLine(questionResult);
                }

                finalResult = "Final Score: " + score + "/" + numOfQuestions;

                // add data into list
                pastResults.Add(question);
                pastResults.Add(Convert.ToString(userAnswer));
                pastResults.Add(questionResult);
                    
                // ONLY after last question has been asked
                if (i == numOfQuestions - 1)
                {
                    pastResults.Add(finalResult);
                    Console.WriteLine(finalResult);
                    GameMenu();
                }
            }
            

            if (pastResults.Count > 0)
            {
                Console.WriteLine("PAST RESULTS:\n==============================================");
                foreach (string pastResult in pastResults)
                {
                    Console.WriteLine(pastResult);
                }
            } 
        }

        static void DisplayResults()
        {
            Console.WriteLine("Results LOL");
            GameMenu();
        }
    }
}
