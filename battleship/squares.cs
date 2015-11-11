using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship
{
    public enum State { hit, miss, empty };
    public class Squares
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

        public Squares()
        {
            int xLoc = 0;
            int yLoc = 0;
            squareState = State.empty;
        }
    }

    public class TestSquare {
        static void main()
        {
           
        }
    }

}
