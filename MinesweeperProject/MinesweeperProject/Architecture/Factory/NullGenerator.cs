namespace MinesweeperProject.Architecture.Factory {
    public class NullGenerator : IGenerator {
        public char[,] GenerateBoard(int size, int mines) {
            // Return a 1x1 grid and let the filters handle everything
            return new char[1, 1];
        }
    }
}