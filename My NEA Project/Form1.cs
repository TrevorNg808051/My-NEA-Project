using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
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
        int chunkSize = 50;

        UIManager uiManager;
        
        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
            
            thePlayerPov = new Camara(theWorldMap);
            
            
            theWorld = new World(thePlayerPov,this);
            thePlayer = new Player(0, -10, 1, 2, 10, theWorld,thePlayerPov);
            theWorldMap = new Map(theWorld,chunkSize);
            theWorld.GetWorldMap(theWorldMap);

            theWorld.AddEntity(thePlayer);
            theWorld.AddEntity(new DebugDummy(0,-20,1,2,10,thePlayerPov));

            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            uiManager = new UIManager(this, thePlayer);
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

        private void Shoot(object sender, MouseEventArgs e)
        {

            Point p = PointToClient(MousePosition);
            label2.Text = $"{p.X},{p.Y}";
            if (thePlayer.GunEqquiped())
            {

                int bulletSpeed = 2;
                double destinationX = thePlayer.ReturnXCoord() + Math.Floor((double)((p.X - (this.Width / 2)) / thePlayerPov.ReturnCamScale()));
                double destinationY = thePlayer.ReturnYCoord() + Math.Floor((double)((p.Y - (this.Height / 2)) / thePlayerPov.ReturnCamScale()));

                theWorld.AddEntity(new Bullet(thePlayer.ReturnXCoord(),thePlayer.ReturnYCoord(),5,5,destinationX,destinationY,bulletSpeed,thePlayerPov));

            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.D) right = true;
            if (e.KeyCode == Keys.A) left = true;
            if (e.KeyCode == Keys.Space) jump = true;

            if (e.KeyCode == Keys.V) uiManager.ToggleCrafting();
            if (e.KeyCode == Keys.I) uiManager.ToggleInventory();
        }

        Point playerLastChunkCoord = new Point { X = 0, Y = 0};
        
        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                for (int vertical = 0; vertical < theWorldMap.ReturnRenderY(); vertical++)
                {
                    for (int horizontal = 0; horizontal < theWorldMap.ReturnRenderX(); horizontal++)
                    {
                        Chunk[,] loadedChunks = theWorldMap.ReturnVisableMap();

                        Bitmap currentChunkToLoad = loadedChunks[horizontal, vertical].ReturnChunk();

                        Graphics g = e.Graphics;

                        int worldX = loadedChunks[horizontal, vertical].ReturnChunkX() * loadedChunks[horizontal, vertical].ReturnChunkSize();
                        int worldY = loadedChunks[horizontal, vertical].ReturnChunkY() * loadedChunks[horizontal, vertical].ReturnChunkSize();

                        int screenCentreX = (Screen.PrimaryScreen.Bounds.Width / 2);
                        int screenCentreY = (Screen.PrimaryScreen.Bounds.Height / 2);

                        int startingX = ((worldX - thePlayer.ReturnXCoord()) * thePlayerPov.ReturnCamScale()) + screenCentreX;
                        int startingY = ((worldY - thePlayer.ReturnYCoord()) * thePlayerPov.ReturnCamScale()) + screenCentreY;

                        int width = loadedChunks[horizontal, vertical].ReturnChunkSize() * thePlayerPov.ReturnCamScale();
                        int height = loadedChunks[horizontal, vertical].ReturnChunkSize() * thePlayerPov.ReturnCamScale();

                        try
                        {
                            g.DrawImage(currentChunkToLoad, startingX, startingY, width, height);
                        }
                        catch (System.ArgumentException)
                        {
                            continue;
                        }
                        catch (System.InvalidOperationException)
                        {
                            continue;
                        }

                    }
                }
            }
            catch (System.ArgumentNullException)
            {
                return;
            }
            catch (System.NullReferenceException)
            {
                return;
            }
            
        }

        public Point ReturnMousePos()
        {
            return MousePosition;
        }
    }
}
