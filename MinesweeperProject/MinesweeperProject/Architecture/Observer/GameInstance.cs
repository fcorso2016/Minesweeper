using System;
using System.Windows.Forms;
using MinesweeperProject.Architecture.DynamicLinkage;
using MinesweeperProject.Architecture.Factory;
using MinesweeperProject.Structure;

namespace MinesweeperProject.Architecture.Observer {
    public class GameInstance : GameMode, IObserver<Payload> {
        
        public string Message { get; set; }

        private IGeneratorFactory _factory;

        public GameInstance(IGeneratorFactory factory) {
            _factory = factory;
        }
        
        public override void GenerateBoard(Panel panel) {
            throw new NotImplementedException();
        }

        public void OnNext(Payload value) {
            Message = value.Message;
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
    }
}