using My_NEA_Project.Entities;
using My_NEA_Project.Entities.Creatures;
using My_NEA_Project.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_NEA_Project
{

    public partial class GamePlay : Form
    {
        World theWorld;
        Player thePlayer;
        Camara thePlayerPov;
        Map theWorldMap;
        int chunkSize = 50;

        UIManager uiManager;

        string saveFile = "";

        int difficulty = 0;

        int fileNum = 0;
        public GamePlay(string difficulty,int fileNum)
        {
            this.fileNum = fileNum;
            InitializeComponent();
            KeyPreview = true;

            switch (difficulty)
            {
                case "Easy":
                    this.difficulty = 1;
                    break;
                case "Normal":
                    this.difficulty = 2;
                    break;
                case "Hard":
                    this.difficulty = 3;
                    break;
            }

            thePlayerPov = new Camara(theWorldMap);
            
            
            theWorld = new World(thePlayerPov,this);
            thePlayer = new Player(0, -10, 1, 2, 10, theWorld,thePlayerPov);
            theWorldMap = new Map(theWorld,chunkSize);
            theWorld.GetWorldMap(theWorldMap);

            theWorld.AddEntity(thePlayer);

            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            uiManager = new UIManager(this, thePlayer);
            FrameIntervalTracker.Start();
            AutoSaveTimer.Start();
        }
        public GamePlay(string filePath)
        {
            thePlayerPov = new Camara(theWorldMap);



            int playerX = 0;
            int playerY = 0;
            int worldSeed = 0;
            List<Structure> listOfStructure = new List<Structure>();
            List<itemStack> listOfStackItems = new List<itemStack>();
            saveFile = filePath;
            using (StreamReader reader = new StreamReader(filePath))
            {
                // 1. Difficulty
                // 2. PlayerX
                // 3. PlayerY
                // 4. Seed
                // 5. FileNum
                // 6. Every structure's coords
                // 7. Inventory content


                this.difficulty = int.Parse(reader.ReadLine());
                playerX = int.Parse(reader.ReadLine());
                playerY = int.Parse(reader.ReadLine());
                worldSeed = int.Parse(reader.ReadLine());
                fileNum = int.Parse(reader.ReadLine());
                while (!reader.EndOfStream)
                {
                    itemStack iS;
                    switch (reader.ReadLine())
                    {
                        case "UpgradeStationBuilding":
                            listOfStructure.Add(new UpgradeStationBuilding(int.Parse(reader.ReadLine()),int.Parse(reader.ReadLine()), new PictureBox(), thePlayerPov, theWorld));
                            break;
                        case "Stone":
                            iS = new itemStack() { item = new Stone(thePlayer), stackCount = int.Parse(reader.ReadLine()) };

                            listOfStackItems.Add(iS);
                            break;
                        case "Wood":
                            iS = new itemStack() { item = new Wood(thePlayer), stackCount = int.Parse(reader.ReadLine()) };

                            listOfStackItems.Add(iS);
                            break;
                        case "UpgradeStation":
                            iS = new itemStack() { item = new UpgradeStation(thePlayer), stackCount = int.Parse(reader.ReadLine()) };

                            listOfStackItems.Add(iS);
                            break;
                        case "RandomOperation":
                            iS = new itemStack() { item = new Operator(thePlayer), stackCount = int.Parse(reader.ReadLine()) };

                            listOfStackItems.Add(iS);
                            break;
                        case "RandomNumber":
                            iS = new itemStack() { item = new Numbers(thePlayer), stackCount = int.Parse(reader.ReadLine()) };

                            listOfStackItems.Add(iS);
                            break;

                    }
                    
                }

            }

            theWorld = new World(thePlayerPov, this,worldSeed);
            thePlayer = new Player(playerX, playerY, 1, 2, 10, theWorld, thePlayerPov);
            theWorldMap = new Map(theWorld, chunkSize);
            theWorld.GetWorldMap(theWorldMap);

            theWorld.AddEntity(thePlayer);
            foreach(Structure s in listOfStructure)
            {
                theWorld.AddEntity(s);
            }
            foreach(itemStack iS in listOfStackItems)
            {
                thePlayer.ReciveItem(iS.item,iS.stackCount);
            }
            InitializeComponent();
            KeyPreview = true;
           

            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            uiManager = new UIManager(this, thePlayer);
            

           
            FrameIntervalTracker.Start();
            AutoSaveTimer.Start();
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
            uiManager.ShowHealth();
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
            if (thePlayer.GunEqquiped() && GetEquation() != null)
            {

                int bulletSpeed = 2;
                double destinationX = thePlayer.ReturnXCoord() + Math.Floor((double)((p.X - (this.Width / 2)) / thePlayerPov.ReturnCamScale()));
                double destinationY = thePlayer.ReturnYCoord() + Math.Floor((double)((p.Y - (this.Height / 2)) / thePlayerPov.ReturnCamScale()));

                theWorld.AddEntity(new Bullet(thePlayer.ReturnXCoord(),thePlayer.ReturnYCoord(),1,1,destinationX,destinationY,bulletSpeed,thePlayerPov,theWorld));

            }
            if (GetEquation() == null)
            {
                MessageBox.Show("gun is not loaded");
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.D) right = true;
            if (e.KeyCode == Keys.A) left = true;
            if (e.KeyCode == Keys.Space) jump = true;

            if (e.KeyCode == Keys.V) uiManager.ToggleCrafting();
            if (e.KeyCode == Keys.I) uiManager.ToggleInventory();
            if (e.KeyCode == Keys.R) uiManager.ToggleEquationForming();

            if(e.KeyCode == Keys.E)
            {
                thePlayer.Interact();
            }
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

        private void AutoSaveTimer_Tick(object sender, EventArgs e)
        {
            SaveGame(fileNum);
        }

        private void SaveGame(int fileNum)
        {
            
            string filePath = "SaveFile_" + fileNum + ".txt";
            bool gameSaved = false;

            while (!gameSaved)
            {
                if (File.Exists(filePath))
                {
                    gameSaved = true;
                    string gameData = theWorld.ReturnGameData();
                    using (StreamWriter sw = new StreamWriter(filePath))
                    {
                        sw.Write(gameData);

                    }
                }
                else if(File.Exists(filePath))
                {
                    fileNum++;
                    filePath = "SaveFile_" + fileNum + ".txt";
                }
                else
                {
                    using (StreamWriter sw = new StreamWriter(filePath))
                    {
                        sw.Write("");
                       
                    }
                }
            }
        }

        public List<string> GetEquation()
        {
            List<string> equation = uiManager.ReturnEquation();
            if(equation == null)
            {
                return null;
            }
            return equation;
        }

       
        public int ReturnDifficulty()
        {
            return difficulty;
        }
        public int ReturnFileNum()
        {
            return fileNum;
        }
    }
}
