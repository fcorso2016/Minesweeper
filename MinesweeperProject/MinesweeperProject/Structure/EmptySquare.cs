using System;

namespace MinesweeperProject.Structure {
    public class EmptySquare : NormalSquare {
        
        public EmptySquare(int x, int y) : base(x, y) {
        }

        public override void Open() {
            base.Open();
            SendMessage("EXPANDALL: " + X + ", " + Y);
        }
        
    }
}