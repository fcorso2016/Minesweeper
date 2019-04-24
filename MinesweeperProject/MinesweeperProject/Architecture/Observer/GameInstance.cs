using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using MinesweeperProject.Architecture.DynamicLinkage;
using MinesweeperProject.Architecture.Factory;
using MinesweeperProject.Architecture.Filter;
using MinesweeperProject.Structure;

namespace MinesweeperProject.Architecture.Observer {
    public class GameInstance : GameMode, IObserver<Payload> {
        
        public string Message { get; set; }
        private readonly IGeneratorFactory _factory;

        public GameInstance(IGeneratorFactory factory) {
            _factory = factory;
        }
        
        public override void GenerateBoard(Panel panel) {
            GetBoard().SetPanel(panel);
            
            IGenerator gen = _factory.CreateGenerator("NativeGenerator");
            int size = 0;
            int mines = 0;
            switch (GetDifficulty()) {
                case Difficulty.Beginner:
                    size = 8;
                    mines = 10;
                    break;
                case Difficulty.Intermediate:
                    size = 16;
                    mines = 40;
                    break;
                case Difficulty.Expert:
                    size = 24;
                    mines = 99;
                    break;
            }

            // Create and filter the board
            GetBoard().MakeBoard(size);
            char[,] board = gen.GenerateBoard(size, mines);
            ICriteria boardFilter = new SizeChecker(board, GetDifficulty());
            boardFilter = new MinesChecker(boardFilter);
            boardFilter = new NumberChecker(boardFilter);
            board = boardFilter.Verify();
            
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    Square square;
                    switch (board[i, j]) {
                        case 'X':
                            square = new Mine(i, j);
                            break;
                        case '0':
                            square = new EmptySquare(i, j);
                            break;
                        default:
                            square = new NumberSquare(i, j, board[i, j] - '0');
                            break;
                    }
                    
                    GetBoard().AddSquare(square);
                    square.Button.Top += panel.Top;
                    square.Button.Left += panel.Left;
                    panel.Controls.Add(square.Button);

                    square.Subscribe(this);
                }
            }
        }

        public void OnNext(Payload value) {
            Message = value.Message;
            ActOnMessage();
        }

        public void OnError(Exception error) {
            // Doesn't need to do anything currently
        }

        public void OnCompleted() {
            // Doesn't need to do anything currently
        }

        public IDisposable AddSquareToGame(Square square) {
            return square.Subscribe(this);
        }

        private void ActOnMessage() {
            Regex regex = new Regex("([A-Z]+)(?::\\s?((?:\\d+(?:,\\s?)?)+))?");
            if (regex.IsMatch(Message)) {
                Match match = regex.Match(Message);
                string operation = match.Groups[1].Value;
                Regex divider = new Regex(",\\s?");
                string[] args = divider.Split(match.Groups[2].Value);

                if (operation.ToUpper().Equals("EXPANDALL")) {
                    if (Int32.TryParse(args[0], out int x) && Int32.TryParse(args[1], out int y)) {
                        GetBoard().ExpandEmpty(x, y, true);
                    }
                } else if (operation.ToUpper().Equals("BOOM")) {
                    if (Int32.TryParse(args[0], out int x) && Int32.TryParse(args[1], out int y)) {
                        Mine mine = (Mine) GetBoard().GetSquare(x, y);
                        Thread explosion = mine.PrepExplosion();
                        explosion.Start();
                    }
                } else if (operation.ToUpper().Equals("CASCADE")) {
                    if (Int32.TryParse(args[0], out int x) && Int32.TryParse(args[1], out int y)) {
                        Mine mine = (Mine) GetBoard().GetSquare(x, y);
                        GetBoard().TriggerExplosions(mine);
                    }
                } else if (operation.ToUpper().Equals("DONE")) {
                    GetBoard().NextExplosion();
                } else if (operation.ToUpper().Equals("BADFLAG")) {
                    
                } else if (operation.ToUpper().Equals("GOODFLAG")) {
                    
                } else if (operation.ToUpper().Equals("REFRESH")) {
                    GetBoard().RefreshContents();
                }
            }
            
        }
        
    }
}