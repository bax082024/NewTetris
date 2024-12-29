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





    }
}
