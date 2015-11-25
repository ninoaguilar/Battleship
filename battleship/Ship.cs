namespace battleship
{

    public class Ship
    {
        private Square[] position;
        private int length;
        private bool isSunk;


        public Ship(int shipLength)
        {
            this.position = new Square[shipLength];
            this.length = shipLength;
            this.isSunk = false;
        }

        public Square[] Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

        public int Length
        {
            get
            {
                return length;
            }

            set
            {
                length = value;
            }
        }

        public bool IsSunk
        {
            get
            {
                return isSunk;
            }

            set
            {
                isSunk = value;
            }
        }

        public void takeHit()
        {
            foreach (var square in this.position)   //Check if squares are hit.
            {
                // if(square.State.hit)
                // Getting an error -Nino
                if(square.getSquareState() == State.hit)
                {
                    this.sink();        //Check if ship is sunk.
                }
            }
        }

        public void sink()
        {
            bool sink = true;
            foreach (var square in this.Position)
            {
                   // if (!square.State.hit)
                   // Getting an error - Nino
                   if(square.getSquareState() != State.hit)
                    {
                        sink = false;
                    }
            }
            if(sink)
            {
                this.isSunk = true;
            }
            else
            {
                this.isSunk = false;
            }
            //If each square in position array has value 'hit', change isSunk to true.
        }
    }
}