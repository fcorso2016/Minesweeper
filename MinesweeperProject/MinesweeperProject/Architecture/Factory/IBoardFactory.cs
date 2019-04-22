using MinesweeperProject.Architecture.Composite;

namespace MinesweeperProject.Architecture.Factory {
    public interface IBoardFactory {
        Square MakeSquare(char sq, int x, int y);
    }
}