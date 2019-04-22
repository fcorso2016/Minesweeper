using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MinesweeperProject.Architecture.Observer;

namespace MinesweeperProject.Structure {
    public abstract class Square : IObservable<Payload> {

        public int X { get; }
        public int Y { get; }
        public bool IsOpen { get; set; }
        protected bool IsFlagged;
        public IList<IObserver<Payload>> Observers { get; set; }
        public Button Button { get; private set; }
        public Panel panel { get; set; }

        protected Square(int x, int y) {
            Observers = new List<IObserver<Payload>>();
            X = x;
            Y = y;
            IsOpen = false;
            IsFlagged = false;
            Button = new Button {Size = new Size(30, 30), Top = 30 * x, Left = 30 * y};
            Button.Click += new EventHandler(OnClick);
        }

        private void OnClick(object subject, EventArgs e) {
            Open();
        }

        public virtual void Open() {
            ProcessOpen();
        }

        public void ProcessOpen() {
            if (!IsOpen) {
                IsOpen = true;
                RenderConents();
                Button.Dispose();
                Button = null;
            }
        }

        protected virtual void Mark() {
            IsFlagged = true;
        }

        public void Unmark() {
            IsFlagged = false;
        }
        
        
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