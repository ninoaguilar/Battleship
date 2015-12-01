namespace battleship
{
    public enum ShipName { patrol, submarine, battleship, destroyer, carrier };
    public class Ship
    {
        private Square[] position;
        private int length;
        private bool isSunk;
        private bool placed;
        private ShipName name;

        public Ship(ShipName name)
        {
            int shipLength = 0;
            switch (name)
            {
                case ShipName.patrol:
                    shipLength = 2;
                    break;
                case ShipName.submarine:
                case ShipName.battleship:
                    shipLength = 3;
                    break;
                case ShipName.destroyer:
                    shipLength = 4;
                    break;
                case ShipName.carrier:
                    shipLength = 5;
                    break;
            }
            this.position = new Square[shipLength];
            this.length = shipLength;
            this.isSunk = false;
            this.name = name;
            for(int i = 0; i < length; i++)
            {
                this.position[i] = new Square();
            }
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

        public ShipName Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
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

        public bool Placed
        {
            get
            {
                return placed;
            }

            set
            {
                placed = value;
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