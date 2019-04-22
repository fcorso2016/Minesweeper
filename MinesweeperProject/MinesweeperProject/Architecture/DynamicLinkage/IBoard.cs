using System.Xml.Linq;
using MinesweeperProject.Structure;

namespace MinesweeperProject.Architecture.DynamicLinkage {
    public interface IBoard {
        void AddSquare(Square sq);
    }
}