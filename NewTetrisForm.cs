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

        private bool moveLeft = false;
        private bool moveRight = false;
        private bool rotate = false;
        private bool hardDrop = false;

        public NewTetrisForm()
        {
            InitializeComponent();

            this.KeyPreview = true;
          

            gameTimer.Tick += GameTimer_Tick;

            // Properly connect Paint event
            gamePanel.Paint += GamePanel_Paint;

            grid = new Color[gridHeight, gridWidth];
        }

        public class Tetromino
        {
            private Point position; // Backing field for position
            public Point Position
            {
                get => position;
                set => position = value; // Allow mutation
            }

            public Point[] Blocks { get; private set; } // Array of points representing blocks
            public Color Color { get; private set; } // Color of the Tetromino

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
            Console.WriteLine("Start Button Clicked");
            this.Focus(); // Ensure the form has focus


            currentTetromino = GenerateRandomTetromino();
            currentTetromino.Position = new Point(gridWidth / 2, 0);

            // Reset grid
            for (int y = 0; y < gridHeight; y++)
            {
                for (int x = 0; x < gridWidth; x++)
                {
                    grid[y, x] = Color.Empty; // Clear the grid
                }
            }

            // Reset game state
            score = 0;
            level = 1;
            fallSpeed = 500;
            labelScore.Text = "Score: " + score;

            // Initialize Tetromino
            currentTetromino = GenerateRandomTetromino();
            currentTetromino.Position = new Point(gridWidth / 2, 0);

            // Configure game timer
            gameTimer.Interval = fallSpeed;
            gameTimer.Start();

            // Redraw game panel
            gamePanel.Invalidate();
        }








        private void GameTimer_Tick(object sender, EventArgs e)
        {
            // Handle continuous movement
            if (moveLeft && CanMoveLeft(currentTetromino))
            {
                currentTetromino.MoveLeft();
                moveLeft = false; // Reset after movement
            }
            else if (moveRight && CanMoveRight(currentTetromino))
            {
                currentTetromino.MoveRight();
                moveRight = false; // Reset after movement
            }

            // Handle rotation
            if (rotate && CanRotate(currentTetromino))
            {
                currentTetromino.Rotate();
                rotate = false; // Reset after rotation
            }

            // Handle hard drop
            if (hardDrop)
            {
                while (CanMoveDown(currentTetromino))
                    currentTetromino.MoveDown();
                hardDrop = false; // Reset after hard drop
            }

            // Handle falling
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
                    MessageBox.Show("Game Over! Score: " + score, "Tetris");
                    return;
                }
            }

            gamePanel.Invalidate(); // Redraw the game
        }






        private bool CanMoveDown(Tetromino tetromino)
        {
            foreach (var block in tetromino.Blocks)
            {
                int newX = tetromino.Position.X + block.X; // Column
                int newY = tetromino.Position.Y + block.Y + 1; // Row (move down)

                // Check if the block would go out of bounds (past the bottom)
                if (newY >= gridHeight)
                {
                    return false;
                }

                // Check if the block would collide with an existing block on the grid
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

            // Draw the current Tetromino if it's not null
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





        private void NewTetrisForm_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                moveLeft = true;
            else if (e.KeyCode == Keys.Right)
                moveRight = true;
            else if (e.KeyCode == Keys.Up)
                rotate = true;
            else if (e.KeyCode == Keys.Space)
                hardDrop = true;
        }

        private void NewTetrisForm_KeyUp(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                moveLeft = false;
            else if (e.KeyCode == Keys.Right)
                moveRight = false;
            else if (e.KeyCode == Keys.Up)
                rotate = false;
            else if (e.KeyCode == Keys.Space)
                hardDrop = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left:
                    moveLeft = true;
                    break;
                case Keys.Right:
                    moveRight = true;
                    break;
                case Keys.Up:
                    rotate = true;
                    break;
                case Keys.Space:
                    hardDrop = true;
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }







        private void PlaceTetrominoOnGrid(Tetromino tetromino)
        {
            foreach (var block in tetromino.Blocks)
            {
                int x = tetromino.Position.X + block.X;
                int y = tetromino.Position.Y + block.Y;

                // Ensure placement is within bounds
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
                    // Shift all rows above down
                    for (int row = y; row > 0; row--)
                    {
                        for (int col = 0; col < gridWidth; col++)
                        {
                            grid[row, col] = grid[row - 1, col];
                        }
                    }

                    // Clear the top row
                    for (int col = 0; col < gridWidth; col++)
                    {
                        grid[0, col] = Color.Empty;
                    }

                    y++; // Recheck this row after shifting
                    score += 100; // Update score
                    labelScore.Text = "Score: " + score;
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



        private bool CanMoveRight(Tetromino tetromino)
        {
            foreach (var block in tetromino.Blocks)
            {
                int x = tetromino.Position.X + block.X + 1;
                int y = tetromino.Position.Y + block.Y;

                if (x >= gridWidth || (y >= 0 && grid[y, x] != Color.Empty))
                {
                    return false;
                }
            }
            return true;
        }

        private bool CanMoveLeft(Tetromino tetromino)
        {
            Console.WriteLine("Checking CanMoveLeft...");
            foreach (var block in tetromino.Blocks)
            {
                int x = tetromino.Position.X + block.X - 1;
                int y = tetromino.Position.Y + block.Y;

                if (x < 0 || (y >= 0 && grid[y, x] != Color.Empty))
                {
                    Console.WriteLine("Cannot move left");
                    return false;
                }
            }
            Console.WriteLine("Can move left");
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

        
    }
}
