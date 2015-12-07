using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship
{
    public class AIPlayer : Player
    {
        private int hitXLoc;
        private int hitYLoc;
        private bool shipHit;
        private bool shipSunk;

        public AIPlayer() : base()
        {
            this.Name = "Computer";
            shipHit = false;
            shipSunk = false;
        }

        public void shootShip()
        {
            Square attackSquare = new Square();

            if (shipHit) hit(hitXLoc, hitYLoc, attackSquare);
            else if (shipSunk) miss(attackSquare);
            else miss(attackSquare);
        }

        public void miss(Square attackSquare)
        {
            int tempXLoc, tempYloc;
            Random rnd = new Random();
            tempXLoc = rnd.Next(10);

            /// <summary>
            /// AI will fire at a random square. Guessed squares will be every other square
            /// to eliminate guesses next to each other. Square locations will be;
            /// x = even, y = odd or vice-versa
            /// </summary>
            if (tempXLoc % 2 == 0) tempYloc = 1 + 2 * rnd.Next(5);
            else tempYloc = 2 * rnd.Next(5);

            attackSquare.setXLoc(tempXLoc);
            attackSquare.setYLoc(tempYloc);

            /// <summary>
            /// Check if attackSquare shot at an empty square. If shot hits a square that
            /// has already been attacked guess a different shot. 
            /// </summary>
            if(!shoot(attackSquare))
            {
                miss(attackSquare);
            }
            /// <summary>
            /// From previous if statement, shoot function was called. attackSquare is
            /// either hit/miss. If hit save hit location and change bool values.
            /// </summary>
            else if(attackSquare.getSquareState() == State.hit)
            {
                shipHit = true;
                shipSunk = false;
                hitXLoc = tempXLoc;
                hitYLoc = tempYloc;
            }
            /// <summary>
            /// From previous if statments; attackSquare was a miss.
            /// </summary>
            else
            {
                //Do nothing; Accept Defeat
                return;
            }

        }

        public void hit(int x, int y, Square attackSquare)
        {
            Random rand = new Random();
            int guess = rand.Next(5);

            switch (guess)
            {
                case 0:
                    if (!up(x, y, attackSquare)) hit(x, y, attackSquare);
                    break;
                case 1:
                    if (!down(x, y, attackSquare)) hit(x, y, attackSquare);
                    break;
                case 2:
                    if (!left(x, y, attackSquare)) hit(x, y, attackSquare);
                    break;
                case 3:
                    if (!right(x, y, attackSquare)) hit(x, y, attackSquare);
                    break;
            }
        }

        private bool up(int x, int y, Square attackSquare)
        {
            int tempY = y--; //Shift square guess over one to the right

            /// <summary>
            /// Check to see if X value is within the gameboard.
            /// </summary>
            if (tempY <= 0)
            {
                //If true, guess to the right of the original location
                return down(x, y, attackSquare);
            }

            attackSquare.setXLoc(x);
            attackSquare.setYLoc(tempY);

            if (attackSquare.getSquareState() == State.hit)
            {
                return up(x, tempY, attackSquare);
            }
            else if (shoot(attackSquare))
            {
                //if(ship sunk) shipSunk = true; shipHit = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool down(int x, int y, Square attackSquare)
        {
            int tempY = y++; //Shift square guess over one to the right

            /// <summary>
            /// Check to see if X value is within the gameboard.
            /// </summary>
            if (tempY >= 10)
            {
                //If true guess one up of the original location
                return up(x, y, attackSquare);
            }

            attackSquare.setXLoc(x);
            attackSquare.setYLoc(tempY);

            if (attackSquare.getSquareState() == State.hit)
            {
                return down(x, tempY, attackSquare);
            }
            else if (shoot(attackSquare))
            {
                //if(ship sunk) shipSunk = true; shipHit = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool right(int x, int y, Square attackSquare)
        {
            int tempX = x++; //Shift square guess over one to the right

            /// <summary>
            /// Check to see if X value is within the gameboard.
            /// </summary>
            if (tempX >= 10)
            {
                //If true guess  to the left of the original location
                return left(x, y, attackSquare);
            }

            attackSquare.setXLoc(tempX);
            attackSquare.setYLoc(y);

            if (attackSquare.getSquareState() == State.hit)
            {
                return right(tempX, y, attackSquare);
            }
            else if (shoot(attackSquare))
            {
                //if(ship sunk) shipSunk = true; shipHit = false;
                return true;
            }
            else return false;
        }

        private bool left(int x, int y, Square attackSquare)
        {
            int tempX = x--; //Shift square guess over one to the right

            /// <summary>
            /// Check to see if X value is within the gameboard.
            /// </summary>
            if (tempX <= 0)
            {
                //If true guess  to the right of the original location
                return right(x, y, attackSquare);
            }

            attackSquare.setXLoc(tempX);
            attackSquare.setYLoc(y);

            if (attackSquare.getSquareState() == State.hit)
            {
                return left(tempX, y, attackSquare);
            }
            else if (shoot(attackSquare))
            {
                //if(ship sunk) shipSunk = true; shipHit = false;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}