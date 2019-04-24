using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;
using MinesweeperProject.Structure;

namespace MinesweeperProject.Architecture.DynamicLinkage {
    public class Board : IBoard {
        private static readonly Color[] textColors = {
            Color.Black, Color.Blue, Color.Green, Color.Red, Color.Purple, Color.Black, Color.Maroon, Color.Gray,
            Color.Turquoise
        };

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

        public Square GetSquare(int x, int y) {
            return _squares[x, y];
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
            
            Graphics bg = Graphics.FromImage(_background);
            bg.FillRectangle(SystemBrushes.Control, new Rectangle(panel.Left, panel.Top, panel.Width, panel.Height));
        }

        public void RefreshContents() {
            _foreground = (Bitmap) _background.Clone();

            Graphics g = _panel.CreateGraphics();
            Graphics fg = Graphics.FromImage(_foreground);
            fg.FillRectangle(SystemBrushes.Control, new Rectangle(_panel.Left, _panel.Top, _panel.Width, _panel.Height));
            foreach (Square sq in _squares) {
                if (sq.IsOpen) {
                    if (sq.GetType() == typeof(NumberSquare)) {
                        int value = ((NumberSquare) sq).Value;
                        PointF textPos = new PointF(30 * sq.X + _panel.Left + 5, 30 * sq.Y + _panel.Top + 5);
                        fg.DrawString(value.ToString(),
                            new Font("Tahoma", 12),
                            new SolidBrush(textColors[value]), 
                            textPos);
                    } else if (sq.GetType() == typeof(Mine)) {
                        //Image img = Image.FromFile("../mine.png");
                        fg.FillRectangle(Brushes.Red, new Rectangle(30 * sq.X + _panel.Left, 30 * sq.Y + _panel.Top, 30, 30));
                        
                        
                    }
                }
            }
            
            g.DrawImage(_foreground, new Rectangle(new Point(0, 0), _panel.Size));
            _background = _foreground;
        }

        public void TriggerExplosions(Mine mine) {
            Mine closest = FindClosestMine(mine);

            if (closest != null) {
                _scheduler.Start(closest);
            }
        }

        private Mine FindClosestMine(Mine mine) {
            Queue<Square> squares = new Queue<Square>();
            IList<Square> visited = new List<Square>();
            squares.Enqueue(mine);
            visited.Add(mine);
            while (squares.Count > 0) {
                Square s = squares.Dequeue();
                if (s.GetType() == typeof(Mine)) {
                    return (Mine) s;
                }

                foreach (Square adj in GetAdjacentSquares(s)) {
                    if (!visited.Contains(adj)) {
                        visited.Add(adj);
                        squares.Enqueue(adj);
                    }
                }
            }

            return null;
        }

        private IList<Square> GetAdjacentSquares(Square s) {
            int size = (int) Math.Sqrt(_squares.Length);
            
            IList<Square> squares = new List<Square>();
            if (s.X > 0) squares.Add(_squares[s.X - 1, s.Y]);
            if (s.X < size - 1) squares.Add(_squares[s.X + 1, s.Y]);
            if (s.Y > 0) squares.Add(_squares[s.X, s.Y - 1]);
            if (s.X < size - 1) squares.Add(_squares[s.X, s.Y + 1]);

            return squares;
        }

        public void NextExplosion() {
            _scheduler.Done();
        }

        public void AddSquare(Square sq) {
            _squares[sq.X, sq.Y] = sq;
        }
    }
}