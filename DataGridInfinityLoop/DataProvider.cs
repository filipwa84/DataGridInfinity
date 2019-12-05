using DataGridInfinityLoop.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridInfinityLoop
{
    public class DataProvider
    {
        private string rawData;

        public List<DataModel> DataModels { get; private set; }

        public DataProvider()
        {
            DataModels = new List<DataModel>();
        }

        public async Task ReadData(string path)
        {
            using (var reader = new StreamReader(path))
            {
                rawData = await reader.ReadToEndAsync();
                reader.Close();
            }

            ParseData();
        }

        private void ParseData()
        {
            var lines = rawData.Split("\n").ToList();

            foreach(var line in lines.GetRange(1, lines.Count-1))
            {
                var e = line.Split(',').Select(x => x.Trim()).ToList();

                if (e.Count != 16) continue;

                var model = new DataModel
                {
                    District = e[0].ToInt(),
                    Grade = e[1].ToInt(),
                    Year = e[2].ToInt(),
                    Category = e[3],
                    NumberTested = e[4].ToInt(),
                    MeanScaleScore = e[5].ToInt(),
                    LevelOneNumber = e[6].ToInt(),
                    LevelOnePercent = e[7].ToDecimal(),
                    LevelTwoNumber = e[8].ToInt(),
                    LevelTwoPercent = e[9].ToDecimal(),
                    LevelThreeNumber = e[10].ToInt(),
                    LevelThreePercent = e[11].ToDecimal(),
                    LevelFourNumber = e[12].ToInt(),
                    LevelFourPercent = e[13].ToDecimal(),
                    LevelThreeFourNumber = e[14].ToInt(),
                    LevelThreeFourPercent = e[15].ToDecimal()
                };

                DataModels.Add(model);
            }
        }

    }

    public static class Parser
    {
        public static int ToInt(this string input)
        {
            var success = int.TryParse(input, out var myint);

            return success ? myint : default(int);
        }

        public static decimal ToDecimal(this string input)
        {
            var success = decimal.TryParse(input, out var mydecimal);

            return success ? mydecimal : default(decimal);
        }
    }
}
