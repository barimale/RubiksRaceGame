using Discrete.Random.Matrix.Generator.Adapter;
using RubiksRaceGame.Model;

namespace RubiksRaceGame.Services
{
    internal class BoardRandomizer
    {
        public static Dictionary<int, Color> ColorMapper = new Dictionary<int, Color>{
                {0, Color.Red},
                {1, Color.Blue},
                {2, Color.Green},
                {3, Color.Yellow},
                {4, Color.Orange},
                {5, Color.Purple},
                {6, Color.Transparent},
            };

        public List<ColorWithIndex> Execute()
        {
            //given
            var rowsAmount = 5;
            var columnsAmount = 5;
            var lower = 0;
            var upper = 6;
            var isStrict = true;
            var amountOfColors = upper - lower + 1;
            double[] masses = new double[amountOfColors];

            for (int i = 0; i < masses.Length - 1; i++)
            {
                masses[i] = (double)(4D / (double)25D);
            }

            // transparent just one
            masses[6] = 1D / 25D;

            var provider = ServiceProvider.GetProvider();
            var allAdaptees = provider.GetRegisterAdaptersName();

            var adapteeName = allAdaptees.First();
            
            var fromCategorical = provider.ExecuteCategoricalByNameAsync(adapteeName, lower, upper, rowsAmount, columnsAmount, masses, isStrict).Result;

            int index = 0;
            var result = new List<ColorWithIndex>();

            foreach (var item in fromCategorical.Item4)
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
