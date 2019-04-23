using System;
using System.Drawing;
using System.Net.Mime;
using System.Threading;
using System.Windows.Forms.VisualStyles;

namespace MinesweeperProject.Structure {
    public class NumberSquare : NormalSquare {

        public int Value { get; }

        public NumberSquare(int x, int y, int value) : base(x, y) {
            Value = value;
        }
        
    }
}