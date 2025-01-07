using NAudio.Wave;
using System.Drawing.Drawing2D;

namespace NewTetris
{
    public partial class NewTetrisForm : Form
    {
        private int gridWidth = 10;
        private int gridHeight = 20;
        private int cellSize = 30;
        private Color[,] grid;
        private Tetromino currentTetromino;
        private int score = 0;
        private int level = 1;
        private int fallSpeed = 500;
        private System.Windows.Forms.Timer gameTimer = new System.Windows.Forms.Timer();
        private Random random = new Random();

        private WaveOutEvent startButtonSound;
        private WaveOutEvent gameplayMusic;
        private WaveOutEvent collisionSound;
        private Mp3FileReader startButtonReader;
        private Mp3FileReader gameplayMusicReader;
        private Mp3FileReader collisionSoundReader;

        public NewTetrisForm()
        {
            InitializeComponent();

            LoadSounds();

            this.KeyPreview = true;
            this.KeyDown += NewTetrisForm_KeyDown;

            gameTimer.Tick += GameTimer_Tick;
            gamePanel.Paint += GamePanel_Paint;

            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.Resize += NewTetrisForm_Resize;



            grid = new Color[gridHeight, gridWidth];
        }

        private void NewTetrisForm_Load(object sender, EventArgs e)
        {
            NewTetrisForm_Resize(this, EventArgs.Empty);
        }


        public class Tetromino
        {
            private Point position;
            public Point Position
            {
                get => position;
                set => position = value;
            }

            public Point[] Blocks { get; private set; }
            public Color Color { get; private set; }

            public Tetromino(Point[] blocks, Color color)
            {
                Blocks = blocks;
                Color = color;
                Position = new Point(0, 0);
            }

            public void MoveLeft() => Position = new Point(Position.X - 1, Position.Y);
            public void MoveRight() => Position = new Point(Position.X + 1, Position.Y);
            public void MoveDown() => Position = new Point(Position.X, Position.Y + 1);
            public void Rotate()
            {
                for (int i = 0; i < Blocks.Length; i++)
                {
                    int x = Blocks[i].X;
                    Blocks[i].X = Blocks[i].Y;
                    Blocks[i].Y = -x;
                }
            }
        }

        private Tetromino GenerateRandomTetromino()
        {
            int type = random.Next(0, 7);
            var tetromino = type switch
            {
                0 => new Tetromino(new Point[] { new Point(0, 0), new Point(1, 0), new Point(-1, 0), new Point(0, 1) }, Color.Cyan), // T
                1 => new Tetromino(new Point[] { new Point(0, 0), new Point(1, 0), new Point(-1, 0), new Point(-1, 1) }, Color.Blue), // L
                2 => new Tetromino(new Point[] { new Point(0, 0), new Point(1, 0), new Point(-1, 0), new Point(1, 1) }, Color.Orange), // Reverse L
                3 => new Tetromino(new Point[] { new Point(0, 0), new Point(0, 1), new Point(1, 0), new Point(1, 1) }, Color.Yellow), // Square
                4 => new Tetromino(new Point[] { new Point(0, 0), new Point(1, 0), new Point(1, 1), new Point(0, -1) }, Color.Green), // S
                5 => new Tetromino(new Point[] { new Point(0, 0), new Point(-1, 0), new Point(-1, 1), new Point(0, -1) }, Color.Red), // Z
                6 => new Tetromino(new Point[] { new Point(0, 0), new Point(1, 0), new Point(-1, 0), new Point(-2, 0) }, Color.Purple), // Line
                _ => throw new Exception("Invalid Tetromino type")
            };

            tetromino.Position = new Point(gridWidth / 2, 0);

            if (!CanMoveDown(tetromino) && IsGameOver())
            {
                ShowGameOverDialog();
            }

            return tetromino;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Start Button Clicked");

            startButtonSound.Stop();
            startButtonSound.Play();

            gameplayMusic.Stop();
            StartGameplayMusic();

            StartGame();
        }

        private void StartGame()
        {
            for (int y = 0; y < gridHeight; y++)
            {
                for (int x = 0; x < gridWidth; x++)
                {
                    grid[y, x] = Color.Empty;
                }
            }

            score = 0;
            level = 1;
            fallSpeed = 500;
            labelScore.Text = "Score: " + score;
            labelLevel.Text = "Level: " + level;

            currentTetromino = GenerateRandomTetromino();
            currentTetromino.Position = new Point(gridWidth / 2, 0);

            gameTimer.Interval = fallSpeed;
            gameTimer.Start();

            gamePanel.Invalidate();
        }




