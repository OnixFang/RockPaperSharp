using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager.StartGame();
        }
    }

    static class GameManager
    {
        static int PlayerScore = 0;
        static int ComputerScore = 0;

        public static void StartGame()
        {
            GameScreen.DrawPlayerChoices();
        }

        static void CompareChoices()
        {

        }

        static class GameScreen
        {
            static void DrawTitle()
            {
                Console.WriteLine("------------------------------- RockPaperSharp -------------------------------");
            }

            static void DrawScores()
            {
                Console.WriteLine("Player Wins  : " + PlayerScore);
                Console.WriteLine("Computer Wins: " + ComputerScore);
            }

            internal static void DrawPlayerChoices()
            {
                DrawTitle();
                DrawScores();

                Console.WriteLine("Choose your weapon!" + Environment.NewLine);
                Console.WriteLine("1. Rock");
                Console.WriteLine("2. Paper");
                Console.WriteLine("3. Scisors" + Environment.NewLine);
                Console.Write("Enter the number of your weapon: ");

                Player.Choice = Convert.ToInt32(Console.ReadLine());
            }
        }

        static class Player
        {
            internal static int Choice { get; set; }
        }

        static class Computer
        {
            internal static int Choice = 1;

            internal static void GenerateChoice()
            {
                Random rnd = new Random();

                Choice = rnd.Next(1, 4);
            }
        }
    }



    enum Choices
    {
        Rock = 1,
        Paper,
        Scisors
    }
}
