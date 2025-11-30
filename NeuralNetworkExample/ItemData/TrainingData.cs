using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkExample
{
    // Класс для таблицы TrainingData
    public class TrainingData
    {
        public int Id { get; set; }
        public string Input { get; set; }
        public string ExpectedOutput { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public List<TrainingItem> Data { get; set; } = new List<TrainingItem>();
    }
}
