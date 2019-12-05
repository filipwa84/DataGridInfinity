using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridInfinityLoop.Model
{
    public class DataModel
    {
        public int District { get; set; }
        public int Grade { get; set; }
        public int Year { get; set; }
        public string Category { get; set; }
        public int NumberTested { get; set; }
        public int MeanScaleScore { get; set; }
        public int LevelOneNumber { get; set; }
        public decimal LevelOnePercent { get; set; }
        public int LevelTwoNumber { get; set; }
        public decimal LevelTwoPercent { get; set; }
        public int LevelThreeNumber { get; set; }
        public decimal LevelThreePercent { get; set; }
        public int LevelFourNumber { get; set; }
        public decimal LevelFourPercent { get; set; }
        public int LevelThreeFourNumber { get; set; }
        public decimal LevelThreeFourPercent { get; set; }

    }
}
