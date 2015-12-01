using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship
{
    public class AILogic
    {
        private int x;
        private int y;
        private bool shipHit = false;
        private bool shipSunk =  false;

        public AILogic()
        {
            Player AI = new Player();
            AI.Name = "Computer";
        }

        public void placeShips()
        {
            //Need ship placement class
        }

        public void shootShip()
        {
            //Get last shot status
            if (shipHit) hit();
            else if (shipSunk) miss();
            else miss();
        }

        public void miss()
        {
            Square attackSquare = new Square();
            Shot shootShip = new Shot();

            Random rnd = new Random();
            x = rnd.Next(10);

            /// <summary>
            /// AI will guess a random square.
            /// Guess squares will be every other square
            /// to eliminate guesses next to each other
            /// Square locations will be;
            /// x = even, y = odd or vicversa
            /// </summary>
            if (x % 2 == 0) y = 1 + 2 * rnd.Next(5);
            else y = 2 * rnd.Next(5);

            attackSquare.setXLoc(x);
            attackSquare.setYLoc(y);
            shootShip.setTarget(attackSquare);  
        }

        public void hit()
        {
            //from previous hit location
            // x +- 1
            // or
            // y +- 1
            // if next shot is a hit
            // coninue on axis that had hit
            // else if next shot miss
            // go on other axis
            // stop when ship is sunk
        }
    }
}