        private void StartGameplayMusic()
        {
            gameplayMusic.Play();
            gameplayMusic.PlaybackStopped += (s, e) =>
            {
                gameplayMusicReader.Position = 0;
                gameplayMusic.Play();
            };
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

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (CanMoveDown(currentTetromino))
            {
                currentTetromino.MoveDown();
            }
            else
            {
                PlaceTetrominoOnGrid(currentTetromino);
                ClearCompletedRows();

                currentTetromino = GenerateRandomTetromino();
                currentTetromino.Position = new Point(gridWidth / 2, 0);

                if (IsGameOver())
                {
                    gameTimer.Stop();
                    ShowGameOverDialog();
                    return;
                }
            }

            gamePanel.Invalidate();
        }




        private void ShowGameOverDialog()
        {
            gameplayMusic?.Stop();
            gameTimer.Stop();

            var highScoreForm = new HighScoreForm(score);
            highScoreForm.ShowDialog();

            var result = MessageBox.Show(
                "Do you want to play again?",
                "Game Over",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                RestartGame();
            }
            else
            {
                Application.Exit();
            }
        }

        private void RestartGame()
        {
            score = 0;
            level = 1;
            fallSpeed = 500;
            labelScore.Text = $"Score: {score}";
            labelLevel.Text = $"Level: {level}";

            for (int y = 0; y < gridHeight; y++)
            {
                for (int x = 0; x < gridWidth; x++)
                {
                    grid[y, x] = Color.Empty;
                }
            }

            currentTetromino = GenerateRandomTetromino();
            currentTetromino.Position = new Point(gridWidth / 2, 0);

            gameTimer.Start();
            StartGameplayMusic();

            gamePanel.Invalidate();
        }

        private bool CanMoveDown(Tetromino tetromino)
        {
            foreach (var block in tetromino.Blocks)
            {
                int newX = tetromino.Position.X + block.X;
                int newY = tetromino.Position.Y + block.Y + 1;

                if (newY >= gridHeight)
                {
                    return false;
                }

                if (newY >= 0 && grid[newY, newX] != Color.Empty)
                {
                    return false;
                }
            }
            return true;
        }

        private void GamePanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Draw the grid
            for (int y = 0; y < gridHeight; y++)
            {
                for (int x = 0; x < gridWidth; x++)
                {
                    if (grid[y, x] != Color.Empty)
                    {
                        g.FillRectangle(new SolidBrush(grid[y, x]), x * cellSize, y * cellSize, cellSize, cellSize);
                        g.DrawRectangle(Pens.Black, x * cellSize, y * cellSize, cellSize, cellSize);
                    }
                }
            }

            // Draw the current Tetromino
            if (currentTetromino != null)
            {
                foreach (var block in currentTetromino.Blocks)
                {
                    int drawX = (currentTetromino.Position.X + block.X) * cellSize;
                    int drawY = (currentTetromino.Position.Y + block.Y) * cellSize;
                    g.FillRectangle(new SolidBrush(currentTetromino.Color), drawX, drawY, cellSize, cellSize);
                    g.DrawRectangle(Pens.Black, drawX, drawY, cellSize, cellSize);
                }
            }
        }


        private void NewTetrisForm_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine($"Key pressed: {e.KeyCode}");

            if (currentTetromino == null) return;

            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (CanMoveLeft(currentTetromino)) currentTetromino.MoveLeft();
                    break;

                case Keys.Right:
                    if (CanMoveRight(currentTetromino)) currentTetromino.MoveRight();
                    break;

                case Keys.Up:
                    if (CanRotate(currentTetromino)) currentTetromino.Rotate();
                    break;

                case Keys.Down:
                    if (CanMoveDown(currentTetromino)) currentTetromino.MoveDown();
                    else
                    {
                        PlaceTetrominoOnGrid(currentTetromino);
                        ClearCompletedRows();
                        currentTetromino = GenerateRandomTetromino();
                        currentTetromino.Position = new Point(gridWidth / 2, 0);

                        if (IsGameOver())
                        {
                            gameTimer.Stop();
                            MessageBox.Show("Game Over! Score: " + score, "Tetris");
                        }
                    }
                    break;

