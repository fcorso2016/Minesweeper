using System.Collections;
using MinesweeperProject.Architecture.DynamicLinkage;

namespace MinesweeperProject.Architecture.Filter {
    public class SizeChecker : Criteria {
        
        public SizeChecker(char[,] board, Difficulty difficulty) : base(board, difficulty) {
        }

        public SizeChecker(ICriteria criteria) : base(criteria) {
        }

        public override char[,] Verify() {
            int correctSize = Board.Length;
            switch (GetDifficulty()) {
                case Difficulty.Beginner:
                    correctSize = 8;
                    break;
                case Difficulty.Intermediate:
                    correctSize = 16;
                    break;
                case Difficulty.Expert:
                    correctSize = 24;
                    break;
            }

            if (Board.Length != correctSize) {
                char[,] newBoard = new char[correctSize, correctSize];
                for (int i = 0; i < correctSize; i++) {
                    for (int j = 0; j < correctSize; j++) {
                        if (Board.Length > i) {
                            newBoard[i, j] = Board[i, j];
                        } else {
                            newBoard[i, j] = '0';
                        }
                    }
                }

                Board = newBoard;
            }

            return Board;
        }
    }
}