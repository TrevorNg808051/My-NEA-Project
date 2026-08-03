namespace My_NEA_Project
{
    partial class EquationFormation
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent()
        {
            this.EquationFormingPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.NumberFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.NumberScrollBar = new System.Windows.Forms.HScrollBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.OperationFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.OperationScrollBar = new System.Windows.Forms.HScrollBar();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // EquationFormingPanel
            // 
            this.EquationFormingPanel.BackColor = System.Drawing.Color.Navy;
            this.EquationFormingPanel.Location = new System.Drawing.Point(4, 3);
            this.EquationFormingPanel.Name = "EquationFormingPanel";
            this.EquationFormingPanel.Size = new System.Drawing.Size(this.Width, 231);
            this.EquationFormingPanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.NumberFlowLayout);
            this.panel1.Controls.Add(this.NumberScrollBar);
            this.panel1.Location = new System.Drawing.Point(4, 238);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(this.Width, 85);
            this.panel1.TabIndex = 1;
            // 
            // NumberFlowLayout
            // 
            this.NumberFlowLayout.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.NumberFlowLayout.Location = new System.Drawing.Point(3, 3);
            this.NumberFlowLayout.Name = "NumberFlowLayout";
            this.NumberFlowLayout.Size = new System.Drawing.Size(this.Width * 2, 62);
            this.NumberFlowLayout.TabIndex = 1;
            // 
            // NumberScrollBar
            // 
            this.NumberScrollBar.Location = new System.Drawing.Point(0, 64);
            this.NumberScrollBar.Maximum = 1000;
            this.NumberScrollBar.Name = "NumberScrollBar";
            this.NumberScrollBar.Size = new System.Drawing.Size(this.Width, 20);
            this.NumberScrollBar.TabIndex = 0;
            this.NumberScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.NumberScroll);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.OperationFlowLayout);
            this.panel2.Controls.Add(this.OperationScrollBar);
            this.panel2.Location = new System.Drawing.Point(4, 329);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(this.Width, 85);
            this.panel2.TabIndex = 2;
            // 
            // OperationFlowLayout
            // 
            this.OperationFlowLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.OperationFlowLayout.Location = new System.Drawing.Point(3, 3);
            this.OperationFlowLayout.Name = "OperationFlowLayout";
            this.OperationFlowLayout.Size = new System.Drawing.Size(this.Width * 2, 62);
            this.OperationFlowLayout.TabIndex = 2;
            // 
            // OperationScrollBar
            // 
            this.OperationScrollBar.Location = new System.Drawing.Point(0, 64);
            this.OperationScrollBar.Maximum = 1000;
            this.OperationScrollBar.Name = "OperationScrollBar";
            this.OperationScrollBar.Size = new System.Drawing.Size(this.Width, 20);
            this.OperationScrollBar.TabIndex = 1;
            this.OperationScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.OperationScroll);
            // 
            // EquationFormation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.EquationFormingPanel);
            this.Name = "EquationFormation";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel EquationFormingPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel NumberFlowLayout;
        private System.Windows.Forms.HScrollBar NumberScrollBar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.HScrollBar OperationScrollBar;
        private System.Windows.Forms.FlowLayoutPanel OperationFlowLayout;
    }
}
