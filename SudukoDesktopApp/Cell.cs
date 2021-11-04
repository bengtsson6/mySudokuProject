using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudukoDesktopApp
{
    class Cell : TextBox
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Cell(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
