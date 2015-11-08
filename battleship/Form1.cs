using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace battleship
{
    public partial class Form1 : Form
    {
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
        }
    }
}
