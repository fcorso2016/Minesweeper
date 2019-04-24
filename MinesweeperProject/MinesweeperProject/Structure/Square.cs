using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MinesweeperProject.Architecture.DynamicLinkage;
using MinesweeperProject.Architecture.Observer;

namespace MinesweeperProject.Structure {
    public abstract class Square : IObservable<Payload> {

        public int X { get; }
        public int Y { get; }
        public bool IsOpen { get; set; }
        protected bool IsFlagged;
        public IList<IObserver<Payload>> Observers { get; set; }
        public Button Button { get; private set; }

        protected Square(int x, int y) {
            Observers = new List<IObserver<Payload>>();
            X = x;
            Y = y;
            IsOpen = false;
            IsFlagged = false;
            Button = new Button {Size = new Size(30, 30), Left = 30 * x, Top = 30 * y};
            Button.Click += OnClick;
        }

        private void OnClick(object subject, EventArgs e) {
            MouseEventArgs me = (MouseEventArgs) e;
            if (me.Button == MouseButtons.Left) {
                Open();
                SendMessage("REFRESH");
            } else if (me.Button == MouseButtons.Right) {
                if (IsFlagged) {
                    Unmark();
                } else {
                    Mark();
                }
            }
        }

        protected virtual void Open() {
            ProcessOpen();
        }

        public virtual void ProcessOpen() {
            if (!IsOpen) {
                IsOpen = true;
                Button.Dispose();
                Button = null;
            }
        }
        
        protected virtual void Mark() {
            IsFlagged = true;
        }

        private void Unmark() {
            IsFlagged = false;
        }

        public IDisposable Subscribe(IObserver<Payload> observer) {
            if (!Observers.Contains(observer)) {
                Observers.Add(observer);
            }
            return new ObservationState(Observers, observer);
        }

        protected void SendMessage(string message) {
            foreach (IObserver<Payload> observer in Observers) {
                observer.OnNext(new Payload() { Message = message});
            }
        }

    }
}