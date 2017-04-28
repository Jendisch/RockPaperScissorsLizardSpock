using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    abstract class Player
    {

        public int playerScore;
        public int playerChoice;
        public string actualWord;
        public string playerName;        

        public abstract void SetPlayerName();

        public abstract void PickAction();

    }
}
