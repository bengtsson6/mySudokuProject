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
          
            int[,] puzzle =   {{6,0,0,4,1,0,9,0,0},
                               {0,2,0,0,0,0,0,0,0},
                               {0,9,3,8,6,0,0,1,0},
                               {0,0,1,0,7,0,0,0,0},
                               {7,5,0,0,0,0,0,8,4},
                               {0,0,0,0,4,0,2,0,0},
                               {0,1,0,0,8,4,3,2,0},
                               {0,0,0,0,0,0,0,9,0}, 
                               {0,0,4,0,3,1,0,0,6}};

            Sudoku sudoku = new Sudoku(puzzle);
            
            sudoku.PrintBoard();

            Console.WriteLine(DateTime.Now);
            sudoku.solve();
            Console.WriteLine(DateTime.Now);
            sudoku.PrintBoard();
            
            Console.ReadLine();
        }
    }
}
