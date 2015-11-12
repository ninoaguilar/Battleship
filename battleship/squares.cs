using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship
{
    public enum State { hit, miss, empty };
    public class Square
    {
        private int xLoc;              // Square x location
        private int yLoc;              // Square y location
        private State squareState;     // Square current state

        /// <summary>
        /// Fire at current square object location
        /// </summary>
        public bool fireHere()
        {
            if (isOccuppied())
            {

                this.squareState = State.hit;
                Console.WriteLine("Square is hit"); // Prints out to screen for testing
                return true;
            }

            Console.WriteLine("Square is not hit"); // Prints out to screen for testing
            return false;
        }

        /// <summary>
        /// Check if square object is occupied 
        /// </summary>
        public bool isOccuppied()
        {
            if (this.squareState != State.empty)
            {
                Console.WriteLine("Square is occuppied"); // Prints out to screen for testing
                return true;
            }

            Console.WriteLine("Square is not occuppied"); // Prints out to screen for testing
            return false;
        }

        public Square()
        {
            xLoc = 0;
            yLoc = 0;
            squareState = State.empty;
        }

        public int getXLoc()
        {
            return xLoc;
        }
        public void setXLoc(int loc)
        {
            xLoc = loc;
        }
        public int getYLoc()
        {
            return yLoc;
        }
        public void setYLoc(int loc)
        {
            yLoc = loc;
        }
        public State getSquareState()
        {
            return squareState;
        }
        public void setState(State state)
        {
            squareState = state;
        }
    }

    public class TestSquare {
        static void main()
        {
           
        }
    }

}
