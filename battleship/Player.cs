namespace battleship
{

    public class Player
    {
        private string name;
        private Ship[] ships;
        private Gameboard myBoard;
        //Grids (Mine, Opp's)

        public Player()
        {
            this.name = "";
            this.ships = new Ship[5] { new Ship(2), new Ship(3), new Ship(3), new Ship(4), new Ship(5)};
            this.myBoard = new Gameboard();
        }

        public string Name
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

        public bool shoot(Square shotSquare) //Take a square from Form, evaluate if square is legal, create shot object, send/receive over network.
        {
            if(shotSquare.getSquareState().Equals(State.empty))
            {
                Shot newShot = new Shot(shotSquare);
                //sendShot(newShot);
                //receiveShot(incomingPacket);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}