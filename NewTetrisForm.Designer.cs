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
            btnExit = new Button();
            buttonViewHighScores = new Button();
            labelLevel = new Label();
            pb6 = new PictureBox();
            pb4 = new PictureBox();
            pb2 = new PictureBox();
            pb8 = new PictureBox();
            pb7 = new PictureBox();
            pb1 = new PictureBox();
            pb3 = new PictureBox();
            pb5 = new PictureBox();
            buttonStart = new Button();
            labelScore = new Label();
            lblTitle = new Label();
            gamePanel = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb5).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(btnExit);
            panel1.Controls.Add(buttonViewHighScores);
            panel1.Controls.Add(labelLevel);
            panel1.Controls.Add(pb6);
            panel1.Controls.Add(pb4);
            panel1.Controls.Add(pb2);
            panel1.Controls.Add(pb8);
            panel1.Controls.Add(pb7);
            panel1.Controls.Add(pb1);
            panel1.Controls.Add(pb3);
            panel1.Controls.Add(pb5);
            panel1.Controls.Add(buttonStart);
            panel1.Controls.Add(labelScore);
            panel1.Controls.Add(lblTitle);
            panel1.Controls.Add(gamePanel);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(567, 714);
            panel1.TabIndex = 0;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Silver;
            btnExit.FlatStyle = FlatStyle.Popup;
            btnExit.Location = new Point(480, 688);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 14;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // buttonViewHighScores
            // 
            buttonViewHighScores.BackColor = Color.Silver;
            buttonViewHighScores.FlatStyle = FlatStyle.Popup;
            buttonViewHighScores.Location = new Point(464, 130);
            buttonViewHighScores.Name = "buttonViewHighScores";
            buttonViewHighScores.Size = new Size(75, 23);
            buttonViewHighScores.TabIndex = 13;
            buttonViewHighScores.Text = "Highscore";
            buttonViewHighScores.UseVisualStyleBackColor = false;
            buttonViewHighScores.Click += buttonViewHighScores_Click;
            // 
            // labelLevel
            // 
            labelLevel.Anchor = AnchorStyles.None;
            labelLevel.AutoSize = true;
            labelLevel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelLevel.ForeColor = Color.Brown;
            labelLevel.Location = new Point(309, 36);
            labelLevel.Name = "labelLevel";
            labelLevel.Size = new Size(71, 21);
            labelLevel.TabIndex = 12;
            labelLevel.Text = "Level : 1";
            // 
            // pb6
            // 
            pb6.Anchor = AnchorStyles.None;
            pb6.BackgroundImage = Properties.Resources._4;
            pb6.BackgroundImageLayout = ImageLayout.Zoom;
            pb6.Location = new Point(464, 191);
            pb6.Name = "pb6";
            pb6.Size = new Size(64, 52);
            pb6.TabIndex = 11;
            pb6.TabStop = false;
            // 
            // pb4
            // 
            pb4.Anchor = AnchorStyles.None;
            pb4.BackgroundImage = Properties.Resources._4;
            pb4.BackgroundImageLayout = ImageLayout.Zoom;
            pb4.Location = new Point(22, 609);
            pb4.Name = "pb4";
            pb4.Size = new Size(64, 52);
            pb4.TabIndex = 10;
            pb4.TabStop = false;
            // 
            // pb2
            // 
            pb2.Anchor = AnchorStyles.None;
            pb2.BackgroundImage = Properties.Resources._3;
            pb2.BackgroundImageLayout = ImageLayout.Zoom;
            pb2.Location = new Point(22, 212);
            pb2.Name = "pb2";
            pb2.Size = new Size(79, 69);
            pb2.TabIndex = 9;
            pb2.TabStop = false;
            // 
            // pb8
            // 
            pb8.Anchor = AnchorStyles.None;
            pb8.BackgroundImage = Properties.Resources._3;
            pb8.BackgroundImageLayout = ImageLayout.Zoom;
            pb8.Location = new Point(464, 609);
            pb8.Name = "pb8";
            pb8.Size = new Size(79, 69);
            pb8.TabIndex = 8;
            pb8.TabStop = false;
            // 
            // pb7
            // 
            pb7.Anchor = AnchorStyles.None;
            pb7.BackgroundImage = Properties.Resources._2;
            pb7.BackgroundImageLayout = ImageLayout.Zoom;
            pb7.Location = new Point(464, 396);
            pb7.Name = "pb7";
            pb7.Size = new Size(79, 69);
            pb7.TabIndex = 7;
            pb7.TabStop = false;
            // 
            // pb1
            // 
            pb1.Anchor = AnchorStyles.None;
            pb1.BackgroundImage = Properties.Resources._2;
            pb1.BackgroundImageLayout = ImageLayout.Zoom;
            pb1.Location = new Point(22, 3);
            pb1.Name = "pb1";
            pb1.Size = new Size(79, 69);
            pb1.TabIndex = 6;
            pb1.TabStop = false;
            // 
            // pb3
            // 
            pb3.Anchor = AnchorStyles.None;
            pb3.BackgroundImage = Properties.Resources._1;
            pb3.BackgroundImageLayout = ImageLayout.Zoom;
            pb3.Location = new Point(22, 433);
            pb3.Name = "pb3";
            pb3.Size = new Size(79, 69);
            pb3.TabIndex = 5;
            pb3.TabStop = false;
            // 
            // pb5
            // 
            pb5.Anchor = AnchorStyles.None;
            pb5.BackgroundImage = Properties.Resources._1;
            pb5.BackgroundImageLayout = ImageLayout.Zoom;
            pb5.Location = new Point(464, 3);
            pb5.Name = "pb5";
            pb5.Size = new Size(79, 69);
            pb5.TabIndex = 4;
            pb5.TabStop = false;
            // 
            // buttonStart
            // 
            buttonStart.Anchor = AnchorStyles.None;
            buttonStart.BackColor = Color.LightBlue;
            buttonStart.FlatStyle = FlatStyle.Popup;
            buttonStart.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonStart.Location = new Point(230, 667);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(104, 33);
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
            labelScore.ForeColor = Color.Brown;
            labelScore.Location = new Point(161, 36);
            labelScore.Name = "labelScore";
            labelScore.Size = new Size(73, 21);
            labelScore.TabIndex = 2;
            labelScore.Text = "Score : 0";
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.None;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Stencil", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Brown;
            lblTitle.Location = new Point(210, -3);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(153, 44);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "TETRIS";
            // 
            // gamePanel
            // 
            gamePanel.Anchor = AnchorStyles.None;
            gamePanel.BackColor = Color.LightGray;
            gamePanel.Location = new Point(131, 60);
            gamePanel.Name = "gamePanel";
            gamePanel.Size = new Size(303, 601);
            gamePanel.TabIndex = 0;
            // 
            // NewTetrisForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(567, 714);
            Controls.Add(panel1);
            Name = "NewTetrisForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tetris";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pb6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb5).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel gamePanel;
        private Label lblTitle;
        private Label labelScore;
        private Button buttonStart;
        private PictureBox pb6;
        private PictureBox pb4;
        private PictureBox pb2;
        private PictureBox pb8;
        private PictureBox pb7;
        private PictureBox pb1;
        private PictureBox pb3;
        private PictureBox pb5;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Label labelLevel;
        private Button buttonViewHighScores;
        private Button btnExit;
    }
}
