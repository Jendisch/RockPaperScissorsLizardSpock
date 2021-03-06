﻿using System;
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
            SetNumberPlayers();
            while (playerOne.playerScore < 2 && playerTwo.playerScore < 2 )
            {
                SetPlayerTurn();
                FindWinner();
            }
            SQLConnection connect = new SQLConnection();
            connect.InsertData(playerOne.playerName, playerOne.playerScore);
            connect.InsertData(playerTwo.playerName, playerTwo.playerScore);
            RevealWinner();
            AskForResults();
            Console.ReadKey();
        }




        private void WelcomeToGame()
        {
            Console.WriteLine("Welcome to Rock, Paper, Scissors, Lizard, Spock!\nIf you are already familiar with the rules of the game, press any key to continue.");
            Console.WriteLine("The rules are as follows:\nScissors cuts Paper.\nPaper covers Rock.\nRock crushes Lizard.\nLizard poisons Spock.\nSpock smashes Scissors.\nScissors decapitates Lizard.\nLizard eats Paper.\nPaper disproves Spock.\nSpock vaporizes Rock.\n(and as it always has...) Rock crushes Scissors.");
            Console.WriteLine("Best 2/3 wins. Good luck!\nPress any key to continue.");
            Console.ReadKey();
        }

        private void SetNumberPlayers()
        {
            Console.WriteLine("How many people are planning to play the game? 1 or 2?");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("It looks like it's you versus the computer... may the odds be ever in your favor!");
                    playerOne = new Human();
                    Console.WriteLine("Please enter your name player one.");
                    playerOne.SetPlayerName();
                    playerTwo = new AI();
                    playerTwo.SetPlayerName();
                    break;
                case "2":
                    Console.WriteLine("Human versus Human huh? Have fun you two!");
                    playerOne = new Human();
                    Console.WriteLine("Please enter your name player one.");
                    playerOne.SetPlayerName();
                    playerTwo = new Human();
                    Console.WriteLine("Please enter your name player two.");
                    playerTwo.SetPlayerName();
                    break;
                default:
                    Console.WriteLine("Not a valid response. Please choose either '1' or '2'.");
                    SetNumberPlayers();
                    break;
            }
        }

        private void SetPlayerTurn()
        {
            Console.WriteLine("\n" + playerOne.playerName + " you're up!");
            playerOne.PickAction();
            Console.WriteLine("\n" + playerTwo.playerName + " you're up!");
            playerTwo.PickAction();
        }

        private void FindWinner()
        {
            int roundWinner = ((5 + playerOne.playerChoice -playerTwo.playerChoice) % 5);
            if (roundWinner == 1 || roundWinner == 3)
            {
                playerOne.playerScore += 1;
                Console.WriteLine(playerOne.actualWord + " versus " + playerTwo.actualWord + ".");
                Console.WriteLine("Player one wins!");
            }
            else if (roundWinner == 2 || roundWinner == 4)
            {
                playerTwo.playerScore += 1;
                Console.WriteLine(playerOne.actualWord + " versus " + playerTwo.actualWord + ".");
                Console.WriteLine("Player two wins!");
            }
            else if (roundWinner == 0)
            {
                Console.WriteLine("It's a tie! Let's begin another round. Press any key to continue.");
                Console.ReadKey();
                SetPlayerTurn();
            }

        }

        private void RevealWinner()
        {
            if (playerOne.playerScore == 2)
            {
                Console.WriteLine("Congrats player one! You won!");
            }
            else if (playerTwo.playerScore == 2)
            {
                Console.WriteLine("Congrats player two! You won!");
            }
        }

        public void AskForResults()
        {
            Console.WriteLine("Would you like to see the High Scorers for Rock Paper Scissors Lizard Spock? Yes or no?");
            string choice = Console.ReadLine();
            string choiceLower = choice.ToLower();
            switch (choiceLower)
            {
                case "yes":
                    SQLConnection connect = new SQLConnection();
                    string highScorers = connect.CreateConnection();
                    Console.WriteLine(highScorers);
                    Console.WriteLine("Press any key to end the game.");
                    break;
                case "no":
                    Console.WriteLine("No problem, thanks for playing! Press any key to end the game.");
                    break;
                default:
                    Console.WriteLine("Not a valid response. Please choose 'yes' or 'no'.");
                    AskForResults();
                    break;
            }
        }


    }
}

