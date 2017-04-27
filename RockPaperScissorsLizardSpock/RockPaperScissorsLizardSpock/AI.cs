﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    class AI : Player
    {

        Random random = new Random();

        public AI()
        {
        }

        public override void PickAction()
        {
            Console.WriteLine("Press any key to see whether the computer picks rock, paper, scissors, lizard, or spock was chosen.");
            Console.ReadKey();
            int randomPick = random.Next(0, 5);
            switch (randomPick)
            {
                case 0:
                    actualWord = "rock";
                    playerChoice = 0;
                    break;
                case 1:
                    actualWord = "paper";
                    playerChoice = 1;
                    break;
                case 2:
                    actualWord = "scissors";
                    playerChoice = 2;
                    break;
                case 3:
                    actualWord = "spock";
                    playerChoice = 3;
                    break;
                case 4:
                    actualWord = "lizard";
                    playerChoice = 4;
                    break;
                default:
                    Console.WriteLine("Not a valid response. Please pick one of the options below.");
                    PickAction();
                    break;
            }
            Console.WriteLine("Looks like the computer chose " + actualWord + ".");

        }

    }
}
