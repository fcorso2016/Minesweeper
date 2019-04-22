using System.Windows.Forms;

namespace MinesweeperProject.Architecture.DynamicLinkage {
    public abstract class GameMode {

        private Difficulty _difficulty;
        private IBoard _board;

        public Difficulty GetDifficulty() {
            return _difficulty;
        }

        public void SetDifficulty(Difficulty value) {
            _difficulty = value;
        }

        public abstract void GenerateBoard(Panel panel);

    }
}