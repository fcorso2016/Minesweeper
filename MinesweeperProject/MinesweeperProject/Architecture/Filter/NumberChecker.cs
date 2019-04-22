using System.Xml.Linq;
using MinesweeperProject.Architecture.DynamicLinkage;

namespace MinesweeperProject.Architecture.Filter {
    public class NumberChecker : Criteria {
        public NumberChecker(char[,] board, Difficulty difficulty) : base(board, difficulty) {
        }

        public NumberChecker(ICriteria criteria) : base(criteria) {
        }

        public override char[,] Verify() {
            for (int i = 0; i < Board.Length; i++) {
                for (int j = 0; j < Board.Length; j++) {
                    // Correct any invalid values before moving forward
                    if (Board[i, j] != 'X' || !(Board[i, j] >= '0' && Board[i, j] <= '9')) {
                        Board[i, j] = '0';
                    }
                    
                    // If the tile is a number, check for the number of mines around it
                    if (Board[i, j] != 'X') {
                        int mineCount = 0;
                        for (int x = -1; x <= 1; x++) {
                            for (int y = -1; y <= 1; y++) {
                                if (Board[i + x, j + y] == 'X') {
                                    mineCount++;
                                }
                            }
                        }

                        Board[i, j] = (char) ('0' + mineCount);
                    }
                }
            }

            return Board;
        }
    }
}