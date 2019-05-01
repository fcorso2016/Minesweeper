using System.Windows.Forms;
using System.Xml.Linq;
using MinesweeperProject.Structure;

namespace MinesweeperProject.Architecture.DynamicLinkage {
    public interface IBoard {
        void AddSquare(Square sq);
        Square[,] GetSquares();
        void MakeBoard(int size);
        void ExpandEmpty(int x, int y, bool process);
        void SetPanel(Panel panel);
        void RefreshContents();
    }
}