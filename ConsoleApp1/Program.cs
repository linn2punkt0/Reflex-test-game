using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's play!");
            Console.WriteLine(
                "Press spacebar to start, then you will see a letter on the screen, press the matching letter on your keyboard as fast as you can.");
            if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
            {
                Console.WriteLine();
                PlayGame();
            }
        }

        static string letters = "QWERTYUIOPASDFGHJKLZXCVBNM";
        
        private static void PlayGame()
        {
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            Console.WriteLine("Press matching key as fast as you can!");
            string randomLetter = GetRandomLetter();
            Console.WriteLine(randomLetter);

            var userInput = Console.ReadKey(true).KeyChar;
            stopwatch.Stop();
            if (!ValidateInput(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You are stupid, that's not even a letter!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                if (CompareInput(userInput, randomLetter) == true)
                {
                    string message = "Letters match!";
                    
                    System.TimeSpan time = stopwatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}.{1:00}",
                        time.Seconds,
                        time.Milliseconds / 10);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{message} Time elapsed: {elapsedTime}.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    string message = "Letters do not match!";
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
               
            }
            
            PlayAgain();




        }

        private static string GetRandomLetter()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, letters.Length - 1);
            return letters[randomNumber].ToString();
        }

        private static bool ValidateInput(char input)
        {
            if (Char.IsLetter(input))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private static bool CompareInput(char input, string random)
        {
            var userInput = Char.ToUpper(input);
            string stringInput = userInput.ToString();

            if (stringInput == random )
            {
                return true;
            }

            return false;
        }

        private static int GetTime(DateTime start, DateTime end)
        {
            return end.Millisecond - start.Millisecond;
        }

        private static void PlayAgain()
        {
            Console.WriteLine("Play again? Press the spacebar.");
            if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
            {
                Console.WriteLine();
                PlayGame();
            }
        }
    }
}
