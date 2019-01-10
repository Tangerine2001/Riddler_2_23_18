using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

/* https://fivethirtyeight.com/features/can-you-rescue-the-paratroopers/
 * 
 * You have one token, and I have two tokens. Naturally, we both crave 
 * more tokens, so we play a game of skill that unfolds over a number 
 * of rounds in which the winner of each round gets to steal one token 
 * from the loser. The game itself ends when one of us is out of tokens 
 * — that person loses. Suppose that you’re better than me at this game 
 * and that you win each round two-thirds of the time and lose one-third 
 * of the time.
 *
 * What is your probability of winning the game?
 */

namespace Riddler_2_23_18
{
    class Program
    {
        static int player = 1;
        static int opponent = 2;
        static float totalGames;
        static float totalWins;
        static float winProb;

        static void Main(string[] args)
        {
            totalGames = 100000;

            playGame(totalGames);
            winProb = (totalWins / totalGames) * 100;
            Debug.WriteLine("Total Wins: " + totalWins);
            Debug.WriteLine("Total Games: " + totalGames);
            Debug.WriteLine("Win Chance: " + Math.Round(winProb, 2) + "%");
        }

        public static void playGame(float games)
        {
            while (games != 0)
            {
                player = 1;
                opponent = 2;

                while (player != 0 && opponent != 0)
                {
                    Random rand = new Random();
                    int r = rand.Next(1, 4);
                    if (r <= 2)
                    {
                        player++;
                        opponent--;
                    }
                    else
                    {
                        opponent++;
                        player--;
                    }
                }

                if(player > opponent)
                {
                    totalWins++;
                } 
                games--;
            }
        }
    }
}
