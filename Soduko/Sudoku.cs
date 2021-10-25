using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soduko
{
    class Sudoku
    {
        private int[,] board;

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

        public int[,] Board { get => board; set => board = value; }
    }
}
