using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship
{
    public class GameController
    {
        private int playerTurn;
        private bool gameOver;

        public GameController()
        {
            playerTurn = 1;
            gameOver = false;
        }
        public GameController(int p)
        {
            playerTurn = p;
            gameOver = false;
        }
        public int getPlayerTurn()
        {
            return playerTurn;
        }
        public void setGameOver(bool go)
        {
            gameOver = go;
        }
        public bool isGameOver()
        {
            return gameOver;
        }
        public void passTurn()
        {
            playerTurn++;
            if (playerTurn > 2) playerTurn = 1;
        }
        public void resetGame()
        {
            playerTurn = 1;
            gameOver = false;
            //create new state of game
        }

    }
}
