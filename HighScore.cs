using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NewTetris
{
    public class HighScore
    {
        public string Name { get; set; } = String.Empty;
        public int Score { get; set; }

        private static string filePath = "highscores.txt";

        public static List<HighScore> LoadHighScores()
        {
            var scores = new List<HighScore>();
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 2 && int.TryParse(parts[1], out int score))
                    {
                        scores.Add(new HighScore { Name = parts[0], Score = score });
                    }
                }
            }
            return scores.OrderByDescending(s => s.Score).ToList();
        }


    }
}
