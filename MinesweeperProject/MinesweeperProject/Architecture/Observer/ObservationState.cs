using System;
using System.Collections.Generic;

namespace MinesweeperProject.Architecture.Observer {
    public class ObservationState : IDisposable {

        private IObserver<Payload> _observer;
        private IList<IObserver<Payload>> _observers;

        public ObservationState(IList<IObserver<Payload>> observers, IObserver<Payload> observer) {
            _observers = observers;
            _observer = observer;
        }
        
        public void Dispose() {
            if (_observer != null && _observers.Contains(_observer)){
                _observers.Remove(_observer);
            }
        }
        
    }
}