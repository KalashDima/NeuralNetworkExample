using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using NeuralNetworkExample;
using Newtonsoft.Json;

namespace NeuralNetworkWinForms
{
    public class NeuralNetwork
    {
        private readonly HttpClient _httpClient;
        private readonly DatabaseServiceEF _dbService;
        private readonly Action<string> _logAction;
        private List<Layer> _layers;

        public NeuralNetwork(string connectionString, Action<string> logAction = null)
        {
            _httpClient = new HttpClient();
            _dbService = new DatabaseServiceEF(connectionString, logAction);
            _logAction = logAction;
            InitializeNetwork();
        }

        private void InitializeNetwork()
        {
            _layers = new List<Layer>
            {
                new Layer(10, 8),  // 10 входов, 8 нейронов
                new Layer(8, 6),   // 8 нейронов, 6 нейронов
                new Layer(6, 3)    // 6 нейронов, 3 выхода
            };

            Log("Нейросеть инициализирована: 10 → 8 → 6 → 3");
        }

        private void Log(string message)
        {
            _logAction?.Invoke($"НЕЙРОСЕТЬ: {message}");
        }

        public double[] Predict(double[] input)
        {
            if (input.Length != _layers[0].Weights.GetLength(1))
            {
                throw new ArgumentException(
                    $"Неверный размер входных данных. Ожидалось: {_layers[0].Weights.GetLength(1)}, получено: {input.Length}");
            }

            double[] current = input;

            foreach (var layer in _layers)
            {
                current = layer.Forward(current);
            }

            return current;
        }

        public async Task TrainFromOnlineData(string dataUrl)
        {
            try
            {
                Log($"Загрузка данных из: {dataUrl}");
                var response = await _httpClient.GetStringAsync(dataUrl);
                var trainingData = JsonConvert.DeserializeObject<TrainingData>(response);

                Log($"Загружено {trainingData.Data.Count} записей для обучения");
                await _dbService.SaveTrainingData(trainingData);

                await TrainOnDatabaseData();
                Log("Обучение завершено успешно");
            }
            catch (Exception ex)
            {
                Log($"Ошибка при обучении: {ex.Message}");
                throw;
            }
        }

        private async Task TrainOnDatabaseData()
        {
            var trainingData = await _dbService.GetTrainingData();
            Log($"Обучение на {trainingData.Count} записях из БД");

            // Простой цикл обучения (заглушка)
            foreach (var data in trainingData)
            {
                var prediction = Predict(data.Input);
                // Здесь должна быть реализация backpropagation
            }
        }

        public async Task<T> GetDataFromApi<T>(string apiUrl)
        {
            try
            {
                var response = await _httpClient.GetStringAsync(apiUrl);
                return JsonConvert.DeserializeObject<T>(response);
            }
            catch (Exception ex)
            {
                Log($"Ошибка при получении данных из API: {ex.Message}");
                return default(T);
            }
        }

        public async Task SaveModelToDatabase(string modelName)
        {
            try
            {
                Log($"Сохранение модели '{modelName}'");

                var model = new NeuralNetworkModel
                {
                    Name = modelName,
                    CreatedDate = DateTime.Now,
                    ModelData = JsonConvert.SerializeObject(new
                    {
                        LayersCount = _layers.Count,
                        InputSize = _layers[0].Weights.GetLength(1),
                        OutputSize = _layers[_layers.Count - 1].Weights.GetLength(0),
                        Created = DateTime.Now
                    })
                };

                await _dbService.SaveModel(model);

                for (int i = 0; i < _layers.Count; i++)
                {
                    var layer = _layers[i];
                    var layerData = new LayerData
                    {
                        NeuralNetworkModelId = model.Id,
                        LayerIndex = i,
                        Weights = JsonConvert.SerializeObject(layer.Weights),
                        Biases = JsonConvert.SerializeObject(layer.Biases)
                    };
                    await _dbService.SaveLayerData(layerData);
                }

                Log($"Модель '{modelName}' успешно сохранена с {_layers.Count} слоями");
            }
            catch (Exception ex)
            {
                Log($"Ошибка сохранения модели: {ex.Message}");
                throw;
            }
        }

        public async Task LoadModelFromDatabase(string modelName)
        {
            try
            {
                Log($"Загрузка модели '{modelName}' из БД");

                var model = await _dbService.GetModelByName(modelName) ?? throw new ArgumentException($"Модель '{modelName}' не найдена в БД");
                var layersData = await _dbService.GetLayersForModel(model.Id);

                _layers = new List<Layer>();

                foreach (var layerData in layersData.OrderBy(ld => ld.LayerIndex))
                {
                    var weights = JsonConvert.DeserializeObject<double[,]>(layerData.Weights);
                    var biases = JsonConvert.DeserializeObject<double[]>(layerData.Biases);

                    var layer = new Layer(weights.GetLength(1), weights.GetLength(0))
                    {
                        Weights = weights,
                        Biases = biases
                    };

                    _layers.Add(layer);
                    Log($"Загружен слой {layerData.LayerIndex}: {weights.GetLength(1)}→{weights.GetLength(0)}");
                }

                Log($"Модель '{modelName}' успешно загружена. Слоев: {_layers.Count}");
            }
            catch (Exception ex)
            {
                Log($"Ошибка загрузки модели: {ex.Message}");
                throw;
            }
        }

        public void CreateSimpleTestModel()
        {
            _layers = new List<Layer>
            {
                new Layer(10, 5),
                new Layer(5, 3)
            };

            var random = new Random(42);

            foreach (var layer in _layers)
            {
                for (int i = 0; i < layer.Weights.GetLength(0); i++)
                {
                    for (int j = 0; j < layer.Weights.GetLength(1); j++)
                    {
                        layer.Weights[i, j] = random.NextDouble() * 0.1;
                    }
                    layer.Biases[i] = random.NextDouble() * 0.1;
                }
            }

            Log("Создана простая тестовая модель: 10 → 5 → 3");
        }

        public int GetLayersCount()
        {
            return _layers?.Count ?? 0;
        }
    }
}