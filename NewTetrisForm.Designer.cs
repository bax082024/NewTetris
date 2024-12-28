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
            buttonStart = new Button();
            labelScore = new Label();
            lblTitel = new Label();
            gamePanel = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(buttonStart);
            panel1.Controls.Add(labelScore);
            panel1.Controls.Add(lblTitel);
            panel1.Controls.Add(gamePanel);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(710, 748);
            panel1.TabIndex = 0;
            // 
            // buttonStart
            // 
            buttonStart.Anchor = AnchorStyles.None;
            buttonStart.BackColor = Color.LightBlue;
            buttonStart.FlatStyle = FlatStyle.Popup;
            buttonStart.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonStart.Location = new Point(272, 675);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(135, 44);
            buttonStart.TabIndex = 3;
            buttonStart.Text = "START";
            buttonStart.UseVisualStyleBackColor = false;
            buttonStart.Click += buttonStart_Click;
            // 
            // labelScore
            // 
            labelScore.Anchor = AnchorStyles.None;
            labelScore.AutoSize = true;
            labelScore.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelScore.Location = new Point(297, 53);
            labelScore.Name = "labelScore";
            labelScore.Size = new Size(73, 21);
            labelScore.TabIndex = 2;
            labelScore.Text = "Score : 0";
            // 
            // lblTitel
            // 
            lblTitel.Anchor = AnchorStyles.None;
            lblTitel.AutoSize = true;
            lblTitel.Font = new Font("Snap ITC", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitel.Location = new Point(250, 0);
            lblTitel.Name = "lblTitel";
            lblTitel.Size = new Size(193, 48);
            lblTitel.TabIndex = 1;
            lblTitel.Text = "TETRIS";
            // 
            // gamePanel
            // 
            gamePanel.Anchor = AnchorStyles.None;
            gamePanel.BackColor = Color.Gainsboro;
            gamePanel.Location = new Point(119, 77);
            gamePanel.Name = "gamePanel";
            gamePanel.Size = new Size(458, 592);
            gamePanel.TabIndex = 0;
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
        private Panel gamePanel;
        private Label lblTitel;
        private Label labelScore;
        private Button buttonStart;
    }
}
