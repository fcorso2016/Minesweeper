namespace MinesweeperProject.Structure {
    public class Mine : Square {
        
        public Mine(int x, int y) : base(x, y) {
        }

        public void Explode() {
            throw new System.NotImplementedException();
        }

        private void TriggerExplosions() {
            throw new System.NotImplementedException();
        }
        
        public override void Open() {
            throw new System.NotImplementedException();
        }

        public override void Mark() {
            throw new System.NotImplementedException();
        }

        protected override void RenderConents() {
            throw new System.NotImplementedException();
        }
        
    }
}