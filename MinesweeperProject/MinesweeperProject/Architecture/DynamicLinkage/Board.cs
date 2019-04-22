using System;
using System.Collections.Generic;
using MinesweeperProject.Structure;

namespace MinesweeperProject.Architecture.DynamicLinkage {
    public class Board : IBoard {

        private Square[,] _squares;
        private Scheduler.Scheduler _scheduler;
        private GameMode _gameMode;

        public Board(GameMode gm) {
            _gameMode = gm;
            _gameMode.SetBoard(this);
        }

        public void MakeBoard(int size) {
            _squares = new Square[size, size];
        }

        public void ExpandEmpty(int x, int y, bool process) {
            int size = (int) Math.Sqrt(_squares.Length);
            if (x >= 0 && x < size && y >= 0 && y < size) {
                if (_squares[x, y].GetType().IsSubclassOf(typeof(NormalSquare)) && (!_squares[x, y].IsOpen || process)) {
                    _squares[x, y].ProcessOpen();
                    if (_squares[x, y].GetType() == typeof(EmptySquare)) {
                        ExpandEmpty(x - 1, y, false);
                        ExpandEmpty(x + 1, y, false);
                        ExpandEmpty(x, y - 1, false);
                        ExpandEmpty(x, y + 1, false);
                    }
                }
            }
        }

        public void TriggerExplosions(Mine mine) {
            throw new NotImplementedException();
        }

        public void AddSquare(Square sq) {
            _squares[sq.X, sq.Y] = sq;
        }
    }
}