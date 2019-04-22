using MinesweeperProject.Architecture.Composite;

namespace MinesweeperProject.Architecture.Factory {
    public class BoardFactory : IBoardFactory {
        public Square MakeSquare(char sq, int x, int y) {
            switch (sq) {
                case ' ':
                    return new EmptySquare(x, y);
                case 'X':
                    return new Mine(x, y);
                default:
                    NumberSquare ns = new NumberSquare(x, y, sq - '0');
                    return ns;
            }
        }
    }
}