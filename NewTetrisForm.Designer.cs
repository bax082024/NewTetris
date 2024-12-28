namespace NewTetris
{
    partial class NewTetrisForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            panel2 = new Panel();
            lblTitel = new Label();
            labelScore = new Label();
            buttonStart = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(buttonStart);
            panel1.Controls.Add(labelScore);
            panel1.Controls.Add(lblTitel);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(710, 748);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.BackColor = Color.Gainsboro;
            panel2.Location = new Point(122, 105);
            panel2.Name = "panel2";
            panel2.Size = new Size(458, 535);
            panel2.TabIndex = 0;
            // 
            // lblTitel
            // 
            lblTitel.Anchor = AnchorStyles.None;
            lblTitel.AutoSize = true;
            lblTitel.Font = new Font("Snap ITC", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitel.Location = new Point(250, 9);
            lblTitel.Name = "lblTitel";
            lblTitel.Size = new Size(193, 48);
            lblTitel.TabIndex = 1;
            lblTitel.Text = "TETRIS";
            // 
            // labelScore
            // 
            labelScore.Anchor = AnchorStyles.None;
            labelScore.AutoSize = true;
            labelScore.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelScore.Location = new Point(300, 81);
            labelScore.Name = "labelScore";
            labelScore.Size = new Size(73, 21);
            labelScore.TabIndex = 2;
            labelScore.Text = "Score : 0";
            // 
            // buttonStart
            // 
            buttonStart.Anchor = AnchorStyles.None;
            buttonStart.BackColor = Color.LightBlue;
            buttonStart.FlatStyle = FlatStyle.Popup;
            buttonStart.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonStart.Location = new Point(273, 668);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(135, 44);
            buttonStart.TabIndex = 3;
            buttonStart.Text = "START";
            buttonStart.UseVisualStyleBackColor = false;
            // 
            // NewTetrisForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(710, 748);
            Controls.Add(panel1);
            Name = "NewTetrisForm";
            Text = "Tetris";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label lblTitel;
        private Label labelScore;
        private Button buttonStart;
    }
}
