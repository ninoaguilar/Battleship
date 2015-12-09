using System;
using System.Timers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace battleship
{
    public partial class Form1 : Form
    {
        Gameboard Board;
        GridButton[][] playerGridButtons = new GridButton[10][];
        GridButton[][] enemyGridButtons = new GridButton[10][];
        GameController controller = new GameController();

        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));

        WMPLib.WindowsMediaPlayer musicPlayer = new WMPLib.WindowsMediaPlayer();
        public Form1()
        {
            InitializeComponent();
            initializeManualComponents();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            musicPlayer.URL = (@"StartMusic.mp3");
            musicPlayer.settings.volume = 15;
            musicPlayer.controls.play();
        }

        private void beginButton_Click(object sender, EventArgs e)
        {
            startScreen.Enabled = false;
            startScreen.Visible = false;
            beginButton.Enabled = false;
            beginButton.Visible = false;
            musicPlayer.controls.stop();
            formBoards();
        }

        public void formBoards()
        {
            int horizontalLoc = 49;
            int verticalLoc = 126;

            for (int k = 0; k < 10; k++)
                playerGridButtons[k] = new GridButton[10];
            for (int l = 0; l < 10; l++)
                enemyGridButtons[l] = new GridButton[10];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    setGridButtonAttributes(i, j, horizontalLoc, verticalLoc, ref playerGridButtons);
                    setGridButtonAttributes(i, j, horizontalLoc + 584, verticalLoc, ref enemyGridButtons);
                    playerGridButtons[i][j].MouseUp += new MouseEventHandler(playerGridButton_Click);
                    playerGridButtons[i][j].MouseEnter += new EventHandler(playerGridButton_MouseEnter);
                    playerGridButtons[i][j].MouseLeave += new EventHandler(playerGridButton_MouseLeave);
                    this.Controls.Add(playerGridButtons[i][j]);
                    this.Controls.Add(enemyGridButtons[i][j]);
                    horizontalLoc += 37;
                }
                horizontalLoc = 49;
                verticalLoc += 35;
            }
        }

        void playerGridButton_MouseEnter(Object sender, EventArgs e)
        {
            var enteredSquare = sender as GridButton;
            if (selectedShip != null)
            {
                if (((horizontal && enteredSquare.XLoc + selectedShip.Length <= 10) || (!horizontal && enteredSquare.YLoc + selectedShip.Length <= 10)) && shipFits(enteredSquare.XLoc, enteredSquare.YLoc))
                {
                    for (int i = 0; i < selectedShip.Length; i++)
                    {
                        if (horizontal)
                        {
                            playerGridButtons[enteredSquare.YLoc][enteredSquare.XLoc + i].BackColor = Color.White;
                        }
                        else
                        {
                            playerGridButtons[enteredSquare.YLoc + i][enteredSquare.XLoc].BackColor = Color.White;
                        }
                    }
                    placeable = true;
                }
                else
                {
                    enteredSquare.BackColor = Color.Red;
                    placeable = false;
                }
            }
        }

        bool shipFits(int initXLoc, int initYLoc)
        {
            bool fits = true;

            foreach (Ship ship in controller.getPlayer().getShips())
            {
                for (int i = 0; i < ship.Length; i++)
                {
                    for (int j = 0; j < selectedShip.Length; j++)
                    {
                        if (horizontal)
                        {
                            if (ship.Position[i].getXLoc() == initXLoc + j && ship.Position[i].getYLoc() == initYLoc)
                            {
                                fits = false;
                            }
                        }
                        else
                        {
                            if (ship.Position[i].getXLoc() == initXLoc && ship.Position[i].getYLoc() == initYLoc + j)
                            {
                                fits = false;
                            }
                        }
                    }
                }
            }
            return fits;
        }

        void playerGridButton_MouseLeave(Object sender, EventArgs e)
        {
            var exitedSquare = sender as GridButton;
            if (selectedShip != null)
            {
                if ((horizontal && exitedSquare.XLoc + selectedShip.Length <= 10) || (!horizontal && exitedSquare.YLoc + selectedShip.Length <= 10))
                {
                    for (int i = 0; i < selectedShip.Length; i++)
                    {
                        if (horizontal)
                        {
                            playerGridButtons[exitedSquare.YLoc][exitedSquare.XLoc + i].BackColor = Color.Transparent;
                        }
                        else
                        {
                            playerGridButtons[exitedSquare.YLoc + i][exitedSquare.XLoc].BackColor = Color.Transparent;
                        }
                    }
                    placeable = true;
                }
                else
                {
                    placeable = false;
                    exitedSquare.BackColor = Color.Transparent;
                }
            }
        }

        void playerGridButton_Click(Object sender, MouseEventArgs e)
        {
            var clickedSquare = sender as GridButton;
            switch (e.Button)
            {
                case MouseButtons.Right:
                    for (int i = 0; i < selectedShip.Length; i++)
                    {
                        if (horizontal)
                        {
                            if (clickedSquare.XLoc + i < 10)
                            {
                                playerGridButtons[clickedSquare.YLoc][clickedSquare.XLoc + i].BackColor = Color.Transparent;
                            }
                        }
                        else
                        {
                            if (clickedSquare.YLoc + i < 10)
                            {
                                playerGridButtons[clickedSquare.YLoc + i][clickedSquare.XLoc].BackColor = Color.Transparent;
                            }
                        }
                    }
                    horizontal = !horizontal;
                    for (int i = 0; i < selectedShip.Length; i++)
                    {
                        if (horizontal)
                        {
                            if (clickedSquare.XLoc + i < 10)
                            {
                                playerGridButtons[clickedSquare.YLoc][clickedSquare.XLoc + i].BackColor = Color.White;
                                placeable = true;
                            }
                            else
                            {
                                playerGridButtons[clickedSquare.YLoc][clickedSquare.XLoc].BackColor = Color.Red;
                                placeable = false;
                            }
                        }
                        else
                        {
                            if (clickedSquare.YLoc + i < 10)
                            {
                                playerGridButtons[clickedSquare.YLoc + i][clickedSquare.XLoc].BackColor = Color.White;
                                placeable = true;
                            }
                            else
                            {
                                playerGridButtons[clickedSquare.YLoc][clickedSquare.XLoc].BackColor = Color.Red;
                                placeable = false;
                            }
                        }
                    }
                    break;
                case MouseButtons.Left:

                    if (selectedShip != null && placeable)
                    {
                        if (horizontal)
                        {
                            for (int i = 0; i < selectedShip.Length; i++)
                            {
                                selectedShip.Position[i].setXLoc(clickedSquare.XLoc + i);
                                selectedShip.Position[i].setYLoc(clickedSquare.YLoc);
                                selectedShip.Placed = true;
                            }
                        }
                        else
                        {
                            for (int i = 0; i < selectedShip.Length; i++)
                            {
                                selectedShip.Position[i].setXLoc(clickedSquare.XLoc);
                                selectedShip.Position[i].setYLoc(clickedSquare.YLoc + i);
                                selectedShip.Placed = true;
                            }
                        }

                        switch (selectedShip.Name)
                        {
                            case ShipName.patrol:
                                ship2PlacedPictureBox.Visible = true;
                                ship2PlacedPictureBox.Location = new Point(49 + selectedShip.Position[0].getXLoc() * 37, 126 + selectedShip.Position[0].getYLoc() * 35);
                                if (horizontal)
                                {
                                    ship2PlacedPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ship2PictureBox.BackgroundImage")));
                                    ship2PlacedPictureBox.Size = new System.Drawing.Size(74, 35);
                                }
                                else
                                {
                                    ship2PlacedPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ship1-vert")));
                                    ship2PlacedPictureBox.Size = new System.Drawing.Size(36, 70);
                                }
                                break;
                            case ShipName.submarine:
                                ship3aPlacedPictureBox.Visible = true;
                                ship3aPlacedPictureBox.Location = new Point(49 + selectedShip.Position[0].getXLoc() * 37, 126 + selectedShip.Position[0].getYLoc() * 35);
                                if (horizontal)
                                {
                                    ship3aPlacedPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ship3aPictureBox.BackgroundImage")));
                                    ship3aPlacedPictureBox.Size = new System.Drawing.Size(111, 35);
                                }
                                else
                                {
                                    ship3aPlacedPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ship2-vert")));
                                    ship3aPlacedPictureBox.Size = new System.Drawing.Size(36, 104);
                                }
                                break;
                            case ShipName.battleship:
                                ship3bPlacedPictureBox.Visible = true;
                                ship3bPlacedPictureBox.Location = new Point(49 + selectedShip.Position[0].getXLoc() * 37, 126 + selectedShip.Position[0].getYLoc() * 35);
                                if (horizontal)
                                {
                                    ship3bPlacedPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ship3bPictureBox.BackgroundImage")));
                                    ship3bPlacedPictureBox.Size = new System.Drawing.Size(111, 35);
                                }
                                else
                                {
                                    ship3bPlacedPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ship3-vert")));
                                    ship3bPlacedPictureBox.Size = new System.Drawing.Size(36, 104);
                                }
                                break;
                            case ShipName.destroyer:
                                ship4PlacedPictureBox.Visible = true;
                                ship4PlacedPictureBox.Location = new Point(49 + selectedShip.Position[0].getXLoc() * 37, 126 + selectedShip.Position[0].getYLoc() * 35);
                                if (horizontal)
                                {
                                    ship4PlacedPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ship4PictureBox.BackgroundImage")));
                                    ship4PlacedPictureBox.Size = new System.Drawing.Size(147, 35);
                                }
                                else
                                {
                                    ship4PlacedPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ship4-vert")));
                                    ship4PlacedPictureBox.Size = new System.Drawing.Size(36, 140);
                                }
                                break;
                            case ShipName.carrier:
                                ship5PlacedPictureBox.Visible = true;
                                ship5PlacedPictureBox.Location = new Point(49 + selectedShip.Position[0].getXLoc() * 37, 126 + selectedShip.Position[0].getYLoc() * 35);
                                if (horizontal)
                                {
                                    ship5PlacedPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ship5PictureBox.BackgroundImage")));
                                    ship5PlacedPictureBox.Size = new System.Drawing.Size(185, 35);
                                }
                                else
                                {
                                    ship5PlacedPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ship5-vert")));
                                    ship5PlacedPictureBox.Size = new System.Drawing.Size(36, 174);
                                }
                                break;
                        }
                        checkCanStart();
                    }
                    break;
            }
        }

        public void checkCanStart()
        {
            var allPlaced = true;
            foreach(Ship ship in controller.getPlayer().getShips())
            {
                if (!ship.Placed)
                {
                    allPlaced = false;
                }
            }

            if (allPlaced)
            {
                startButton.Enabled = true;
            }
            else
            {
                startButton.Enabled = false;
            }
        }

        public void setGridButtonAttributes(int i, int j, int hLoc, int vLoc, ref GridButton[][] buttonGrid)
        {
            buttonGrid[i][j] = new GridButton();
            buttonGrid[i][j].Size = new Size(37, 35);
            buttonGrid[i][j].Location = new Point(hLoc, vLoc);
            buttonGrid[i][j].FlatStyle = FlatStyle.Flat;
            buttonGrid[i][j].FlatAppearance.BorderColor = Color.FromArgb(0, 24, 80);
            buttonGrid[i][j].FlatAppearance.BorderSize = 1;
            buttonGrid[i][j].BackColor = Color.Transparent;
            playerGridButtons[i][j].XLoc = j;
            playerGridButtons[i][j].YLoc = i;
        }

        public void shipSelect(PictureBox sender)
        {
            foreach (PictureBox shipPictureBox in shipPictureBoxes)
            {
                shipPictureBox.BackColor = Color.Transparent;
            }
            sender.BackColor = Color.White;
            activeShipPictureBox = sender;
            if (sender.Equals(ship2PictureBox))
            {
                selectedShip = controller.getPlayer().getShip(ShipName.patrol);
            }
            else if (sender.Equals(ship3aPictureBox))
            {
                selectedShip = controller.getPlayer().getShip(ShipName.submarine);
            }
            else if (sender.Equals(ship3bPictureBox))
            {
                selectedShip = controller.getPlayer().getShip(ShipName.battleship);
            }
            else if (sender.Equals(ship4PictureBox))
            {
                selectedShip = controller.getPlayer().getShip(ShipName.destroyer);
            }
            else if (sender.Equals(ship5PictureBox))
            {
                selectedShip = controller.getPlayer().getShip(ShipName.carrier);
            }
        }

        public void initializeManualComponents()
        {
            this.ship2PictureBox.MouseClick += new MouseEventHandler((o, a) => shipSelect(this.ship2PictureBox));
            this.ship3aPictureBox.MouseClick += new MouseEventHandler((o, a) => shipSelect(this.ship3aPictureBox));
            this.ship3bPictureBox.MouseClick += new MouseEventHandler((o, a) => shipSelect(this.ship3bPictureBox));
            this.ship4PictureBox.MouseClick += new MouseEventHandler((o, a) => shipSelect(this.ship4PictureBox));
            this.ship5PictureBox.MouseClick += new MouseEventHandler((o, a) => shipSelect(this.ship5PictureBox));
            this.shipPictureBoxes = new List<PictureBox>();
            this.shipPictureBoxes.Add(this.ship2PictureBox);
            this.shipPictureBoxes.Add(this.ship3aPictureBox);
            this.shipPictureBoxes.Add(this.ship3bPictureBox);
            this.shipPictureBoxes.Add(this.ship4PictureBox);
            this.shipPictureBoxes.Add(this.ship5PictureBox);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            //Put code to start the game here
        }
    }

    public partial class GridButton : System.Windows.Forms.Button
    {
        private int xLoc, yLoc;

        public int XLoc
        {
            get
            {
                return xLoc;
            }

            set
            {
                xLoc = value;
            }
        }

        public int YLoc
        {
            get
            {
                return yLoc;
            }

            set
            {
                yLoc = value;
            }
        }
    }
}
