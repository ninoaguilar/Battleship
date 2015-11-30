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
        
        WMPLib.WindowsMediaPlayer musicPlayer = new WMPLib.WindowsMediaPlayer();
        public Form1()
        {
            InitializeComponent();
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
                    playerGridButtons[i][j].Click += new EventHandler(playerGridButton_Click);
                    this.Controls.Add(playerGridButtons[i][j]);
                    this.Controls.Add(enemyGridButtons[i][j]);
                    horizontalLoc += 37;
                }
                horizontalLoc = 49;
                verticalLoc += 35;
            }
        }

        void playerGridButton_Click(Object sender, EventArgs e)
        {
            var clickedSquare = sender as GridButton;
            if(selectedShip != null && placeable)
            {
                if (horizontal)
                {
                    for(int i = 0; i < selectedShip.Length; i++)
                    {
                        selectedShip.Position[i].setXLoc(clickedSquare.XLoc + i);
                        selectedShip.Position[i].setYLoc(clickedSquare.YLoc);
                    }
                }
                else
                {
                    for (int i = 0; i < selectedShip.Length; i++)
                    {
                        selectedShip.Position[i].setXLoc(clickedSquare.XLoc);
                        selectedShip.Position[i].setYLoc(clickedSquare.YLoc + i);
                    }
                }

                switch (selectedShip.Name)
                {
                    case ShipName.patrol:
                        ship2PlacedPictureBox.Visible = true;
                        ship2PlacedPictureBox.Location = new Point(49 + selectedShip.Position[0].getXLoc() * 37, 126 + selectedShip.Position[0].getYLoc() * 35);
                        break;
                    case ShipName.submarine:
                        ship3aPlacedPictureBox.Visible = true;
                        ship3aPlacedPictureBox.Location = new Point(49 + selectedShip.Position[0].getXLoc() * 37, 126 + selectedShip.Position[0].getYLoc() * 35);
                        break;
                    case ShipName.battleship:
                        ship3bPlacedPictureBox.Visible = true;
                        ship3bPlacedPictureBox.Location = new Point(49 +selectedShip.Position[0].getXLoc() * 37, 126 + selectedShip.Position[0].getYLoc() * 35);
                        break;
                    case ShipName.destroyer:
                        ship4PlacedPictureBox.Visible = true;
                        ship4PlacedPictureBox.Location = new Point(49 + selectedShip.Position[0].getXLoc() * 37, 126 + selectedShip.Position[0].getYLoc() * 35);
                        break;
                    case ShipName.carrier:
                        ship5PlacedPictureBox.Visible = true;
                        ship5PlacedPictureBox.Location = new Point(49 +selectedShip.Position[0].getXLoc() * 37, 126 + selectedShip.Position[0].getYLoc() * 35);
                        break;
                }
            }
        }

        public void setGridButtonAttributes(int i, int j, int hLoc, int vLoc, ref GridButton[][] buttonGrid)
        {
            buttonGrid[i][j] = new GridButton();
            buttonGrid[i][j].Size = new Size(37, 35);
            buttonGrid[i][j].Location = new Point(hLoc, vLoc);
            buttonGrid[i][j].FlatStyle = FlatStyle.Flat;
            buttonGrid[i][j].FlatAppearance.BorderColor = Color.Black;
            buttonGrid[i][j].FlatAppearance.BorderSize = 2;
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
