using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soduko
{
    class Program
    {
        static void Main(string[] args)
        {
          
            int[,] puzzle =   {{0,0,0,0,0,0,0,0,0},
                               {0,0,0,0,0,0,0,0,0},
                               {0,0,0,0,0,0,0,0,0},
                               {0,0,0,0,0,0,0,0,0},
                               {0,0,0,0,0,0,0,0,0},
                               {0,0,0,0,0,0,0,0,0},
                               {0,0,0,0,0,0,0,0,0},
                               {0,0,0,0,0,0,0,0,0}, 
                               {0,0,0,0,0,0,0,0,0}};

            int[,] userEnterPuzzle = new int[10,10];
            for(int i= 0; i < 9; i++)
            {
                int[] row = new int[9];
                Console.WriteLine("Enter row " + i + " of the puzzle");
                string input = Console.ReadLine();
                while (input.Length != 9)
                {
                    Console.WriteLine("The row must contain 9 numbers");
                    input = Console.ReadLine();
                }
                int index = 0;
                foreach (char c in input.ToCharArray())
                {

                    row.SetValue(int.Parse(c.ToString()), index);
                    index++;
                }
                for (int j = 0; j < row.Length; j++)
                {
                    userEnterPuzzle[i, j] = row[j];
                }
            }

            Sudoku sudoku = new Sudoku(userEnterPuzzle);

            Console.WriteLine();
            sudoku.PrintBoard();
            sudoku.Solve();
            Console.WriteLine(sudoku.NumberOfInputs);
            sudoku.PrintSolvedBoard();
        }
    }
}
