namespace MinesweeperProject.Architecture.Factory {
    public interface IGenerator {
        char[,] GenerateBoard(int size, int mines);
    }
}