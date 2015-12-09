using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship
{
    public partial class AIPlayer : Player
    {
        private int hitXLoc;
        private int hitYLoc;
        private bool shipHit;
        private bool shipSunk;
        private bool horizontal;

        public AIPlayer() : base()
        {
            this.Name = "Computer";
            shipHit = false;
            shipSunk = false;
            hitXLoc = 0;
            hitYLoc = 0;
           
        }

        public void attackEnemy()
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
            int guess = rand.Next(1001) % 4;

            /// <summary>
            /// When up/down/left/right returns false, the guess shot was already attacked.
            ///  Guess a new shot
            /// </summary>
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

        // Check if ship being attack has been sunk
        private bool checkIfSunk(Square attackSquare, bool horizontal)
        {
            if (horizontal)
            {
                return checkHorizontal(hitXLoc, hitYLoc, attackSquare);
            }

            return checkVertical(hitXLoc, hitYLoc, attackSquare);
        }

        /// <summary>
        /// Check vertical status of ship being attacked.
        /// A sunken ship will have miss on both ends of the ship 
        /// If the ship is at the edge the ship will have a miss on the opposite end
        /// </summary>
        private bool checkVertical(int x, int y, Square checkSquare)
        {
            int sizeOfLargestShip = 5;
            int tempY = y;

            //Looking for the end of the ship
            for(int i = 0; i <= sizeOfLargestShip; i++)
            {
                tempY -= i;
                if (tempY < 0)
                {
                    tempY = 0;
                    break;
                }
                checkSquare.setXLoc(x);
                checkSquare.setYLoc(tempY);
                
                //If the square being checked is not a hit, it must be the end of the ship
                if(checkSquare.getSquareState() != State.hit)
                {
                    break;
                }
            }

            //Starting from the end of the ship and check for a miss on both ends
            for(int i = 0; i <= sizeOfLargestShip; i++)
            {
                checkSquare.setYLoc(tempY + i);

                /// <summary>
                /// Starts from the end of ship
                /// If square status is a hit ignore
                /// If square status is a miss it is the end of the ship
                /// If square status is a not a hit or miss the ship has not been sunk
                /// </summary>
                if (checkSquare.getSquareState() == State.miss)
                {
                    return true;
                }
                else if (checkSquare.getSquareState() != State.hit)
                {
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Check horizontal status of ship being attacked.
        /// A sunken ship will have miss on both ends of the ship 
        /// If the ship is at the edge the ship will have a miss on the opposite end
        /// </summary>
        private bool checkHorizontal(int x, int y, Square checkSquare)
        {
            int sizeOfLargestShip = 5;
            int tempX = x;

            for (int i = 0; i <= sizeOfLargestShip; i++)
            {
                tempX -= i;
                if (tempX < 0)
                {
                    tempX = 0;
                    break;
                }
                checkSquare.setXLoc(tempX);
                checkSquare.setYLoc(y);

                if (checkSquare.getSquareState() != State.hit)
                {
                    break;
                }
            }

            for (int i = 0; i <= sizeOfLargestShip; i++)
            {
                checkSquare.setYLoc(tempX + i);
                if (checkSquare.getSquareState() == State.miss)
                {
                    return true;
                }
                else if (checkSquare.getSquareState() != State.hit)
                {
                    return false;
                }
            }

            return false;
        }
        private bool up(int x, int y, Square attackSquare)
        {
            horizontal = false;
            int tempY = y--; //Shift square guess up one

            /// <summary>
            /// Check to see if Y value is within the gameboard.
            /// </summary>
            if (tempY < 0)
            {
                //If true, guess down of the original location
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
                if(checkIfSunk(attackSquare, horizontal))
                {
                    shipSunk = true;
                    shipHit = false;
                }
                
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool down(int x, int y, Square attackSquare)
        {
            horizontal = false;
            int tempY = y++; //Shift square guess down one

            /// <summary>
            /// Check to see if y value is within the gameboard.
            /// </summary>
            if (tempY >= 10)
            {
                //If true guess one up of the original location
                return up(x, y, attackSquare);
            }

            attackSquare.setXLoc(x);
            attackSquare.setYLoc(tempY);

            //If the square being attacked has already been hit, keep guessing down one
            if (attackSquare.getSquareState() == State.hit)
            {
                return down(x, tempY, attackSquare);
            }
            else if (shoot(attackSquare)) //Attacking a square not yet guessed
            {
                if (checkIfSunk(attackSquare, horizontal))
                {
                    shipSunk = true;
                    shipHit = false;
                }
                return true;
            }
            else
            {
                //shoot function shot at a square that has already been attacked
                return false;
            }
        }

        private bool right(int x, int y, Square attackSquare)
        {
            horizontal = true;
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
                if (checkIfSunk(attackSquare, horizontal))
                {
                    shipSunk = true;
                    shipHit = false;
                }
                return true;
            }
            else return false;
        }

        private bool left(int x, int y, Square attackSquare)
        {
            horizontal = true;
            int tempX = x--; //Shift square guess over one to the right

            /// <summary>
            /// Check to see if X value is within the gameboard.
            /// </summary>
            if (tempX < 0)
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
                if (checkIfSunk(attackSquare, horizontal))
                {
                    shipSunk = true;
                    shipHit = false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}