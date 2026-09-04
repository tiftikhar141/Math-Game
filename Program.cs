using System.Buffers;
using System.Collections.Generic;

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

            if (menuOption == 1)
            {
                Calculations(1);
            }
            if (menuOption == 2)
            {
                Calculations(2);
            }
            if (menuOption == 3)
            {
                Calculations(3);
            }
            if (menuOption == 4)
            {
                Calculations(4);
            }
            if (menuOption == 5) 
            {
                Calculations(5);
            }
            if (menuOption == 6)
            {  
                Calculations(6);
            }

        }
        static void Calculations(int operation)
        {
            var random = new Random();
            int number1, number2;
            int userAnswer;
            int correctAnswer = 0;
            int score = 0;
            string sign = "";

            string currentResult = "";
            List<string> pastResults = new List<string>();

            int numOfQuestions = 0;

            if (operation != 6) {
                Console.WriteLine("How many questions? ");
                numOfQuestions = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < numOfQuestions; i++)
                {
                    do
                    {
                        number1 = (int)random.NextInt64(1, 101);
                        number2 = (int)random.NextInt64(1, 101); // start range at 1 to avoid divide by 0 error
                    } while (number1 % number2 != 0);

                    int additionAnswer = number1 + number2;
                    int subtractionAnswer = number1 - number2;
                    int multiplicationAnswer = number1 * number2;
                    int divisionAnswer = number1 / number2;

                    string[] operationSigns = [" + ", " - ", " x ", " ÷ "];

                    int[] randomAnswer = [additionAnswer, subtractionAnswer, multiplicationAnswer, divisionAnswer];
                    int randomIndex = (int)random.NextInt64(0, 4);

                    if (operation == 1)
                    {
                        sign = operationSigns[0];
                        correctAnswer = additionAnswer;
                    }
                    if (operation == 2)
                    {
                        sign = operationSigns[1];
                        correctAnswer = subtractionAnswer;
                    }
                    if (operation == 3)
                    {
                        sign = operationSigns[2];
                        correctAnswer = multiplicationAnswer;
                    }
                    if (operation == 4)
                    {
                        sign = operationSigns[3];
                        correctAnswer = divisionAnswer;
                    }
                    if (operation == 5)
                    {
                        sign = operationSigns[randomIndex];
                        correctAnswer = randomAnswer[randomIndex];
                    }

                    Console.WriteLine(number1 + sign + number2); // print question
                    userAnswer = Convert.ToInt32(Console.ReadLine()); // get answer

                    if (userAnswer == correctAnswer)
                    {
                        score++;
                        Console.WriteLine("Correct!");
                    }
                    else
                    {
                        Console.WriteLine("Wrong, the correct answer was " + correctAnswer);
                    }

                    currentResult = number1 + sign + number2 + "\nYour Answer: " + userAnswer + "\nCorrect Answer: " + correctAnswer; // store q & a info inside string
                    pastResults.Add(currentResult); // add q & a info of current question to past results list
                }
            }

            //foreach (string result in pastResults)
            //{
            //    Console.WriteLine(result);
            //}

            Console.WriteLine("length of past results list: " + pastResults.Count); // count is being saved at the end, but goes back to 0 when doing a new operation

            if (operation == 6)
            {
                //if (pastResults.Count == 0)
                //{
                //    Console.WriteLine("Past Results do not exist");
                //} else
                //{
                //    foreach (string result in pastResults)
                //    {
                //        Console.WriteLine(result);
                //    }
                //}
                Console.WriteLine("length of past results list: " + pastResults.Count); 

            }

            Console.WriteLine("Final Score: " + score + "/" + numOfQuestions);
            GameMenu();
        }
        
    }
}