                case Keys.Space:
                    while (CanMoveDown(currentTetromino)) currentTetromino.MoveDown();
                    PlaceTetrominoOnGrid(currentTetromino);
                    ClearCompletedRows();
                    currentTetromino = GenerateRandomTetromino();
                    currentTetromino.Position = new Point(gridWidth / 2, 0);

                    if (IsGameOver())
                    {
                        gameTimer.Stop();
                        MessageBox.Show("Game Over! Score: " + score, "Tetris");
                    }
                    break;
            }

            gamePanel.Invalidate();
        }

        private void NewTetrisForm_KeyUp(object? sender, KeyEventArgs e)
        {
            // If needed
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left:
                    NewTetrisForm_KeyDown(this, new KeyEventArgs(Keys.Left));
                    break;

                case Keys.Right:
                    NewTetrisForm_KeyDown(this, new KeyEventArgs(Keys.Right));
                    break;

                case Keys.Up:
                    NewTetrisForm_KeyDown(this, new KeyEventArgs(Keys.Up));
                    break;

                case Keys.Down:
                    NewTetrisForm_KeyDown(this, new KeyEventArgs(Keys.Down));
                    break;

                case Keys.Space:
                    NewTetrisForm_KeyDown(this, new KeyEventArgs(Keys.Space));
                    break;

                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }

            return true;
        }

        private void PlaceTetrominoOnGrid(Tetromino tetromino)
        {
            foreach (var block in tetromino.Blocks)
            {
                int x = tetromino.Position.X + block.X;
                int y = tetromino.Position.Y + block.Y;

                if (y >= 0 && y < gridHeight && x >= 0 && x < gridWidth)
                {
                    grid[y, x] = tetromino.Color;
                }
            }
        }

        private void ClearCompletedRows()
        {
            for (int y = gridHeight - 1; y >= 0; y--)
            {
                bool isComplete = true;
                for (int x = 0; x < gridWidth; x++)
                {
                    if (grid[y, x] == Color.Empty)
                    {
                        isComplete = false;
                        break;
                    }
                }

                if (isComplete)
                {
                    for (int row = y; row > 0; row--)
                    {
                        for (int col = 0; col < gridWidth; col++)
                        {
                            grid[row, col] = grid[row - 1, col];
                        }
                    }

                    for (int col = 0; col < gridWidth; col++)
                    {
                        grid[0, col] = Color.Empty;
                    }

                    y++;
                    score += 100;
                    labelScore.Text = "Score: " + score;

                    int newLevel = (score / 500) + 1;
                    if (newLevel > level)
                    {
                        level = newLevel;
                        labelLevel.Text = "Level: " + level;
                        fallSpeed = Math.Max(50, 500 - (level - 1) * 50);
                        gameTimer.Interval = fallSpeed;
                    }
                }
            }
        }


        private bool IsGameOver()
        {
            foreach (var block in currentTetromino.Blocks)
            {
                int x = currentTetromino.Position.X + block.X;
                int y = currentTetromino.Position.Y + block.Y;

                if (y >= 0 && grid[y, x] != Color.Empty)
                {
                    return true;
                }
            }
            return false;
        }

        private bool CanMoveLeft(Tetromino tetromino)
        {
            foreach (var block in tetromino.Blocks)
            {
                int x = tetromino.Position.X + block.X - 1;
                int y = tetromino.Position.Y + block.Y;

                if (x < 0 || (y >= 0 && grid[y, x] != Color.Empty))
                    return false;
            }
            return true;
        }

        private bool CanMoveRight(Tetromino tetromino)
        {
            foreach (var block in tetromino.Blocks)
            {
                int x = tetromino.Position.X + block.X + 1;
                int y = tetromino.Position.Y + block.Y;

                if (x >= gridWidth || (y >= 0 && grid[y, x] != Color.Empty))
                    return false;
            }
            return true;
        }

        private bool CanRotate(Tetromino tetromino)
        {
            foreach (var block in tetromino.Blocks)
            {
                int x = tetromino.Position.X - block.Y;
                int y = tetromino.Position.Y + block.X;

                if (x < 0 || x >= gridWidth || y >= gridHeight || (y >= 0 && grid[y, x] != Color.Empty))
                {
                    return false;
                }
            }
            return true;
        }

        private void LoadSounds()
        {
            startButtonSound = new WaveOutEvent();
            gameplayMusic = new WaveOutEvent();
            collisionSound = new WaveOutEvent();

            startButtonReader = new Mp3FileReader("Sounds/startbutton.mp3");
            gameplayMusicReader = new Mp3FileReader("Sounds/tetris.mp3");
            collisionSoundReader = new Mp3FileReader("Sounds/collision.mp3");

            startButtonSound.Init(startButtonReader);
            gameplayMusic.Init(gameplayMusicReader);
            collisionSound.Init(collisionSoundReader);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            startButtonSound?.Dispose();
            gameplayMusic?.Dispose();
            collisionSound?.Dispose();
            startButtonReader?.Dispose();
            gameplayMusicReader?.Dispose();
            collisionSoundReader?.Dispose();

            base.OnFormClosing(e);
        }

        private void buttonViewHighScores_Click(object sender, EventArgs e)
        {
            var highScoreForm = new HighScoreForm(0);
            highScoreForm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            gameplayMusic.Stop();
        }

        private void NewTetrisForm_Resize(object sender, EventArgs e)
        {
            int newCellSize = Math.Min(
                (this.ClientSize.Width - (cellSize * 6)) / gridWidth,
                (this.ClientSize.Height - (cellSize * 8)) / gridHeight
            );
            if (newCellSize < 10) return;
            cellSize = newCellSize;

            gamePanel.Width = cellSize * gridWidth;
            gamePanel.Height = cellSize * gridHeight;
            gamePanel.Left = (this.ClientSize.Width - gamePanel.Width) / 2;
            gamePanel.Top = (this.ClientSize.Height - gamePanel.Height) / 2;

            labelScore.Font = new Font(labelScore.Font.FontFamily, cellSize / 2);
            labelScore.Left = gamePanel.Left;
            labelScore.Top = gamePanel.Top - (int)(1.5 * cellSize);

            labelLevel.Font = new Font(labelLevel.Font.FontFamily, cellSize / 2);
            labelLevel.Left = gamePanel.Right - labelLevel.Width;
            labelLevel.Top = gamePanel.Top - (int)(1.5 * cellSize);

            lblTitle.Font = new Font(lblTitle.Font.FontFamily, cellSize / 1.6f);
            lblTitle.Left = (this.ClientSize.Width - lblTitle.Width) / 2;
            lblTitle.Top = gamePanel.Top - (int)(3 * cellSize);

            buttonStart.Width = cellSize * 3;
            buttonStart.Height = cellSize;
            buttonStart.Left = (this.ClientSize.Width - buttonStart.Width) / 2;
            buttonStart.Top = gamePanel.Bottom + cellSize;

            buttonViewHighScores.Width = cellSize * 2;
            buttonViewHighScores.Height = cellSize;
            buttonViewHighScores.Left = gamePanel.Right + (cellSize / 2);
            buttonViewHighScores.Top = buttonStart.Top;

            buttonExit.Width = cellSize * 2;
            buttonExit.Height = cellSize;
            buttonExit.Left = gamePanel.Left - buttonExit.Width - (cellSize / 2);
            buttonExit.Top = buttonStart.Top;

            AdjustPictureBox(pb1, gamePanel.Left - (cellSize * 4), gamePanel.Top);
            AdjustPictureBox(pb2, gamePanel.Left - (cellSize * 4), gamePanel.Top + (cellSize * 6));
            AdjustPictureBox(pb3, gamePanel.Left - (cellSize * 4), gamePanel.Top + (cellSize * 12));
            AdjustPictureBox(pb4, gamePanel.Left - (cellSize * 4), gamePanel.Top + (cellSize * 18));

            AdjustPictureBox(pb5, gamePanel.Right + (cellSize * 1), gamePanel.Top);
            AdjustPictureBox(pb6, gamePanel.Right + (cellSize * 1), gamePanel.Top + (cellSize * 6));
            AdjustPictureBox(pb7, gamePanel.Right + (cellSize * 1), gamePanel.Top + (cellSize * 12));
            AdjustPictureBox(pb8, gamePanel.Right + (cellSize * 1), gamePanel.Top + (cellSize * 18));

            gamePanel.Invalidate();
        }


        private void AdjustPictureBox(PictureBox pictureBox, int left, int top)
        {
            int pictureBoxScaleFactor = 2;
            pictureBox.Width = cellSize * pictureBoxScaleFactor;
            pictureBox.Height = cellSize * pictureBoxScaleFactor;
            pictureBox.Left = left;
            pictureBox.Top = top;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
