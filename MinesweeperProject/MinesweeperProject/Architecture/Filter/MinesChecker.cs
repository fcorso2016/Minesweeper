using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using MinesweeperProject.Architecture.DynamicLinkage;

namespace MinesweeperProject.Architecture.Filter {
    public class MinesChecker : Criteria {
        public MinesChecker(char[,] board, Difficulty difficulty) : base(board, difficulty) {
        }

        public MinesChecker(ICriteria criteria) : base(criteria) {
        }

        public override char[,] Verify() {
            int mines = 0;
            switch (GetDifficulty()) {
                case Difficulty.Beginner:
                    mines = 10;
                    break;
                case Difficulty.Intermediate:
                    mines = 40;
                    break;
                case Difficulty.Expert:
                    mines = 99;
                    break;
            }

            IList<Tuple<int, int>> mineLocations = new List<Tuple<int, int>>();
            for (int i = 0; i < Board.Length; i++) {
                for (int j = 0; j < Board.Length; j++) {
                    if (Board[i, j] == 'X') {
                        mineLocations.Add(new Tuple<int, int>(i, j));
                    }
                }
            }

            if (mines > mineLocations.Count) {
                // Randomly add mines until the board is full
                Random rand = new Random();
                while (mines > mineLocations.Count) {
                    int x, y;
                    do {
                        x = rand.Next() % Board.Length;
                        y = rand.Next() % Board.Length;
                    } while (Board[x, y] == 'X');

                    Board[x, y] = 'X';
                    mineLocations.Add(new Tuple<int, int>(x, y));
                }
            } else if (mines < mineLocations.Count) {
                // Remove the mines from the game randomly
                Random rand = new Random();
                while (mines < mineLocations.Count) {
                    int position = rand.Next() % mineLocations.Count;
                    int x = mineLocations[position].Item1;
                    int y = mineLocations[position].Item2;
                    Board[x, y] = '0';
                    mineLocations.RemoveAt(position);
                }
            }

            return Board;
        }
    }
}