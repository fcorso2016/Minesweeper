using System;
using System.Collections.Generic;
using MinesweeperProject.Structure;

namespace MinesweeperProject.Architecture.DynamicLinkage {
    public class Board : IBoard {

        private Square[,] _squares;
        private Scheduler.Scheduler _scheduler;
        private GameMode _gameMode;

        public Board(GameMode gm) {
            throw new NotImplementedException();
        }

        public void TriggerExplosions(Mine mine) {
            throw new NotImplementedException();
        }

        public void AddSquare(Square sq) {
            _squares[sq.X, sq.Y] = sq;
        }
    }
}