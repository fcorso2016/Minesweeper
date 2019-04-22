namespace MinesweeperProject.Structure {
    public class NumberSquare : NormalSquare {

        private int _value;

        public NumberSquare(int x, int y, int value) : base(x, y) {
            _value = value;
            Button.Text = _value.ToString();
        }

        protected override void RenderConents() {
            // Draw a thing
        }
        
    }
}