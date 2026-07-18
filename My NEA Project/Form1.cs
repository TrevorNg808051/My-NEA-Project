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
            
            thePlayerPov = new Camara(theWorldMap);
            thePlayer = new Player(0,-10,60,100,10);
            theWorld = new World(thePlayerPov,this);
            theWorldMap = new Map(theWorld,20);
            theWorld.getWorldMap(theWorldMap);

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

            this.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            theWorld.WorldUpdate();
            this.DoubleBuffered = true;

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.D) right = true;
            if (e.KeyCode == Keys.A) left = true;
            if (e.KeyCode == Keys.Space) jump = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            for(int vertical = 0; vertical < theWorldMap.ReturnRenderY(); vertical++)
            {
                for (int horizontal = 0; horizontal < theWorldMap.ReturnRenderX(); horizontal++)
                {
                    Chunk[,] loadedChunks = theWorldMap.ReturnVisableMap();

                    Bitmap currentChunkToLoad = loadedChunks[horizontal, vertical].ReturnChunk();

                    Graphics g = e.Graphics;

                    int worldX = loadedChunks[horizontal,vertical].ReturnChunkX() * loadedChunks[horizontal, vertical].ReturnChunkSize();
                    int worldY = loadedChunks[horizontal,vertical].ReturnChunkY() * loadedChunks[horizontal, vertical].ReturnChunkSize();

                    int screenCentreX = (Screen.PrimaryScreen.Bounds.Width / 2);
                    int screenCentreY = (Screen.PrimaryScreen.Bounds.Height / 2);

                    g.DrawImage(currentChunkToLoad, ((worldX - thePlayer.ReturnXCoord()) * thePlayerPov.ReturnCamScale()) + screenCentreX, ((worldY - thePlayer.ReturnYCoord()) * thePlayerPov.ReturnCamScale()) + screenCentreY, loadedChunks[horizontal,vertical].ReturnChunkSize() * thePlayerPov.ReturnCamScale(), loadedChunks[horizontal, vertical].ReturnChunkSize() * thePlayerPov.ReturnCamScale());

                }
            }
        }
    }
}
