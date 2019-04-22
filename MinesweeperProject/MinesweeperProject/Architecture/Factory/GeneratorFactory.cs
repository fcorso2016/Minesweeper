using System;

namespace MinesweeperProject.Architecture.Factory {
    public class GeneratorFactory : IGeneratorFactory {
        public IGenerator CreateGenerator(string name) {
            Type type = Type.GetType(name);
            if (type == null) return new NullGenerator();
            try {
                return (IGenerator) Activator.CreateInstance(type);
            } catch (Exception ex) {
                return new NullGenerator();
            }
        }
    }
}