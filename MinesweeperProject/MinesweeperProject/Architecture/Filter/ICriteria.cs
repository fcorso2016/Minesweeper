using MinesweeperProject.Architecture.DynamicLinkage;

namespace MinesweeperProject.Architecture.Filter {
    public interface ICriteria {
        Difficulty GetDifficulty();
        char[,] Verify();
    }
}