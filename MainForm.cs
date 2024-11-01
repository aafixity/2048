namespace _2048
{
    public partial class MainForm : Form
    {
        private readonly Board _board;
        public MainForm()
        {
            _board = new();
            InitializeComponent();
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _board.Clear();
            _board.SetNew();
            PrintBoard();
        }

        private void PrintBoard()
        {
            currentScoreLabel.Text = _board.Score.ToString();
            int j = 0;
            for (int y = 0; y < Board.SIZE; y++)
            {
                for (int x = 0; x < Board.SIZE; x++)
                {
                    Control control = numsPanel.Controls[j++];
                    if (control is Label label)
                    {
                        label.Text = _board.Array[y, x] == 0 ?
                            "" : _board.Array[y, x].ToString();

                        label.BackColor = Color.FromArgb(205, 193, 180);
                        label.ForeColor = Color.FromArgb(249, 246, 242);

                        switch (_board.Array[y, x])
                        {
                            case 2:
                                label.BackColor = Color.FromArgb(238, 228, 218);
                                label.ForeColor = Color.FromArgb(119, 110, 101);
                                break;
                            case 4:
                                label.BackColor = Color.FromArgb(237, 224, 200);
                                label.ForeColor = Color.FromArgb(119, 110, 101);
                                break;
                            case 8:
                                label.BackColor = Color.FromArgb(243, 176, 121);
                                break;
                            case 16:
                                label.BackColor = Color.FromArgb(246, 148, 99);
                                break;
                            case 32:
                                label.BackColor = Color.FromArgb(247, 123, 95);
                                break;
                            case 64:
                                label.BackColor = Color.FromArgb(246, 94, 57);
                                break;
                            case 128:
                                label.BackColor = Color.FromArgb(238, 207, 114);
                                break;
                            case 256:
                                label.BackColor = Color.FromArgb(237, 205, 96);
                                break;
                            case 512:
                                label.BackColor = Color.FromArgb(238, 200, 86);
                                break;
                            case 1024:
                                label.BackColor = Color.FromArgb(237, 197, 63);
                                break;
                            case 2048:
                                label.BackColor = Color.FromArgb(238, 193, 48);
                                break;
                            case 4096:
                                label.BackColor = Color.FromArgb(239, 102, 109);
                                break;
                            case 8192:
                                label.BackColor = Color.FromArgb(237, 77, 89);
                                break;
                            case 16384:
                                label.BackColor = Color.FromArgb(244, 64, 65);
                                break;
                            case 32768:
                                label.BackColor = Color.FromArgb(113, 180, 214);
                                break;
                            case 65536:
                                label.BackColor = Color.FromArgb(92, 160, 223);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (_board.IsGameOver())
            {
                if (_board.Score > Convert.ToInt32(bestScoreLabel.Text))
                    bestScoreLabel.Text = _board.Score.ToString();
                MessageBox.Show("YOU LOSE!", "GAME OVER!", MessageBoxButtons.OK);
            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.W:
                        _board.Up();
                        break;
                    case Keys.S:
                        _board.Down();
                        break;
                    case Keys.A:
                        _board.Left();
                        break;
                    case Keys.D:
                        _board.Right();
                        break;
                }
                _board.SetNew();
                PrintBoard();
            }
        }
    }
}
