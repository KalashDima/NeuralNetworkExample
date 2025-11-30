using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using NeuralNetworkExample;
using Newtonsoft.Json;

namespace NeuralNetworkWinForms
{
    public class DatabaseServiceEF : IDisposable
    {
        private readonly NeuralNetworkDBSQL _context;
        private readonly Action<string> _logAction;

        public DatabaseServiceEF(string connectionString = null, Action<string> logAction = null)
        {
            _context = new NeuralNetworkDBSQL();
            _logAction = logAction;
        }

        private void Log(string message)
        {
            _logAction?.Invoke($"БАЗА ДАННЫХ: {message}");
        }

        public async Task SaveTrainingData(global::NeuralNetworkExample.TrainingData data)
        {
            try
            {
                var trainingData = new TrainingData
                {
                    Input = JsonConvert.SerializeObject(data.Data[0].Input),
                    ExpectedOutput = JsonConvert.SerializeObject(data.Data[0].ExpectedOutput),
                    CreatedDate = DateTime.Now
                };

                _context.TrainingData.Add(trainingData);
                await _context.SaveChangesAsync();
                Log($"Тренировочные данные сохранены (ID: {trainingData.Id})");
            }
            catch (Exception ex)
            {
                Log($"Ошибка сохранения тренировочных данных: {ex.Message}");
                throw;
            }
        }

        public async Task<List<TrainingItem>> GetTrainingData()
        {
            var trainingData = new List<TrainingItem>();

            var dataFromDb = await _context.TrainingData.ToListAsync();

            foreach (var item in dataFromDb)
            {
                try
                {
                    var input = JsonConvert.DeserializeObject<double[]>(item.Input);
                    var output = JsonConvert.DeserializeObject<double[]>(item.ExpectedOutput);

                    trainingData.Add(new TrainingItem { Input = input, ExpectedOutput = output });
                }
                catch (Exception ex)
                {
                    Log($"Ошибка десериализации данных ID {item.Id}: {ex.Message}");
                }
            }

            Log($"Загружено {trainingData.Count} записей тренировочных данных");
            return trainingData;
        }

        public async Task SaveModel(NeuralNetworkModel model)
        {
            try
            {
                _context.NeuralNetworkModels.Add(model);
                await _context.SaveChangesAsync();
                Log($"Модель '{model.Name}' сохранена (ID: {model.Id})");
            }
            catch (Exception ex)
            {
                Log($"Ошибка сохранения модели: {ex.Message}");
                throw;
            }
        }

        public async Task SaveLayerData(LayerData layerData)
        {
            try
            {
                _context.LayerData.Add(layerData);
                await _context.SaveChangesAsync();
                Log($"Слой {layerData.LayerIndex} сохранен");
            }
            catch (Exception ex)
            {
                Log($"Ошибка сохранения слоя: {ex.Message}");
                throw;
            }
        }

        public async Task<NeuralNetworkModel> GetModelByName(string name)
        {
            var model = await _context.NeuralNetworkModels
                                    .Include(m => m.Layers)
                                    .FirstOrDefaultAsync(m => m.Name == name);

            if (model != null)
                Log($"Модель '{name}' найдена (ID: {model.Id})");
            else
                Log($"Модель '{name}' не найдена");

            return model;
        }

        public async Task<List<LayerData>> GetLayersForModel(int modelId)
        {
            var layers = await _context.LayerData
                                    .Where(ld => ld.NeuralNetworkModelId == modelId)
                                    .OrderBy(ld => ld.LayerIndex)
                                    .ToListAsync();

            Log($"Загружено {layers.Count} слоев для модели ID: {modelId}");
            return layers;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}