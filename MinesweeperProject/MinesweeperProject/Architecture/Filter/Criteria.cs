using MinesweeperProject.Architecture.DynamicLinkage;

namespace MinesweeperProject.Architecture.Filter {
    public abstract class Criteria : ICriteria {

        protected char[,] Board;
        private Difficulty _difficulty;

        protected Criteria(char[,] board, Difficulty difficulty) {
            _difficulty = difficulty;
            Board = board;
        }

        protected Criteria(ICriteria criteria) {
            _difficulty = criteria.GetDifficulty();
            Board = criteria.Verify();
        }

        public Difficulty GetDifficulty() {
            return _difficulty;
        }

        public abstract char[,] Verify();

    }
}