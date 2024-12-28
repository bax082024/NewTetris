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







    }
}
