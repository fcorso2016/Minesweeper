using System.Threading;
using System.Windows.Forms;
using MinesweeperProject.Architecture.TwoPhaseTermination;

namespace MinesweeperProject.Architecture.DynamicLinkage {
    public abstract class GameMode {

        private Difficulty _difficulty;
        private IBoard _board;
        protected int MineCount;
        protected int FlagCount;
        protected GameTimer GameTimer;
        public TextBox MineCountField { protected get; set; }
        public TextBox TimerField { protected get; set; }
        
        public Difficulty GetDifficulty() {
            return _difficulty;
        }

        public void SetDifficulty(Difficulty value) {
            _difficulty = value;
        }

        public IBoard GetBoard() {
            return _board;
        }

        public void SetBoard(IBoard value) {
            _board = value;
        }

        public abstract void GenerateBoard(Panel panel);

    }
}