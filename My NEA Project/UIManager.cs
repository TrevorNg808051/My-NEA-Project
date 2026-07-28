using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_NEA_Project
{
    internal class UIManager
    {
        private Form theFormUiWillBeIn;
        private Player thePlayer;
        public UIManager(Form theFormUiWillBeIn, Player thePlayer)
        {
            this.theFormUiWillBeIn = theFormUiWillBeIn;
            this.thePlayer = thePlayer;
        }

        public void ToggleCrafting()
        {
            throw new NotImplementedException();
        }
        public void ToggleSettings()
        {
            throw new NotImplementedException();
        }
        public void ToggleEquationForming()
        {
            throw new NotImplementedException();
        }
        public void ToggleInventory()
        {
            throw new NotImplementedException();
        }
    }
}
