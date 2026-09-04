//using System.Buffers;
//using System.Collections.Generic;

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
            do
            {
                Console.WriteLine("Choose your operation:\n1) Addition, 2) Subtraction, 3) Multiplication, 4) Division, 5) Random, 6) Previous Results");
                menuOption = Convert.ToInt32(Console.ReadLine());

                if (menuOption < 1 || menuOption > 6)
                {
                    Console.WriteLine("Inavlid option, please try again.");
                }

            } while (menuOption < 1 || menuOption > 6);

            Calculations(menuOption);
        }
        static void Calculations(int operation)
        {
            var random = new Random();
            int number1, number2;
            int userAnswer;
            int correctAnswer = 0;
            int score = 0;
            string sign = "";
            string questionResult;
            string finalResult;

            string[] operationSigns = [" + ", " - ", " x ", " ÷ "];
            
            List<string> pastResults = new();
            
            if (operation != 6)
            {
                Console.WriteLine("How many questions? ");
                int numOfQuestions = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < numOfQuestions; i++)
                {
                    do
                    {
                        number1 = (int)random.NextInt64(1, 101);
                        number2 = (int)random.NextInt64(1, 101); // start range at 1 to avoid divide by 0 error
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
                        int randomIndex = (int)random.NextInt64(0, 4);
                        sign = operationSigns[randomIndex];
                        correctAnswer = answers[randomIndex];
                    }

                    string question = number1 + sign + number2 + " = ?";

                    Console.WriteLine(question); // print question
                    userAnswer = Convert.ToInt32(Console.ReadLine()); // get answer

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
    }
}
