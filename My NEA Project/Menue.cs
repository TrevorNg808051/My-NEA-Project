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
    public partial class Menue : Form
    {
        private Button startBtn, settingBtn, quitBtn;


        private Label title;
        public Menue()
        {
            InitializeComponent();
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;

            startBtn = new Button();
            startBtn.Text = "Start";
            settingBtn = new Button();
            settingBtn.Text = "Settings";
            quitBtn = new Button();
            quitBtn.Text = "Quit";

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
                btn.Size = new Size(500,150);
                btn.Location = new Point((this.Width/2) - (btn.Width/ 2) , 250 + yCoord);
                yCoord += 200;
                this.Controls.Add(btn);
                btn.BackColor = Color.Gray;
            }
        }
    }
}
