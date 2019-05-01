using System;
using System.IO;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace MinesweeperProject.Structure {
    public class Mine : Square {
        
        public bool Exploded { get; private set; }
        
        public Mine(int x, int y) : base(x, y) {
        }

        public override void ProcessOpen() {
            base.ProcessOpen();
            SendMessage("BOOM: " + X + ", " + Y);
        }

        protected override void Mark() {
            base.Mark();
            SendMessage("GOODFLAG");
        }
        
    }
}