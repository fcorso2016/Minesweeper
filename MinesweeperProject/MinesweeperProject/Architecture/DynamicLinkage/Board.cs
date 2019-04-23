using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MinesweeperProject.Structure;

namespace MinesweeperProject.Architecture.DynamicLinkage {
    public class Board : IBoard {

        private Square[,] _squares;
        private Scheduler.Scheduler _scheduler;
        private GameMode _gameMode;
        private Panel _panel;
        private Bitmap _background;
        private Bitmap _foreground;

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

        public void SetPanel(Panel panel) {
            _panel = panel;
            _background = new Bitmap(panel.Width, panel.Height);
            _foreground = new Bitmap(panel.Width, panel.Height);
        }

        public void RefreshContents() {
            _foreground = (Bitmap) _background.Clone();

            Graphics g = _panel.CreateGraphics();
            Graphics fg = Graphics.FromImage(_foreground);
            foreach (Square sq in _squares) {
                if (sq.IsOpen) {
                    if (sq.GetType() == typeof(NumberSquare)) {
                        int value = ((NumberSquare) sq).Value;
                        int x = sq.X;
                        int y = sq.Y;
                        PointF textPos = new PointF(30 * sq.X + _panel.Left + 5, 30 * sq.Y + _panel.Top + 5);
                        fg.DrawString(value.ToString(),
                            new Font("Tahoma", 12),
                            Brushes.Black,
                            textPos);
                    }
                }
            }
            
            g.DrawImage(_foreground, new Rectangle(new Point(0, 0), _panel.Size));
            _background = _foreground;
        }

        public void TriggerExplosions(Mine mine) {
            throw new NotImplementedException();
        }

        public void AddSquare(Square sq) {
            _squares[sq.X, sq.Y] = sq;
        }
    }
}