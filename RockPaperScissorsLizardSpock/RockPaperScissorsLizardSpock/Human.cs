using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    class Human : Player
    {

        public override void SetPlayerName()
        {
            playerName = Console.ReadLine();
        }

        public override void PickAction()
        {
            Console.WriteLine("Please pick either rock, paper, scissors, lizard, or spock. Type in your choice.");
            string choice = Console.ReadLine();
            string choiceLower = choice.ToLower();
            switch (choiceLower)
            {
                case "rock":
                    actualWord = "rock";
                    playerChoice = 0;
                    break;
                case "paper":
                    actualWord = "paper";
                    playerChoice = 1;
                    break;
                case "scissors":
                    actualWord = "scissors";
                    playerChoice = 2;
                    break;
                case "spock":
                    actualWord = "spock";
                    playerChoice = 3;
                    break;
                case "lizard":
                    actualWord = "lizard";
                    playerChoice = 4;
                    break;
                default:
                    Console.WriteLine("Not a valid response. Please pick one of the options below.");
                    PickAction();
                    break;
            }
            Console.WriteLine("Looks like you chose " + actualWord + ". Good choice! Let's see what your opponent chooses.");

        }

    }
}
