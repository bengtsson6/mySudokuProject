using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Soduko
{
    public class Sudoku
    {
        private int[,] board;
        private int[,] solvedBoard;
        private int numberOfInputs = 0;

        //Ctor that gives an empty suduko
        public Sudoku()
        {
            int[,] board = {
                               { 0,0,0,0,0,0,0,0,0},
                               { 0,0,0,0,0,0,0,0,0},
                               { 0,0,0,0,0,0,0,0,0},
                               { 0,0,0,0,0,0,0,0,0},
                               { 0,0,0,0,0,0,0,0,0},
                               { 0,0,0,0,0,0,0,0,0},
                               { 0,0,0,0,0,0,0,0,0},
                               { 0,0,0,0,0,0,0,0,0}, 
                               { 0,0,0,0,0,0,0,0,0} 
            };
            this.board = board;
                    
        }
        //Ctor that gets a given puzzle in the form of 2d array
        public Sudoku (int[,] board)
        {
            this.board = board;
        }
        public void PrintBoard()
        {
            int[,] board = this.board;
            for(int i= 0; i < 9; i++)
            {
                if (i % 3 == 0 && i != 0)
                {
                    Console.WriteLine("--------------------");
                }
                for (int j = 0; j < 9; j++)
                {
                    if(j % 3 == 0 && j != 0)
                    {
                        Console.Write("|");
                    }
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine("");
            }
            Console.ReadLine();
        }

        public void PrintSolvedBoard()
        {
            int[,] board = this.solvedBoard;
            for (int i = 0; i < 9; i++)
            {
                if (i % 3 == 0 && i != 0)
                {
                    Console.WriteLine("--------------------");
                }
                for (int j = 0; j < 9; j++)
                {
                    if (j % 3 == 0 && j != 0)
                    {
                        Console.Write("|");
                    }
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine("");
            }
            Console.ReadLine();
        }
        public int[] UnfilldSquare()
        {
            int[,] board = this.Board;
            int[] cordinates = new int[2];
            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    if (board[i,j] == 0)
                    {
                        cordinates[0] = i;
                        cordinates[1] = j;
                        return cordinates;
                    }
                }
            }
            return null;
        }
        public bool IsValid(int value, int[] cordinate)
        {
            int[,] board = this.Board;
            int row = cordinate[0];
            int column = cordinate[1];
            
            //Test values in row
            for (int i = 0; i < 9; i++)
            {
                if(board[row, i] == value && i != column)
                {
                    return false;
                }
            }

            //Test values in column
            for (int i = 0; i < 9; i++)
            {
                if (board[i, column] == value && i != row)
                {
                    return false;
                }
            }

            //Test values i box
            int boxX;
            int boxY;
            if (column != 0)
            {
                boxX = column / 3;
            } else
            {
                boxX = 0;
            }
            if(row != 0)
            {
                boxY = row / 3;
            } else
            {
                boxY = 0;
            }
            for (int i = boxY * 3; i < (boxY * 3) + 3; i++)
            {
                for (int j = boxX * 3; j < (boxX * 3) + 3; j++)
                {
                    if (board[i, j] == value)
                    {
                        if (column != j && row != i)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        
        public bool Solve()
        {
            int[,] copyOfBoard = this.board;
            if (this.UnfilldSquare() == null)
            {
                return true;
            } else
            {
                int[] cordinate = this.UnfilldSquare();
                int row = cordinate[0];
                int col = cordinate[1];
                for (int i = 1; i < 10; i++)
                {
                    if (this.IsValid(i, cordinate))
                    {
                        board[row, col] = i;
                        numberOfInputs += + 1;
                        if (Solve())
                        {
                            this.solvedBoard = board;
                            this.board = copyOfBoard;
                            return true;
                        }
                    }
                    board[row, col] = 0;
                }
            }
            return false;
        }

        //Generates a random puzzle where the paramenter decides how many inputs that will be given
        //In the process a sulution to the puzzle is also generated
        //and stored in the "solvedPuzzle" instance variable
        public void GeneratePuzzle(int numberOfInserts)
        {
            Random random = new Random();
            int[,] testBoard;
            int[] cordinate = new int[2];
            int[][] usedCordinates = new int[numberOfInserts][];

            do
            {
                ClearPuzzle();
                testBoard = new int[9, 9];

                for (int i = 0; i < numberOfInserts; i++)
                {
                    cordinate[0] = random.Next(0, 9);
                    cordinate[1] = random.Next(0, 9);
                    int tryInput = random.Next(1, 10);
                    if (IsValid(tryInput, cordinate))
                    {
                        testBoard[cordinate[0], cordinate[1]] = tryInput;
                        board[cordinate[0], cordinate[1]] = tryInput;
                        usedCordinates.Append(cordinate);
                    }
                }
            } while (!Solve());
                this.board = testBoard;           
        }

        public void ClearPuzzle()
        {
            int[,] clearBoard = {
                               { 0,0,0,0,0,0,0,0,0},
                               { 0,0,0,0,0,0,0,0,0},
                               { 0,0,0,0,0,0,0,0,0},
                               { 0,0,0,0,0,0,0,0,0},
                               { 0,0,0,0,0,0,0,0,0},
                               { 0,0,0,0,0,0,0,0,0},
                               { 0,0,0,0,0,0,0,0,0},
                               { 0,0,0,0,0,0,0,0,0},
                               { 0,0,0,0,0,0,0,0,0}
            };
            this.board = clearBoard;
        }

        public int[,] Board { get => board; set => board = value; }
        public int NumberOfInputs { get => numberOfInputs; set => numberOfInputs = value; }
        public int[,] SolvedBoard { get => solvedBoard; set => solvedBoard = value; }
    }
}
