namespace MinesweeperProject.Structure {
    public class EmptySquare : NormalSquare {
        
        public EmptySquare(int x, int y) : base(x, y) {
        }
        
        public override void Open() {
            throw new System.NotImplementedException();
        }
        
        protected override void RenderConents() {
            throw new System.NotImplementedException();
        }
        
    }
}