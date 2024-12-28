namespace NewTetris
{
    public partial class NewTetrisForm : Form
    {
        private int gridWidth = 10; // Number of columns
        private int gridHeight = 20; // Number of rows
        private int cellSize = 30; // Size of each block in pixels
        private Color[,] grid; // The grid to store colors of placed blocks
        private Tetromino currentTetromino; // The current piece
        private int score = 0; // Player's score
        private int level = 1; // Current game level
        private int fallSpeed = 500; // Speed in milliseconds
        private System.Windows.Forms.Timer gameTimer = new System.Windows.Forms.Timer();
        private Random random = new Random();

        public NewTetrisForm()
        {
            InitializeComponent();
        }

        public class Tetromino
        {
            public Point[] Blocks { get; private set; } // Array of points representing blocks
            public Color Color { get; private set; } // Color of the Tetromino
            public Point Position { get; set; } // Top-left position of the Tetromino

            public Tetromino(Point[] blocks, Color color)
            {
                Blocks = blocks;
                Color = color;
                Position = new Point(0, 0);
            }

            public void MoveLeft() => Position.X--;
            public void MoveRight() => Position.X++;
            public void MoveDown() => Position.Y++;
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
            return type switch
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
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            grid = new Color[gridHeight, gridWidth]; // Initialize the grid
            score = 0;
            level = 1;
            fallSpeed = 500;
            currentTetromino = GenerateRandomTetromino(); // Generate the first piece
            gameTimer.Interval = fallSpeed;
            gameTimer.Start();
            gamePanel.Invalidate(); // Redraw the game area
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

                if (IsGameOver())
                {
                    gameTimer.Stop();
                    MessageBox.Show("Game Over! Score: " + score, "Tetris");
                }
            }

            gamePanel.Invalidate(); // Redraw the game
        }

        private bool CanMoveDown(Tetromino tetromino)
        {
            foreach (var block in tetromino.Blocks)
            {
                int newX = tetromino.Position.X + block.X;
                int newY = tetromino.Position.Y + block.Y + 1;

                if (newY >= gridHeight || (newY >= 0 && grid[newY, newX] != Color.Empty))
                    return false;
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
            foreach (var block in currentTetromino.Blocks)
            {
                int drawX = (currentTetromino.Position.X + block.X) * cellSize;
                int drawY = (currentTetromino.Position.Y + block.Y) * cellSize;
                g.FillRectangle(new SolidBrush(currentTetromino.Color), drawX, drawY, cellSize, cellSize);
                g.DrawRectangle(Pens.Black, drawX, drawY, cellSize, cellSize);
            }
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
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
                case Keys.Space: // Hard drop
                    while (CanMoveDown(currentTetromino))
                        currentTetromino.MoveDown();
                    break;
            }

            gamePanel.Invalidate(); // Redraw
        }








    }
}
