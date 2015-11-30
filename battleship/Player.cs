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
            this.ships = new Ship[5] { new Ship(ShipName.patrol), new Ship(ShipName.submarine), new Ship(ShipName.battleship), new Ship(ShipName.destroyer), new Ship(ShipName.carrier)};
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

        public Ship[] getShips()
        {
            return ships;
        }

        public Ship getShip(ShipName name)
        {
            Ship requested = ships[0];
            switch (name)
            {
                case ShipName.patrol:
                    requested = ships[0];
                    break;
                case ShipName.submarine:
                    requested = ships[1];
                    break;
                case ShipName.battleship:
                    requested = ships[2];
                    break;
                case ShipName.destroyer:
                    requested = ships[3];
                    break;
                case ShipName.carrier:
                    requested = ships[4];
                    break;
            }
            return requested;
        }

        private void setShip(Ship ship)
        {
            ShipName name = ship.Name;
            switch (name)
            {
                case ShipName.patrol:
                    ships[0] = ship;
                    break;
                case ShipName.submarine:
                    ships[1] = ship;
                    break;
                case ShipName.battleship:
                    ships[2] = ship;
                    break;
                case ShipName.destroyer:
                    ships[3] = ship;
                    break;
                case ShipName.carrier:
                    ships[4] = ship;
                    break;
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