using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Soduko;



namespace SudukoDesktopApp
{
    public partial class SudukoGUI : Form
    {
        private TextBox[,] grid;
        private Sudoku suduko;

        public SudukoGUI()
        {
            suduko = new Sudoku();
            InitializeComponent();
            LoadBoard(suduko.Board);
        }

        public void LoadBoard(int[,] puzzle)
        {
            SudukoGrid.Controls.Clear();
            this.grid = new TextBox[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Cell cell = new Cell(i, j)
                    {
                        BorderStyle = BorderStyle.FixedSingle,
                        TextAlign = HorizontalAlignment.Center,
                        Font = new Font(SystemFonts.DefaultFont.FontFamily, 20),
                        Size = new Size(40, 40),
                        Location = new Point(j * 40, i * 40),
                        MaxLength = 1,
                        Multiline = true
                    };
                    if (((i / 3) + (j / 3)) % 2 == 0)
                    {
                        cell.BackColor = Color.LightGray;
                    }
                    if (puzzle[i, j] != 0)
                    {
                        cell.Text = puzzle[i, j].ToString();
                        cell.Enabled = false;
                        cell.ForeColor = Color.DarkGray;
                    } 

                    SudukoGrid.Controls.Add(cell);
                    this.grid[i, j] = cell;

                }
            }           
        }


        private void SolveButton_Click(object sender, EventArgs e)
        {
            int[,] enteredPuzzle = new int[9, 9];
            
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (!grid[i, j].Text.Equals(""))
                    {
                        enteredPuzzle[i, j] = int.Parse(grid[i, j].Text);
                    } else
                    {
                        enteredPuzzle[i, j] = 0;
                    }
                }
            }
            Sudoku suduko = new Sudoku(enteredPuzzle);
            suduko.Solve();
            LoadBoard(suduko.SolvedBoard);

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            LoadBoard(suduko.Board);
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            Sudoku suduko = new Sudoku();
            suduko.GeneratePuzzle(40);
            LoadBoard(suduko.Board);
        }
    }
}
