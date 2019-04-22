namespace MinesweeperProject.Architecture.Factory {
    public interface IGeneratorFactory {

        IGenerator CreateGenerator(string name);

    }
}