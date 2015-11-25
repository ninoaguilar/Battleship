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

        public Square()
        {
            xLoc = 0;
            yLoc = 0;
            squareState = State.empty;
        }

        public Square(int x, int y)
        {
            xLoc = x;
            yLoc = y;
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

        /// <summary>
        /// Fire at current square object location
        /// </summary>
        public bool fireHere()
        {
            //Sets square state to hit
            this.setState(State.hit);

            if (this.isOccuppied())
            {
                return true;              //hit
            }
           
            return false;                 //miss
        }

        /// <summary>
        /// Checks if square object is occupied 
        /// </summary>
        public bool isOccuppied()
        {
            if (this.getSquareState() != State.empty)
            {
                return true;          //Occupied
            }
            
            return false;             //Not Occupied
        }
    }
}
