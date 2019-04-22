using System;
using System.Collections.Generic;
using MinesweeperProject.Architecture.Observer;

namespace MinesweeperProject.Architecture.Composite {
    public abstract class Square : IBasicComponent {

        protected int X;
        protected int Y;
        protected bool IsOpen;
        protected bool IsFlagged;
        public IList<IObserver<Payload>> Observers { get; set; }

        protected Square(int x, int y) {
            Observers = new List<IObserver<Payload>>();
            X = x;
            Y = y;
            IsOpen = false;
            IsFlagged = false;
        }

        public abstract void Open();
        public abstract void Mark();
        protected abstract void RenderConents();

        public IDisposable Subscribe(IObserver<Payload> observer) {
            if (!Observers.Contains(observer)) {
                Observers.Add(observer);
            }
            return new ObservationState(Observers, observer);
        }

        public void SendMessage(string message) {
            foreach (IObserver<Payload> observer in Observers) {
                observer.OnNext(new Payload() { Message = message});
            }
        }

    }
}