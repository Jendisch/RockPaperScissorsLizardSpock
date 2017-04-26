using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    class Game
    {
        public Player playerOne;
        public Player playerTwo;

        public void StartGame()
        {
            WelcomeToGame();
            GetNumberPlayers();
            while (playerOne.playerScore < 3 || playerTwo.playerScore < 3 )
            {
                PlayerTurn();
                FindWinner();
                Console.ReadKey();
            }
        }

        public void WelcomeToGame()
        {
            Console.WriteLine("Welcome to Rock, Paper, Scissors, Lizard, Spock!\nIf you are already familiar with the rules of the game, press any key to continue.");
            Console.WriteLine("The rules are as follows:\nScissors cuts Paper.\nPaper covers Rock.\nRock crushes Lizard.\nLizard poisons Spock.\nSpock smashes Scissors.\nScissors decapitates Lizard.\nLizard eats Paper.\nPaper disproves Spock.\nSpock vaporizes Rock.\n(and as it always has...) Rock crushes Scissors.");
            Console.WriteLine("Best 2/3 wins. Good luck!\nPress any key to continue.");
            Console.ReadKey();
        }

        public void GetNumberPlayers()
        {
            Console.WriteLine("How many people are planning to play the game? 1 or 2?");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("It looks like it's you versus the computer... may the odds be ever in your favor!");
                    playerOne = new Human();
                    playerTwo = new AI();
                    break;
                case "2":
                    Console.WriteLine("Human versus Human huh? Have fun you two!");
                    playerOne = new Human();
                    playerTwo = new Human();
                    break;
                default:
                    Console.WriteLine("Not a valid response. Please choose either '1' or '2'.");
                    GetNumberPlayers();
                    break;
            }
        }

        public void PlayerTurn()
        {
            Console.WriteLine("Player 1, you're up!");
            playerOne.PickAction();
            Console.WriteLine("Player 2, you're up!");
            playerTwo.PickAction();
        }

        public void FindWinner()
        {
            int roundWinner = ((5 + playerOne.playerChoice -playerTwo.playerChoice) % 5);
            if (roundWinner == 1 || roundWinner == 3)
            {
                playerOne.playerScore += 1;
                Console.WriteLine("Player one wins!");
            }
            else if (roundWinner == 2 || roundWinner == 4)
            {
                playerTwo.playerScore += 1;
                Console.WriteLine("Player two wins!");
            }
            else if (roundWinner == 0)
            {
                Console.WriteLine("It's a tie! Let's begin another round. Press any key to continue.");
                Console.ReadKey();
                PlayerTurn();
            }

        }

    }
}


//if(menu.playerOne.playerChoice == "scissors" && menu.playerTwo.playerChoice == "paper")
//{
//    Console.WriteLine("Scissors cuts paper! Player one wins.");
//}
//else if (menu.playerOne.playerChoice == "paper" && menu.playerTwo.playerChoice == "rock")
//{
//    Console.WriteLine("Paper covers rock! Player one wins");
//}
//else if (menu.playerOne.playerChoice == "rock" && menu.playerTwo.playerChoice == "lizard")
//{
//    Console.WriteLine("Rock crushes lizard! Player one wins");
//}
//else if (menu.playerOne.playerChoice == "lizard" && menu.playerTwo.playerChoice == "spock")
//{
//    Console.WriteLine("Lizard poisons Spock! Player one wins");
//}
//else if (menu.playerOne.playerChoice == "spock" && menu.playerTwo.playerChoice == "scissors")
//{
//    Console.WriteLine("Spock smashes Scissors! Player one wins");
//}
//else if (menu.playerOne.playerChoice == "scissors" && menu.playerTwo.playerChoice == "lizard")
//{
//    Console.WriteLine("Scissors decapitates Lizard! Player one wins");
//}
//else if (menu.playerOne.playerChoice == "lizard" && menu.playerTwo.playerChoice == "paper")
//{
//    Console.WriteLine("Lizard eats Paper! Player one wins");
//}
//else if (menu.playerOne.playerChoice == "paper" && menu.playerTwo.playerChoice == "spock")
//{
//    Console.WriteLine("Paper disproves Spock! Player one wins");
//}
//else if (menu.playerOne.playerChoice == "spock" && menu.playerTwo.playerChoice == "rock")
//{
//    Console.WriteLine("Spock vaporizes Rock! Player one wins");
//}
//else if (menu.playerOne.playerChoice == "rock" && menu.playerTwo.playerChoice == "scissors")
//{
//    Console.WriteLine("Rock crushes scissors! Player one wins");
//}
//else if (menu.playerTwo.playerChoice == "scissors" && menu.playerOne.playerChoice == "paper")
//{
//    Console.WriteLine("Scissors cuts paper! Player two wins.");
//}
//else if (menu.playerTwo.playerChoice == "paper" && menu.playerOne.playerChoice == "rock")
//{
//    Console.WriteLine("Paper covers rock! Player two wins");
//}
//else if (menu.playerTwo.playerChoice == "rock" && menu.playerOne.playerChoice == "lizard")
//{
//    Console.WriteLine("Rock crushes lizard! Player two wins");
//}
//else if (menu.playerTwo.playerChoice == "lizard" && menu.playerOne.playerChoice == "spock")
//{
//    Console.WriteLine("Lizard poisons Spock! Player two wins");
//}
//else if (menu.playerTwo.playerChoice == "spock" && menu.playerOne.playerChoice == "scissors")
//{
//    Console.WriteLine("Spock smashes Scissors! Player two wins");
//}
//else if (menu.playerTwo.playerChoice == "scissors" && menu.playerOne.playerChoice == "lizard")
//{
//    Console.WriteLine("Scissors decapitates Lizard! Player two wins");
//}
//else if (menu.playerTwo.playerChoice == "lizard" && menu.playerOne.playerChoice == "paper")
//{
//    Console.WriteLine("Lizard eats Paper! Player two wins");
//}
//else if (menu.playerTwo.playerChoice == "paper" && menu.playerOne.playerChoice == "spock")
//{
//    Console.WriteLine("Paper disproves Spock! Player two wins");
//}
//else if (menu.playerTwo.playerChoice == "spock" && menu.playerOne.playerChoice == "rock")
//{
//    Console.WriteLine("Spock vaporizes Rock! Player two wins");
//}
//else if (menu.playerTwo.playerChoice == "rock" && menu.playerOne.playerChoice == "scissors")
//{
//    Console.WriteLine("Rock crushes scissors! Player two wins");
//}
//else
//{
//    Console.WriteLine("It's a tie! Let's begin another round. Press any key to continue.");
//    Console.ReadKey();
//    PlayerTurn();
//}
