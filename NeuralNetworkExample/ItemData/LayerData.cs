using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkExample
{
    public class LayerData
    {
        public int Id { get; set; }
        public string Weights { get; set; }
        public string Biases { get; set; }
        public int LayerIndex { get; set; }

        public int NeuralNetworkModelId { get; set; }
        public virtual NeuralNetworkModel NeuralNetworkModel { get; set; }
    }
}
