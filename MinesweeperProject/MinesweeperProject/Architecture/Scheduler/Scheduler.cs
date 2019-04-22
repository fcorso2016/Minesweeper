using System;
using System.Collections.Generic;
using System.Threading;

namespace MinesweeperProject.Architecture.Scheduler {
    public class Scheduler {

        private Thread _runningThread;
        private IList<Thread> _waitingThreads;

        public void Start() {
            throw new NotSupportedException();
        }

        public void Done() {
            throw new NotSupportedException();
        }

    }
}