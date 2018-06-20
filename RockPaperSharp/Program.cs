using System;

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
            Computer.GenerateChoice();
            GameScreen.DrawResults(CompareChoices());
            PlayAgain();
        }

        static void PlayAgain()
        {
            int decision;

            Console.WriteLine("Play again? 1: Yes; Any key: No");

            try
            {
                decision = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                decision = 0;
            }

            if (decision == 1)
            {
                StartGame();
            }
        }

        static string CompareChoices()
        {
            string result;

            switch (Player.Choice)
            {
                case Choices.Rock:
                    switch (Computer.Choice)
                    {
                        case Choices.Rock:
                            result = "Draw!";
                            break;
                        case Choices.Paper:
                            result = "Computer wins!!";
                            ComputerScore++;
                            break;
                        case Choices.Scisors:
                            result = "Player wins!";
                            PlayerScore++;
                            break;
                        default:
                            result = "An error occurred.";
                            break;
                    }
                    break;
                case Choices.Paper:
                    switch (Computer.Choice)
                    {
                        case Choices.Rock:
                            result = "Player wins!";
                            PlayerScore++;
                            break;
                        case Choices.Paper:
                            result = "Draw!";
                            break;
                        case Choices.Scisors:
                            result = "Computer wins!!";
                            ComputerScore++;
                            break;
                        default:
                            result = "An error occurred.";
                            break;
                    }
                    break;
                case Choices.Scisors:
                    switch (Computer.Choice)
                    {
                        case Choices.Rock:
                            result = "Computer wins!!";
                            ComputerScore++;
                            break;
                        case Choices.Paper:
                            result = "Player wins!";
                            PlayerScore++;
                            break;
                        case Choices.Scisors:
                            result = "Draw!";
                            break;
                        default:
                            result = "An error occurred.";
                            break;
                    }
                    break;
                default:
                    result = "An error occurred.";
                    break;
            }

            return result;
        }

        static class GameScreen
        {
            static void DrawTitle()
            {
                Console.WriteLine("------------------------------- RockPaperSharp -------------------------------");
                Console.WriteLine();
            }

            static void DrawScores()
            {
                Console.WriteLine("Player Wins  : " + PlayerScore);
                Console.WriteLine("Computer Wins: " + ComputerScore);
                Console.WriteLine();
            }

            internal static void DrawPlayerChoices()
            {
                int UserInput;

                Console.Clear();
                DrawTitle();
                DrawScores();

                Console.WriteLine("Choose your weapon!" + Environment.NewLine);
                Console.WriteLine("1. Rock");
                Console.WriteLine("2. Paper");
                Console.WriteLine("3. Scisors" + Environment.NewLine);
                Console.Write("Enter the number of your weapon: ");

                try
                {
                    UserInput = Convert.ToInt32(Console.ReadLine());
                    if (UserInput > 3)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        Player.Choice = (Choices)UserInput;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("This is not a valid answer...");
                    Console.Write("Press enter to continue");
                    Console.ReadKey();
                    DrawPlayerChoices();
                }
            }

            internal static void DrawResults(string result)
            {
                Console.Clear();
                DrawTitle();
                DrawScores();

                Console.WriteLine($"Player's choice: {Player.Choice}");
                Console.WriteLine($"Computer's choice: {Computer.Choice}");

                Console.WriteLine();
                Console.WriteLine(result);
                Console.WriteLine();
            }
        }

        static class Player
        {
            internal static Choices Choice { get; set; }
        }

        static class Computer
        {
            internal static Choices Choice = (Choices)1;

            internal static void GenerateChoice()
            {
                Random rnd = new Random();

                Choice = (Choices)rnd.Next(1, 4);
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
