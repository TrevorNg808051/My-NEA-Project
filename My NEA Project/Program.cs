using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_NEA_Project
{
    public struct Movement
    {
        int horrizontalMovement;
        int verticalMovement;
    }

    public struct Material 
    {
        string name;
        bool solid;
        bool liquid;
        bool gas;
        bool slipery;
        bool decreaseSpeed;

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
