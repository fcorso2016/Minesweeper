using System;
using System.Windows.Forms.VisualStyles;

namespace MinesweeperProject.Structure {
    public class Mine : Square {
        
        public Mine(int x, int y) : base(x, y) {
        }

        public void Explode() {
            // Play a sound and start the threads
            SendMessage("BOOM");
        }

        protected override void Open() {
            base.Open();
            Explode();
        }

        protected override void Mark() {
            throw new System.NotImplementedException();
        }
        
    }
}