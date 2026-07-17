using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_NEA_Project
{
    public partial class Form1 : Form
    {
        World theWorld;
        Player thePlayer;
        Camara thePlayerPov;
        Map theWorldMap;
        public Form1()
        {
            InitializeComponent();
            theWorldMap = new Map();
            thePlayerPov = new Camara(theWorldMap);
            thePlayer = new Player(0,0,60,100,10);
            theWorld = new World(theWorldMap, thePlayerPov,this);
            theWorld.AddEntity(thePlayer);
            theWorld.AddEntity(new DebugDummy(0,0,60,100,10));

            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            FrameIntervalTracker.Start();
        }
        bool left, right, jump;

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D) right = false;
            if (e.KeyCode == Keys.A) left = false ;
            if (e.KeyCode == Keys.Space) jump = false;
        }

        private void FrameIntervalTracker_Tick(object sender, EventArgs e)
        {
            label1.Text = $"{thePlayer.ReturnXCoord()},{thePlayer.ReturnYCoord()}";
            theWorld.WorldUpdate();
            thePlayer.SetMovement(right, left, jump);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.D) right = true;
            if (e.KeyCode == Keys.A) left = true;
            if (e.KeyCode == Keys.Space) jump = true;
        }
    }
}
