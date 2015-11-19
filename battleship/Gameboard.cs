namespace battleship
{
    public  class Gameboard
    {
        public Square[][] playerGrid = new Square[10][];
        public Square[][] enemyGrid = new Square[10][];
        public void resetBoard()
        {
            foreach(Square[] col in playerGrid) {
                foreach (Square s in col)
                {
                    s.setState(0);
                    s.setXLoc(0);
                    s.setYLoc(0);
                }
            }
        }
    }
}