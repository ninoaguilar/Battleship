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
        Button[][] playerGridButtons = new Button[10][];
        Button[][] enemyGridButtons = new Button[10][];
        
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
                playerGridButtons[k] = new Button[10];
            for (int l = 0; l < 10; l++)
                enemyGridButtons[l] = new Button[10];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    setGridButtonAttributes(i, j, horizontalLoc, verticalLoc, ref playerGridButtons);
                    setGridButtonAttributes(i, j, horizontalLoc + 584, verticalLoc, ref enemyGridButtons);
                    this.Controls.Add(playerGridButtons[i][j]);
                    this.Controls.Add(enemyGridButtons[i][j]);
                    horizontalLoc += 37;
                }
                horizontalLoc = 49;
                verticalLoc += 35;
            }
        }

        public void setGridButtonAttributes(int i, int j, int hLoc, int vLoc, ref Button[][] buttonGrid)
        {
            buttonGrid[i][j] = new Button();
            buttonGrid[i][j].Size = new Size(37, 35);
            buttonGrid[i][j].Location = new Point(hLoc, vLoc);
            buttonGrid[i][j].FlatStyle = FlatStyle.Flat;
            buttonGrid[i][j].FlatAppearance.BorderColor = Color.Black;
            buttonGrid[i][j].FlatAppearance.BorderSize = 2;
            buttonGrid[i][j].BackColor = Color.Transparent;
        }       
    }
}
