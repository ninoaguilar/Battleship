namespace battleship
{
    public  class Gameboard
    {
        public Square[][] playerGrid = new Square[10][];
        public Square[][] enemyGrid = new Square[10][];
        public Gameboard()
        {
            for (int m = 0; m < 10; m++)
                playerGrid[m] = new Square[10];
            for (int n = 0; n < 10; n++)
                enemyGrid[n] = new Square[10];

            initializeGameboards();
        }

        public void initializeGameboards()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    playerGrid[i][j] = new Square();
                    enemyGrid[i][j] = new Square();
                    playerGrid[i][j].setXLoc(i);
                    playerGrid[i][j].setYLoc(j);
                    enemyGrid[i][j].setXLoc(i);
                    enemyGrid[i][j].setYLoc(j);
                }
            }
        }
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