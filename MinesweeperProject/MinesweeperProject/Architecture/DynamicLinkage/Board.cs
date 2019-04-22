using System;
using System.Collections.Generic;
using MinesweeperProject.Architecture.Composite;

namespace MinesweeperProject.Architecture.DynamicLinkage {
    public class Board : IBoard {

        private IList<IBoardComponent> _components;
        private Scheduler.Scheduler _scheduler;
        private GameMode _gameMode;

        public Board(GameMode gm) {
            throw new NotSupportedException();
        }

        public void TriggerExplosions(Mine mine) {
            throw new NotSupportedException();
        }

        public void AddComponent(IBoardComponent comp) {
            throw new NotSupportedException();
        }
    }
}