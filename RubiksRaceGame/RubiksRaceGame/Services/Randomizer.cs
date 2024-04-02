using Discrete.Random.Matrix.Generator.Adapter;
using Discrete.Random.Matrix.Generator.Utilities;

namespace RubiksRaceGame.Services
{
    internal class Randomizer
    {
        public async Task Execute()
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
                if (i == 1 || i == 2)
                    continue;
                masses[i] = (double)(rest / (double)amountOfColors);
            }

            var provider = ServiceProvider.GetProvider();
            var allAdaptees = provider.GetRegisterAdaptersName();

            foreach (var adapteeName in allAdaptees)
            {
                //when
                var fromCategorical = await provider.ExecuteCategoricalByNameAsync(adapteeName, lower, upper, rowsAmount, columnsAmount, masses, isStrict);
                var fromUniform = await provider.ExecuteUniformByNameAsync(adapteeName, lower, upper, rowsAmount, columnsAmount, isStrict);

                //then
                // Categorical
                var array = fromCategorical.Item4.ToMatrixString(rowsAmount, columnsAmount);
                var points = fromCategorical.Item4.ToSpecialWithColor(rowsAmount, columnsAmount);
                var name = fromCategorical.Item3;
                var mean = fromCategorical.Item1;
                var median = fromCategorical.Item2;

                // RESULTS ABOVE

                // Uniform
                var array2 = fromUniform.Item4.ToMatrixString(rowsAmount, columnsAmount);
                var points2 = fromUniform.Item4.ToSpecialWithColor(rowsAmount, columnsAmount);
                var name2 = fromUniform.Item3;
                var mean2 = fromUniform.Item1;
                var median2 = fromUniform.Item2;

               // RESULTS ABOVE
            }
        }
    }
}
