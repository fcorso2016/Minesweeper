using MinesweeperProject.Architecture.Composite;

namespace MinesweeperProject.Architecture.Factory {
    public class BoardFactory : IBoardFactory {
        public Square MakeSquare(char sq, int x, int y) {
            switch (sq) {
                case '0':
                    return new EmptySquare(x, y);
                case 'X':
                    return new Mine(x, y);
                default:
                    if (sq >= '1' && sq <= '9') {
                        NumberSquare ns = new NumberSquare(x, y, sq - '0');
                        return ns;
                    }

                    // If not a number, then it doesn't know what to do with the value
                    return null;
            }
        }
    }
}