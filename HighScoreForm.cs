using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace NewTetris
{
    public partial class HighScoreForm : Form
    {
        private List<HighScore> highScores;
        private int currentScore; // Score from the game

        public HighScoreForm(int score)
        {
            InitializeComponent();
            currentScore = score;
            highScores = HighScore.LoadHighScores();
            PopulateHighScoreList();

            if (currentScore > 0)
            {
                textBoxScore.Text = currentScore.ToString();
            }
        }

        private void PopulateHighScoreList()
        {
            dataGridViewHighScores.Rows.Clear();
            foreach (var score in highScores)
            {
                dataGridViewHighScores.Rows.Add(score.Name, score.Score);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string name = textBoxScore.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter your name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            highScores.Add(new HighScore { Name = name, Score = currentScore });
            highScores = highScores.OrderByDescending(s => s.Score).Take(10).ToList(); // Keep top 10 scores
            HighScore.SaveHighScores(highScores);
            PopulateHighScoreList();

            MessageBox.Show("Your score has been added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close(); // Close the form after adding the score
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush gradientBrush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.DarkBlue,  // Top color
                Color.Purple,        // Bottom color
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(gradientBrush, this.ClientRectangle);
            }
        }

    }
}
