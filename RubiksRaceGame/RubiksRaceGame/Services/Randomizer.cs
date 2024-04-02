using Discrete.Random.Matrix.Generator.Adapter;

namespace RubiksRaceGame.Services
{
    internal class Randomizer
    {
        public static Dictionary<int, Color> ColorMapper = new Dictionary<int, Color>{
                {0, Color.Red},
                {1, Color.Blue},
                {2, Color.Green},
                {3, Color.Yellow},
                {4, Color.Orange},
                {5, Color.Purple}
            };

        public class ColorWithIndex
        {
            public int Index { get; set; }
            public int ColorCode { get; set; }
        }

        // WIP
        public List<ColorWithIndex> ExecuteForBoard()
        {
            return null;
        }

        public List<ColorWithIndex> Execute()
        {
            //given
            var rowsAmount = 3;
            var columnsAmount = 3;
            var lower = 0;
            var upper = 5;
            var isStrict = true;
            var amountOfColors = upper - lower + 1;
            double[] masses = new double[amountOfColors];

            for (int i = 0; i < masses.Length; i++)
            {
                masses[i] = (double)(1D / (double)amountOfColors);
            }

            // Match Masters
            var rest = 1D;
            for (int i = 0; i < masses.Length; i++)
            {
                masses[i] = (double)(rest / (double)amountOfColors);
            }

            var provider = ServiceProvider.GetProvider();
            var allAdaptees = provider.GetRegisterAdaptersName();

            var adapteeName = allAdaptees.First();
            //when WIP
            var fromCategorical = provider.ExecuteCategoricalByNameAsync(adapteeName, lower, upper, rowsAmount, columnsAmount, masses, isStrict).Result;

            int index = 0;
            var result = new List<ColorWithIndex>();

            foreach(var item in fromCategorical.Item4)
            {
                result.Add(new ColorWithIndex()
                {
                    Index = index,
                    ColorCode = item
                });

                index = index + 1;
            }

            return result;
        }
    }
}
