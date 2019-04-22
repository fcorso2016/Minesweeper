namespace MinesweeperProject.Architecture.Composite {
    public class NumberSquare : NormalSquare {

        private int _value;

        public NumberSquare(int x, int y, int value) : base(x, y) {
            _value = value;
        }

        protected override void RenderConents() {
            throw new System.NotImplementedException();
        }
        
    }
}