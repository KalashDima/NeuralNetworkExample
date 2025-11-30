using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeuralNetworkExample;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NeuralNetworkWinForms
{
    public partial class Form1 : Form
    {
        private NeuralNetwork _neuralNetwork;
        private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=NeuralNetworkDB;Integrated Security=true;";

        public Form1()
        {
            InitializeComponent();

            if (DesignMode) return;

            InitializeNetwork();
            UpdateStatus("Нейросеть инициализирована. Готова к работе.");
        }

        private void InitializeNetwork()
        {
            _neuralNetwork = new NeuralNetwork(_connectionString, LogMessage);
        }

        private void UpdateStatus(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(UpdateStatus), message);
                return;
            }

            lblStatus.Text = $"Статус: {message}";
            statusStrip1.Refresh();
        }

        private void LogMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(LogMessage), message);
                return;
            }

            txtLog.AppendText($"{DateTime.Now:HH:mm:ss} - {message}\r\n");
            txtLog.ScrollToCaret();
        }

        private async void btnTrainOnline_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDataUrl.Text))
            {
                MessageBox.Show("Введите URL для загрузки данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnTrainOnline.Enabled = false;
            progressBar1.Style = ProgressBarStyle.Marquee;

            try
            {
                UpdateStatus("Загрузка данных из интернета...");
                LogMessage($"Начало загрузки данных из: {txtDataUrl.Text}");

                await _neuralNetwork.TrainFromOnlineData(txtDataUrl.Text);

                UpdateStatus("Обучение завершено");
                LogMessage("Обучение нейросети успешно завершено");
            }
            catch (Exception ex)
            {
                UpdateStatus("Ошибка при обучении");
                LogMessage($"Ошибка: {ex.Message}");
                MessageBox.Show($"Ошибка при обучении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnTrainOnline.Enabled = true;
                progressBar1.Style = ProgressBarStyle.Continuous;
            }
        }

        private void btnPredict_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInputData.Text))
            {
                MessageBox.Show("Введите входные данные для предсказания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                UpdateStatus("Выполнение предсказания...");

                var input = ParseInputData(txtInputData.Text);
                LogMessage($"Входные данные: {input.Length} значений");

                var prediction = _neuralNetwork.Predict(input);

                txtResult.Text = string.Join(", ", prediction.Select(p => p.ToString("F4")));
                DisplayPredictionResults(prediction);

                UpdateStatus("Предсказание завершено");
                LogMessage($"Предсказание выполнено. Получено {prediction.Length} выходов");
            }
            catch (Exception ex)
            {
                UpdateStatus("Ошибка при предсказании");
                LogMessage($"Ошибка предсказания: {ex.Message}");
                MessageBox.Show($"Ошибка при предсказании: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double[] ParseInputData(string inputText)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(inputText))
                    throw new ArgumentException("Входные данные пусты");

                string normalizedText = inputText.Replace(',', '.');

                var numbers = normalizedText.Split(',')
                    .Select(x => x.Trim())
                    .Where(x => !string.IsNullOrEmpty(x))
                    .Select(x => double.Parse(x, System.Globalization.CultureInfo.InvariantCulture))
                    .ToArray();

                if (numbers.Length == 0)
                    throw new ArgumentException("Не найдено чисел для обработки");

                LogMessage($"Успешно распознано {numbers.Length} чисел");
                return numbers;
            }
            catch (FormatException)
            {
                throw new FormatException("Неверный формат чисел. Используйте: 0.1, 0.2, 0.3 или 0,1, 0,2, 0,3");
            }
        }

        private void DisplayPredictionResults(double[] prediction)
        {
            try
            {
                formsPlot1.Reset();

                if (prediction != null && prediction.Length > 0)
                {
                    double[] xValues = Enumerable.Range(0, prediction.Length)
                                               .Select(i => (double)i)
                                               .ToArray();

                    var scatter = formsPlot1.Plot.Add.Scatter(xValues, prediction);
                    scatter.Color = ScottPlot.Colors.SteelBlue;
                    scatter.LineWidth = 2;
                    scatter.MarkerSize = 5;

                    formsPlot1.Plot.XLabel("Выходы");
                    formsPlot1.Plot.YLabel("Значения");
                    formsPlot1.Plot.Title($"Предсказание ({prediction.Length} значений)");
                    formsPlot1.Plot.Grid.IsVisible = true;
                }

                formsPlot1.Refresh();
            }
            catch (Exception ex)
            {
                LogMessage($"Ошибка отображения графика: {ex.Message}");
            }
        }

        private async void btnLoadFromApi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtApiUrl.Text))
            {
                MessageBox.Show("Введите URL API", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnLoadFromApi.Enabled = false;

            try
            {
                UpdateStatus("Загрузка данных из API...");
                LogMessage($"Запрос к API: {txtApiUrl.Text}");

                var data = await _neuralNetwork.GetDataFromApi<object>(txtApiUrl.Text);
                txtApiResponse.Text = Newtonsoft.Json.JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);

                UpdateStatus("Данные загружены");
                LogMessage("Данные успешно загружены из API");
            }
            catch (Exception ex)
            {
                UpdateStatus("Ошибка загрузки данных");
                LogMessage($"Ошибка загрузки из API: {ex.Message}");
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLoadFromApi.Enabled = true;
            }
        }

        private async void btnSaveModel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtModelName.Text))
            {
                MessageBox.Show("Введите название модели", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                UpdateStatus("Сохранение модели...");
                await _neuralNetwork.SaveModelToDatabase(txtModelName.Text);
                UpdateStatus("Модель сохранена");
                MessageBox.Show("Модель успешно сохранена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                UpdateStatus("Ошибка сохранения");
                LogMessage($"Ошибка сохранения модели: {ex.Message}");
                MessageBox.Show($"Ошибка при сохранении модели: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
            LogMessage("Лог очищен");
        }

        private void btnGenerateTestData_Click(object sender, EventArgs e)
        {
            var random = new Random();
            var testData = Enumerable.Range(0, 10)
                .Select(_ => random.NextDouble().ToString("F4", System.Globalization.CultureInfo.InvariantCulture))
                .ToArray();

            txtInputData.Text = string.Join(", ", testData);
            LogMessage("Сгенерированы тестовые данные");
        }

        private void btnCreateTestModel_Click(object sender, EventArgs e)
        {
            try
            {
                _neuralNetwork.CreateSimpleTestModel();
                LogMessage("Тестовая модель создана успешно");
                MessageBox.Show("Тестовая модель создана!\nАрхитектура: 10 входов → 5 нейронов → 3 выхода",
                               "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                LogMessage($"Ошибка создания тестовой модели: {ex.Message}");
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnLoadModel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtModelName.Text))
            {
                MessageBox.Show("Введите название модели для загрузки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                UpdateStatus("Загрузка модели...");
                await _neuralNetwork.LoadModelFromDatabase(txtModelName.Text);
                UpdateStatus("Модель загружена");
                MessageBox.Show("Модель успешно загружена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                UpdateStatus("Ошибка загрузки");
                LogMessage($"Ошибка загрузки модели: {ex.Message}");
                MessageBox.Show($"Ошибка при загрузке модели: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}