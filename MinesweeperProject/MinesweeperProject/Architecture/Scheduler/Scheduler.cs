using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting.Channels;
using System.Threading;
using MinesweeperProject.Structure;

namespace MinesweeperProject.Architecture.Scheduler {
    public class Scheduler {

        private Thread _runningThread;
        private IList<Thread> _waitingThreads;
        private IList<Mine> _waitingMines;

        public Scheduler() {
            _waitingThreads = new List<Thread>();
            _waitingMines = new List<Mine>();
        }

        public void Start(Mine adjacentMine) {
            Thread thisThread = Thread.CurrentThread;

            lock (this) {
                if (_runningThread == null) {
                    _runningThread = thisThread;
                    return;
                }

                _waitingThreads.Add(thisThread);
                if (!_waitingMines.Contains(adjacentMine)) {
                    _waitingMines.Add(adjacentMine);
                }
            }

            lock (thisThread) {
                while (thisThread != _runningThread) {
                    Monitor.Wait(thisThread);
                }
            }

            lock (this) {
                int i = _waitingThreads.IndexOf(thisThread);
                _waitingThreads.RemoveAt(i);
            }
        }
        

        public void Done() {
            if (_runningThread != Thread.CurrentThread) {
                throw new InvalidOperationException("Wrong Thread!");
            }

            int waitCount = _waitingThreads.Count;
            if (waitCount <= 0) {
                _runningThread = null;
            } else {
                _runningThread = _waitingThreads[0];
            }
            
            foreach (Mine mine in _waitingMines) {
                mine.ProcessOpen();
            }

            lock (_runningThread) {
                Monitor.PulseAll(_runningThread);
            }
        }

    }
}