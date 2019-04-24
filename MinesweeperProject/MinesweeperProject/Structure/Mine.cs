using System;
using System.IO;
using System.Media;
using System.Threading;
using System.Windows.Forms.VisualStyles;

namespace MinesweeperProject.Structure {
    public class Mine : Square {
        
        public bool Exploded { get; private set; }
        
        public Mine(int x, int y) : base(x, y) {
        }

        private void Explode() {
            Exploded = true;
            SendMessage("CASCADE: " + X + ", " + Y);
            
            // Play a sound clip
            string soundfile = "..\\boom.wav";
            SoundPlayer sound = new SoundPlayer(soundfile);
            sound.Play();
            
            Thread.Sleep(25);
            SendMessage("FINISHED");
        }

        public Thread PrepExplosion() {
            return new Thread(Explode);
        }

        public override void ProcessOpen() {
            base.ProcessOpen();
            //SendMessage("BOOM: " + X + ", " + Y);
        }

        protected override void Mark() {
            throw new System.NotImplementedException();
        }
        
    }
}