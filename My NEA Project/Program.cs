using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_NEA_Project
{
    public struct itemStack
    {
        public int stackCount;
        public Item item;
    }
    public struct Movement
    {
        public double horrizontalMovement;
        public double verticalMovement;
    }

    public struct Material 
    {
        public string name;
        public bool solid;
        public bool liquid;
        public bool gas;
        public bool slipery;
        public bool decreaseSpeed;

    }

    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
