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
    public partial class EquationFormation : UserControl
    {
        bool dragging = false;
        Button buttonBeingDraged;
        Timer draggingActionTimer;

        TableLayoutPanel[] slots;
        public EquationFormation()
        {
            draggingActionTimer = new Timer();
            draggingActionTimer.Interval = 100;
            draggingActionTimer.Tick += new EventHandler(DraggingTick);

        }

        private void NumberScroll(object sender, ScrollEventArgs e)
        {
            NumberFlowLayout.Left = NumberScrollBar.Value * -1;
        }
        private void OperationScroll(object sender, ScrollEventArgs e)
        {
            OperationFlowLayout.Left = OperationScrollBar.Value * -1;
        }
        public void RefreshEquationFormation(int[] numbersAvaliable, char[] operationsAvaliable, int gunLv)
        {
            slots = new TableLayoutPanel[1 + (2 * gunLv)];

            for (int i = 1; i <= 1 + (gunLv * 2); i++)
            {
                TableLayoutPanel AnotherSlot = new TableLayoutPanel();
                if (i % 2 == 1)
                {
                   
                    AnotherSlot.Size = new Size(70, EquationFormingPanel.Height / 2);
                    AnotherSlot.BackColor = Color.LightBlue;
                    AnotherSlot.Name = "NumberSlot";
                }
                else if (i % 2 == 0)
                {
                    AnotherSlot.Size = new Size(70, EquationFormingPanel.Height / 2);
                    AnotherSlot.BackColor = Color.Orange;
                    AnotherSlot.Name = "OperationSlot";
                }
                slots[i - 1] = AnotherSlot;
                EquationFormingPanel.Controls.Add(AnotherSlot);
            }

            foreach(int i in numbersAvaliable)
            {
                Button numberPiece = new Button();

                numberPiece.Size = new Size(NumberFlowLayout.Height,NumberFlowLayout.Height);
                numberPiece.BackColor = Color.Purple;
                numberPiece.Text = i.ToString();
                numberPiece.MouseDown += new MouseEventHandler(HoldButton);
                numberPiece.MouseUp += new MouseEventHandler(LetGoButton);
                NumberFlowLayout.Controls.Add(numberPiece);

            }

            foreach (char c in operationsAvaliable)
            {
                Button operationPiece = new Button();

                operationPiece.Size = new Size(NumberFlowLayout.Height, NumberFlowLayout.Height);
                operationPiece.BackColor = Color.Purple;
                operationPiece.Text = c.ToString();
                operationPiece.MouseDown += new MouseEventHandler(HoldButton);
                operationPiece.MouseUp += new MouseEventHandler(LetGoButton);
                OperationFlowLayout.Controls.Add(operationPiece);
            }
        }
        public void ClearEquationFormation()
        {
            EquationFormingPanel.Controls.Clear();
            NumberFlowLayout.Controls.Clear();
            OperationFlowLayout.Controls.Clear();
        }

        bool fromEquation = false;
        private void HoldButton(object sender, MouseEventArgs e)
        {
            buttonBeingDraged = (Button)sender;
            dragging = true;
            Control form = this;
            if(!(buttonBeingDraged.Parent is FlowLayoutPanel))
            {
                fromEquation = true;
            }
            else
            {
                fromEquation = false;
            }
            buttonBeingDraged.Parent.Controls.Remove(buttonBeingDraged);
            if (!form.Controls.Contains(buttonBeingDraged))
            {
                form.Controls.Add(buttonBeingDraged);
            }
            buttonBeingDraged.Location = this.PointToClient(new Point(MousePosition.X - 10, MousePosition.Y - 10));
            buttonBeingDraged.BringToFront();
            draggingActionTimer.Start();
        }
        private void LetGoButton(object sender, MouseEventArgs e)
        {
            bool buttonCantFindAPlace = true;
            draggingActionTimer.Stop();
            foreach(TableLayoutPanel tlp in slots)
            {
                if (buttonBeingDraged.Bounds.IntersectsWith(tlp.Bounds))
                {
                    try
                    {
                        int.Parse(buttonBeingDraged.Text);
                        if (tlp.Name.Contains("NumberSlot"))
                        {
                            tlp.Controls.Add(buttonBeingDraged);
                            buttonCantFindAPlace = false;
                        }
                    }
                    catch (FormatException)
                    {
                        if (tlp.Name.Contains("OperationSlot"))
                        {
                            tlp.Controls.Add(buttonBeingDraged);
                            buttonCantFindAPlace = false;
                        }
                    }
                    break;
                }
                else
                {
                    buttonCantFindAPlace = true;
                }
                
            }

            if (buttonCantFindAPlace)
            {
                if (fromEquation)
                {
                    try
                    {
                        int.Parse(buttonBeingDraged.Text);
                        NumberFlowLayout.Controls.Add(buttonBeingDraged);

                    }
                    catch (FormatException)
                    {
                        OperationFlowLayout.Controls.Add(buttonBeingDraged);
                    }
                }
                else
                {
                    bool thereIsSpaceAvaliableForButton = false;
                    foreach (TableLayoutPanel tlp in slots)
                    {
                        try
                        {
                            int.Parse(buttonBeingDraged.Text);
                            if (tlp.Controls.Count <= 0 && tlp.Name.Contains("NumberSlot"))
                            {
                                thereIsSpaceAvaliableForButton = true;
                                tlp.Controls.Add(buttonBeingDraged);
                                break;
                            }
                        }
                        catch (FormatException)
                        {
                            if (tlp.Controls.Count <= 0 && tlp.Name.Contains("OperationSlot"))
                            {
                                thereIsSpaceAvaliableForButton = true;
                                tlp.Controls.Add(buttonBeingDraged);
                                break;
                            }
                        }
                    }
                    if (!thereIsSpaceAvaliableForButton)
                    {
                        this.Controls.Remove(buttonBeingDraged);
                        try
                        {
                            int.Parse(buttonBeingDraged.Text);
                            NumberFlowLayout.Controls.Add(buttonBeingDraged);
                        }
                        catch (FormatException)
                        {
                            OperationFlowLayout.Controls.Add(buttonBeingDraged);
                        }
                    }
                }
              
                
            }
            buttonBeingDraged = null;
            dragging = false;
        }

        public void DraggingTick(object sender, EventArgs e)
        {
            
            buttonBeingDraged.Location = this.PointToClient(new Point(MousePosition.X-10,MousePosition.Y-10));
        }
        public List<string> ReturnEquation()
        {
            
            List<string> equation = new List<string>();
            try
            {
                foreach (TableLayoutPanel tlp in slots)
                {
                    if (tlp.Controls.Count <= 0)
                    {
                        return equation;
                    }
                    Button btn = (Button)tlp.Controls[0];
                    equation.Add(btn.Text);
                   
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }
            catch (NullReferenceException)
            {
                return null;
            }
            return equation;
        }
    }
}
