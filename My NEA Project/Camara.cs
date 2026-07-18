using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_NEA_Project
{
    internal class Camara
    {
        private int camWidth;
        private int camHeight;
        private int camScale;
        private int horizontalStartingCoord, verticalStartingCoord;

        Map theWorldMap;

        public Camara(Map theWorldMap)
        {
            this.theWorldMap = theWorldMap;

            this.camWidth = Screen.PrimaryScreen.Bounds.Width;
            this.camHeight = Screen.PrimaryScreen.Bounds.Height;

            camScale = 50;
        }
        public void ZoomOut()
        {

        }

        public int ReturnCamScale()
        {
            return camScale;
        }
        public void SetCamStartingCoords(int startingXCoord, int startingYCoord)
        {
            horizontalStartingCoord = startingXCoord;
            verticalStartingCoord = startingYCoord;
        }
        public int ReturnStaringX()
        {
            return horizontalStartingCoord;
        }
        public int ReturnStartingY()
        {
            return verticalStartingCoord;
        }
    }
}
