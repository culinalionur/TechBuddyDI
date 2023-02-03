namespace TechBuddyDependencyInjection
{
    public class NumGenerator2 : INumGenerator2
    {
        private readonly INumGenerator _numGenerator;
        public NumGenerator2(INumGenerator numGenerator)
        {
            _numGenerator = numGenerator;
            RandomValue = new Random().Next(1000);
        }
        public int RandomValue { get; }

        public int GetNumGeneratorRandomNumber()
        {
            return _numGenerator.RandomValue;
        }
    }
    public interface INumGenerator2
    {
        public int RandomValue { get; }
        public int GetNumGeneratorRandomNumber();
    }
}
