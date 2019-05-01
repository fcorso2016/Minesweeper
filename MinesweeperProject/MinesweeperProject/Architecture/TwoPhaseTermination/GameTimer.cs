using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace MinesweeperProject.Architecture.TwoPhaseTermination {
    public class GameTimer {

        private Thread _timerThread;
        private TextBox TimerField;
        private DateTime _startTime;
        private bool _timerRunning;

        public GameTimer(TextBox timerField) {
            TimerField = timerField;
            _timerThread = new Thread(Tick);
            _timerRunning = false;
        }

        public void Start() {
            _timerRunning = true;
            _startTime = DateTime.Now;
            _timerThread.Start();
        }

        private void Tick() {
            while (_timerRunning) {
                lock (TimerField) {
                    int seconds = (int) Math.Floor((DateTime.Now -_startTime).TotalSeconds);
                    TimerField.Text = seconds.ToString();
                }
                Thread.Sleep(1000);
            }

        }

        public void Interrupt() {
            _timerRunning = false;
        }
        
    }
}