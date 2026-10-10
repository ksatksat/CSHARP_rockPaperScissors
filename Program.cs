using System;
namespace RockPapperScossor
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager gm = new GameManager();
            do
            {
                RoundResult result = gm.PlayRound();
                if (result == RoundResult.Player_1_wins)
                {
                    Console.WriteLine("Player 1 - Wins !");
                }
                else if (result == RoundResult.Player_2_wins)
                {
                    Console.WriteLine("Player 2 - Wins !");
                }
                else
                {
                    Console.WriteLine("It's a Draw !");
                }
                Console.WriteLine("Play Again (Y/N) ?");
            } while (Console.ReadLine().ToUpper() == "Y");
            Console.WriteLine("Exiting from game ...");
        }
    }
    class GameManager
    {
        Random _rnd = new Random();
        public RoundResult PlayRound()
        {
            Choice p_1;
            do
            {
                Console.Write("Enter Choice (R)ock, (P)apper, or (S)cissors: ");
                string input = Console.ReadLine().ToUpper();
                if (input == "R")
                {
                    p_1 = Choice.Rock;
                    Console.WriteLine($"Player 1 picked {p_1}");
                    break;
                }
                else if (input == "P")
                {
                    p_1 = Choice.Papper;
                    Console.WriteLine($"Player 1 picked {p_1}");
                    break;
                }
                else if (input == "S")
                {
                    p_1 = Choice.Scissors;
                    Console.WriteLine($"Player 1 picked {p_1}");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Choice Try Again ... ");
                }
            } while (true);
            //player 2 is bot
            Choice p_2 = (Choice)_rnd.Next(0, 3);
            Console.WriteLine($"Player 2 picked {p_2.ToString()}");
            if (p_1 == p_2)
            {
                return RoundResult.Draw;
            }
            if (p_1 == Choice.Rock && p_2 == Choice.Scissors
            || p_1 == Choice.Papper && p_2 == Choice.Rock
            || p_1 == Choice.Scissors && p_2 == Choice.Papper)
            {
                return RoundResult.Player_1_wins;
            }
            return RoundResult.Player_2_wins;
        }

    }
    public enum RoundResult
    {
        Player_1_wins,
        Player_2_wins,
        Draw
    }
    public enum Choice
    {
        Rock,
        Papper,
        Scissors
    }
}