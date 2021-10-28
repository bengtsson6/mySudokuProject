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
            for(int i= 0; i < 10; i++)
            {
                int[] row = new int[9];
                Console.WriteLine("Enter row " + i + " of the puzzle");
                string input = Console.ReadLine();
                int index = 0;
                foreach(char c in input.ToCharArray())
                {
                    
                    row.SetValue(int.Parse(c.ToString()), index);
                    index++;
                }
                //måste tydligen sätta in ett värde i taget kanske använda List<> och sen casta till array.
                for (int j = 0; j < row.Length; j++)
                {
                    userEnterPuzzle[i, j] = row[j];
                }
            }

            Sudoku sudoku = new Sudoku(userEnterPuzzle);

            Console.WriteLine();
            sudoku.PrintBoard();
            sudoku.Solve();
            sudoku.PrintBoard();
          


        }
    }
}
