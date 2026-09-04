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

            List<string> pastResults = new List<string>();

            int numOfQuestions;
            Console.WriteLine("How many questions? ");
            numOfQuestions = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numOfQuestions; i++)
            {
                do
                {
                    number1 = (int)random.NextInt64(1, 101);
                    number2 = (int)random.NextInt64(1, 101); // start range at 1 to avoid divide by 0 error
                } while (number1 % number2 != 0);

                string[] operationSigns = [" + ", " - ", " x ", " ÷ "];
                int[] answers = [number1 + number2, number1 - number2, number1 * number2, number1 / number2];
                int randomIndex = (int)random.NextInt64(0, 4);

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
                    sign = operationSigns[randomIndex];
                    correctAnswer = answers[randomIndex];
                }

                string question = number1 + sign + number2;

                Console.WriteLine(question); // print question
                userAnswer = Convert.ToInt32(Console.ReadLine()); // get answer

                string questionResult;

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

                // add data into list
                pastResults.Add(question);
                pastResults.Add(Convert.ToString(userAnswer));
                pastResults.Add(questionResult);
            }


            Console.WriteLine("PAST RESULTS: \n===============================");
            foreach (string result in pastResults)
            {
                Console.WriteLine(result);
            }

            Console.WriteLine("length of past results list: " + pastResults.Count); // count is being saved at the end, but goes back to 0 when doing a new operation

            /* 
             We have a working list
             at the end of each round (after all questions are updated) list is up to date with all q & a data of the previous questions
             problem: the list goes back to being empty once a new operation starts
             what should happen: list should stay up to date with question data even after new operation is selected
             */

            Console.WriteLine("Final Score: " + score + "/" + numOfQuestions);
            //GameMenu();
        }
        
    }
}
