using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;

namespace NewTetris
{
    private List<HighScore> highScores;
    private int currentScore;


    public partial class HighScoreForm : Form
    {
        public HighScoreForm()
        {
            InitializeComponent();
            currentScore = score;
            highScores = HighScore.LoadHighScores();
            PopulateHighScoreGrid();
        }

        private void PopulateHighScoreGrid()
        {
            dataGridViewHighScores.Rows.Clear();
            foreach (var highScore in highScores)
            {
                dataGridViewHighScores.Rows.Add(highScore.Name, highScore.Score);
            }
        }

        private void buttonAddName_Click(object sender, EventArgs e)
        {
            var name = textBoxName.Text.Trim();
            if (!string.IsNullOrEmpty(name))
            {
                highScores.Add(new HighScore { Name = name, Score = currentScore });
                HighScore.SaveHighScores(highScores);
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter your name!");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
