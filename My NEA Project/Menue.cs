using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_NEA_Project
{
    public partial class Menue : Form
    {

        private Button lastScreenBtn = new Button();

        private Label title;
        public Menue()
        {
            InitializeComponent();
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;

            StartingScreen(null,new EventArgs());

            lastScreenBtn.Size = new Size(50, 50);
            lastScreenBtn.Location = new Point(50, 50);
            lastScreenBtn.BackColor = Color.Red;
            lastScreenBtn.Click += new EventHandler(LastScreen);

        }
        private void StartingScreen(object sender, EventArgs e)
        {
            Button startBtn, settingBtn, quitBtn;
            startBtn = new Button();
            startBtn.Text = "Start";
            startBtn.Click += new EventHandler(WorldBuilding);

            settingBtn = new Button();
            settingBtn.Text = "Settings";
            settingBtn.Click += new EventHandler(Settings);

            quitBtn = new Button();
            quitBtn.Text = "Quit";
            quitBtn.Click += new EventHandler(QuitApplication);

            title = new Label();
            title.AutoSize = false;
            title.Size = new Size(800, 200);
            title.Font = new Font("Microsoft Uighur", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title.TextAlign = ContentAlignment.MiddleCenter;
            title.Text = "The Educational Math Game!";
            title.Location = new Point((this.Width / 2) - (title.Width / 2), 50);
            this.Controls.Add(title);


            int yCoord = 0;
            foreach (Button btn in new Button[] { startBtn, settingBtn, quitBtn })
            {
                btn.Size = new Size(500, 150);
                btn.Location = new Point((this.Width / 2) - (btn.Width / 2), 250 + yCoord);
                yCoord += 200;
                this.Controls.Add(btn);
                btn.BackColor = Color.Gray;
            }
        }

        private string lastScreen = "";
        private void WorldBuilding(object sender, EventArgs e)
        {
            this.Controls.Clear();
            Button loadSaveBtn = new Button();
            Button newWorldBtn = new Button();

            
            
            loadSaveBtn = new Button();
            loadSaveBtn.Text = "Load Save";
            loadSaveBtn.Click += new EventHandler(LoadSave);

            newWorldBtn = new Button();
            newWorldBtn.Text = "Creat New World";
            newWorldBtn.Click += new EventHandler(ChooseDifficulty);

            int yCoord = 0;
            foreach (Button btn in new Button[] { loadSaveBtn,newWorldBtn })
            {
                btn.Size = new Size(500, 150);
                btn.Location = new Point((this.Width / 2) - (btn.Width / 2), 250 + yCoord);
                yCoord += 200;
                this.Controls.Add(btn);
                btn.BackColor = Color.Gray;
            }
            lastScreen = "startingScreen";



            this.Controls.Add(lastScreenBtn);
        }
        private void Settings(object sender, EventArgs e)
        {

        }
        private void QuitApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ChooseDifficulty(object sender, EventArgs e)
        {
            this.Controls.Clear();
            Button hardDif = new Button();
            hardDif.Text = "Hard";
            Button normalDif = new Button();
            normalDif.Text = "Normal";
            Button easyDif = new Button();
            easyDif.Text = "Easy";

            int yCoord = 0;
            foreach (Button btn in new Button[] { hardDif, normalDif, easyDif })
            {
                btn.Click += new EventHandler(SettingDifficulty);
                btn.Size = new Size(500, 150);
                btn.Location = new Point((this.Width / 2) - (btn.Width / 2), 250 + yCoord);
                yCoord += 200;
                this.Controls.Add(btn);
                btn.BackColor = Color.Gray;
            }
            lastScreen = "worldBuildingScreen";


            title = new Label();
            title.AutoSize = false;
            title.Size = new Size(800, 200);
            title.Font = new Font("Microsoft Uighur", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title.TextAlign = ContentAlignment.MiddleCenter;
            title.Text = "Choose Your Difficulty";
            title.Location = new Point((this.Width / 2) - (title.Width / 2), 50);
            this.Controls.Add(title);

            this.Controls.Add(lastScreenBtn);
        }

        string difficultyChosen = "";
        private void SettingDifficulty(object sender, EventArgs e)
        {
            Button difficultySet = (Button)sender;
            difficultyChosen = difficultySet.Text;
            MakeWorld();
        }
        private void MakeWorld()
        {
            this.Hide();
            using (GamePlay gamePlay = new GamePlay())
            {
                gamePlay.SetDifficulty(difficultyChosen);
                gamePlay.ShowDialog();
            }
            this.Close();
        }

        private void LoadSave (object sender, EventArgs e)
        {

        }
        public void LastScreen(object sender, EventArgs e)
        {
            this.Controls.Clear();
            switch (lastScreen)
            {
                case "startingScreen":
                    StartingScreen(null, new EventArgs());
                    break;
                case "worldBuildingScreen":
                    WorldBuilding(null, new EventArgs());
                    break;

            }
        }
    }
}
