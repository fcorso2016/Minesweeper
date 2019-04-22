using MinesweeperProject.Architecture.Composite;

namespace MinesweeperProject.Architecture.DynamicLinkage {
    public interface IBoard {
        void AddComponent(IBoardComponent comp);
    }
}