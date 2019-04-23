namespace MinesweeperProject.Structure {
    public abstract class NormalSquare : Square {

        protected NormalSquare(int x, int y) : base(x, y) {
        }

        protected override void Mark() {
            base.Mark();
            SendMessage("BADFLAG");
        }

    }
}