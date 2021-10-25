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
          
            int[,] puzzle =   {{1,0,0,0,0,0,0,0,0},
                               {0,0,0,0,0,0,0,0,0},
                               {0,0,0,0,0,0,0,0,0},
                               {0,0,0,0,0,0,0,0,0},
                               {0,0,0,0,0,1,0,0,0},
                               {0,0,1,0,0,0,0,0,0},
                               {0,0,0,0,0,0,0,0,0},
                               {0,0,0,0,0,0,0,0,0}, 
                               {0,0,0,0,0,0,0,0,0}};

            Sudoku sudoku = new Sudoku(puzzle);

            sudoku.PrintBoard();

            int[] arr = {5 , 2};
            Console.WriteLine(sudoku.IsValid(1, arr));
            
            Console.ReadLine();
        }
    }
}
