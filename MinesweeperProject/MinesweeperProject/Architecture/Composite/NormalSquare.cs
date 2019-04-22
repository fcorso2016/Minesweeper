namespace MinesweeperProject.Architecture.Composite {
    public abstract class NormalSquare : Square {
        
        protected NormalSquare(int x, int y) : base(x, y) {
        }

        public override void Open() {
            throw new System.NotImplementedException();
        }

        public override void Mark() {
           throw new System.NotImplementedException(); 
        }

    }
}