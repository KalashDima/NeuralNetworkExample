using System;

namespace NeuralNetworkWinForms
{
    public class Layer
    {
        public double[,] Weights { get; set; }
        public double[] Biases { get; set; }

        public Layer(int inputSize, int outputSize)
        {
            Weights = new double[outputSize, inputSize];
            Biases = new double[outputSize];
            InitializeWeights();
        }

        private void InitializeWeights()
        {
            var random = new Random();
            for (int i = 0; i < Weights.GetLength(0); i++)
            {
                for (int j = 0; j < Weights.GetLength(1); j++)
                {
                    Weights[i, j] = random.NextDouble() - 0.5;
                }
                Biases[i] = random.NextDouble() - 0.5;
            }
        }

        public double[] Forward(double[] input)
        {
            var output = new double[Weights.GetLength(0)];

            for (int i = 0; i < Weights.GetLength(0); i++)
            {
                double sum = 0;
                for (int j = 0; j < Weights.GetLength(1); j++)
                {
                    sum += Weights[i, j] * input[j];
                }
                output[i] = Sigmoid(sum + Biases[i]);
            }

            return output;
        }

        private double Sigmoid(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-x));
        }
    }
}