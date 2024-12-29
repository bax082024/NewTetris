namespace NewTetris
{
    partial class HighScoreForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            labelScore = new Label();
            label1 = new Label();
            buttonCancel = new Button();
            buttonAddName = new Button();
            textBoxScore = new TextBox();
            dataGridViewHighScores = new DataGridView();
            colName = new DataGridViewTextBoxColumn();
            colPoints = new DataGridViewTextBoxColumn();
            colLevel = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHighScores).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(labelScore);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(buttonCancel);
            panel1.Controls.Add(buttonAddName);
            panel1.Controls.Add(textBoxScore);
            panel1.Controls.Add(dataGridViewHighScores);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(339, 525);
            panel1.TabIndex = 0;
            // 
            // labelScore
            // 
            labelScore.AutoSize = true;
            labelScore.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelScore.ForeColor = Color.OrangeRed;
            labelScore.Location = new Point(84, 41);
            labelScore.Name = "labelScore";
            labelScore.Size = new Size(19, 20);
            labelScore.TabIndex = 5;
            labelScore.Text = "``";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Stencil", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Brown;
            label1.Location = new Point(84, 9);
            label1.Name = "label1";
            label1.Size = new Size(174, 32);
            label1.TabIndex = 4;
            label1.Text = "HighScore";
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.LightBlue;
            buttonCancel.FlatStyle = FlatStyle.Popup;
            buttonCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonCancel.Location = new Point(100, 472);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(140, 33);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonAddName
            // 
            buttonAddName.BackColor = Color.LightBlue;
            buttonAddName.FlatStyle = FlatStyle.Popup;
            buttonAddName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonAddName.Location = new Point(100, 433);
            buttonAddName.Name = "buttonAddName";
            buttonAddName.Size = new Size(140, 33);
            buttonAddName.TabIndex = 2;
            buttonAddName.Text = "Add Name";
            buttonAddName.UseVisualStyleBackColor = false;
            buttonAddName.Click += buttonAdd_Click;
            // 
            // textBoxScore
            // 
            textBoxScore.Anchor = AnchorStyles.None;
            textBoxScore.BackColor = Color.LightGray;
            textBoxScore.Location = new Point(100, 406);
            textBoxScore.Name = "textBoxScore";
            textBoxScore.PlaceholderText = "Insert Name";
            textBoxScore.Size = new Size(140, 23);
            textBoxScore.TabIndex = 1;
            // 
            // dataGridViewHighScores
            // 
            dataGridViewHighScores.BackgroundColor = Color.DarkSlateGray;
            dataGridViewHighScores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHighScores.Columns.AddRange(new DataGridViewColumn[] { colName, colPoints, colLevel });
            dataGridViewHighScores.Location = new Point(35, 67);
            dataGridViewHighScores.Name = "dataGridViewHighScores";
            dataGridViewHighScores.RowHeadersVisible = false;
            dataGridViewHighScores.Size = new Size(270, 323);
            dataGridViewHighScores.TabIndex = 0;
            // 
            // colName
            // 
            colName.HeaderText = "Name";
            colName.Name = "colName";
            colName.Width = 170;
            // 
            // colPoints
            // 
            colPoints.HeaderText = "Points";
            colPoints.Name = "colPoints";
            colPoints.Width = 50;
            // 
            // colLevel
            // 
            colLevel.HeaderText = "Level";
            colLevel.Name = "colLevel";
            colLevel.Width = 50;
            // 
            // HighScoreForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(339, 525);
            Controls.Add(panel1);
            Name = "HighScoreForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HighScoreForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHighScores).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dataGridViewHighScores;
        private Label label1;
        private Button buttonCancel;
        private Button buttonAddName;
        private TextBox textBoxScore;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colPoints;
        private DataGridViewTextBoxColumn colLevel;
        private Label labelScore;
    }
}