namespace NeuralNetworkWinForms
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnLoadModel = new System.Windows.Forms.Button();
            this.btnCreateTestModel = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnGenerateTestData = new System.Windows.Forms.Button();
            this.txtInputData = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPredict = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDataUrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTrainOnline = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtModelName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveModel = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtApiUrl = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLoadFromApi = new System.Windows.Forms.Button();
            this.txtApiResponse = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(884, 561);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnLoadModel);
            this.tabPage1.Controls.Add(this.btnCreateTestModel);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(876, 535);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Управление";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnLoadModel
            // 
            this.btnLoadModel.Location = new System.Drawing.Point(460, 33);
            this.btnLoadModel.Name = "btnLoadModel";
            this.btnLoadModel.Size = new System.Drawing.Size(130, 23);
            this.btnLoadModel.TabIndex = 5;
            this.btnLoadModel.Text = "Загрузить модель";
            this.btnLoadModel.UseVisualStyleBackColor = true;
            this.btnLoadModel.Click += new System.EventHandler(this.btnLoadModel_Click);
            // 
            // btnCreateTestModel
            // 
            this.btnCreateTestModel.Location = new System.Drawing.Point(596, 33);
            this.btnCreateTestModel.Name = "btnCreateTestModel";
            this.btnCreateTestModel.Size = new System.Drawing.Size(130, 23);
            this.btnCreateTestModel.TabIndex = 4;
            this.btnCreateTestModel.Text = "Создать тест модель";
            this.btnCreateTestModel.UseVisualStyleBackColor = true;
            this.btnCreateTestModel.Click += new System.EventHandler(this.btnCreateTestModel_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnGenerateTestData);
            this.groupBox4.Controls.Add(this.txtInputData);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(20, 250);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(836, 100);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Входные данные";
            // 
            // btnGenerateTestData
            // 
            this.btnGenerateTestData.Location = new System.Drawing.Point(730, 65);
            this.btnGenerateTestData.Name = "btnGenerateTestData";
            this.btnGenerateTestData.Size = new System.Drawing.Size(100, 23);
            this.btnGenerateTestData.TabIndex = 2;
            this.btnGenerateTestData.Text = "Тест данные";
            this.btnGenerateTestData.UseVisualStyleBackColor = true;
            this.btnGenerateTestData.Click += new System.EventHandler(this.btnGenerateTestData_Click);
            // 
            // txtInputData
            // 
            this.txtInputData.Location = new System.Drawing.Point(10, 35);
            this.txtInputData.Multiline = true;
            this.txtInputData.Name = "txtInputData";
            this.txtInputData.Size = new System.Drawing.Size(820, 24);
            this.txtInputData.TabIndex = 1;
            this.txtInputData.Text = "0.1, 0.2, 0.3, 0.4, 0.5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(227, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Входные данные (через запятую, числа):";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtResult);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.btnPredict);
            this.groupBox3.Location = new System.Drawing.Point(20, 356);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(836, 100);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Предсказание";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(10, 35);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(820, 24);
            this.txtResult.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Результат:";
            // 
            // btnPredict
            // 
            this.btnPredict.Location = new System.Drawing.Point(730, 65);
            this.btnPredict.Name = "btnPredict";
            this.btnPredict.Size = new System.Drawing.Size(100, 23);
            this.btnPredict.TabIndex = 0;
            this.btnPredict.Text = "Предсказать";
            this.btnPredict.UseVisualStyleBackColor = true;
            this.btnPredict.Click += new System.EventHandler(this.btnPredict_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDataUrl);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnTrainOnline);
            this.groupBox2.Location = new System.Drawing.Point(20, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(836, 70);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Обучение из интернета";
            // 
            // txtDataUrl
            // 
            this.txtDataUrl.Location = new System.Drawing.Point(10, 35);
            this.txtDataUrl.Name = "txtDataUrl";
            this.txtDataUrl.Size = new System.Drawing.Size(620, 20);
            this.txtDataUrl.TabIndex = 2;
            this.txtDataUrl.Text = "https://api.example.com/training-data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "URL данных для обучения:";
            // 
            // btnTrainOnline
            // 
            this.btnTrainOnline.Location = new System.Drawing.Point(640, 33);
            this.btnTrainOnline.Name = "btnTrainOnline";
            this.btnTrainOnline.Size = new System.Drawing.Size(190, 23);
            this.btnTrainOnline.TabIndex = 0;
            this.btnTrainOnline.Text = "Обучить из интернета";
            this.btnTrainOnline.UseVisualStyleBackColor = true;
            this.btnTrainOnline.Click += new System.EventHandler(this.btnTrainOnline_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtModelName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSaveModel);
            this.groupBox1.Location = new System.Drawing.Point(20, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(836, 64);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Сохранение модели";
            // 
            // txtModelName
            // 
            this.txtModelName.Location = new System.Drawing.Point(10, 35);
            this.txtModelName.Name = "txtModelName";
            this.txtModelName.Size = new System.Drawing.Size(300, 20);
            this.txtModelName.TabIndex = 2;
            this.txtModelName.Text = "MyNeuralNetworkModel";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Название модели:";
            // 
            // btnSaveModel
            // 
            this.btnSaveModel.Location = new System.Drawing.Point(320, 33);
            this.btnSaveModel.Name = "btnSaveModel";
            this.btnSaveModel.Size = new System.Drawing.Size(130, 23);
            this.btnSaveModel.TabIndex = 0;
            this.btnSaveModel.Text = "Сохранить модель";
            this.btnSaveModel.UseVisualStyleBackColor = true;
            this.btnSaveModel.Click += new System.EventHandler(this.btnSaveModel_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(876, 535);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "API Запросы";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtApiUrl);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.btnLoadFromApi);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtApiResponse);
            this.splitContainer1.Size = new System.Drawing.Size(870, 529);
            this.splitContainer1.SplitterDistance = 60;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtApiUrl
            // 
            this.txtApiUrl.Location = new System.Drawing.Point(10, 25);
            this.txtApiUrl.Name = "txtApiUrl";
            this.txtApiUrl.Size = new System.Drawing.Size(650, 20);
            this.txtApiUrl.TabIndex = 2;
            this.txtApiUrl.Text = "https://jsonplaceholder.typicode.com/posts/1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "API URL:";
            // 
            // btnLoadFromApi
            // 
            this.btnLoadFromApi.Location = new System.Drawing.Point(670, 23);
            this.btnLoadFromApi.Name = "btnLoadFromApi";
            this.btnLoadFromApi.Size = new System.Drawing.Size(190, 23);
            this.btnLoadFromApi.TabIndex = 0;
            this.btnLoadFromApi.Text = "Загрузить данные";
            this.btnLoadFromApi.UseVisualStyleBackColor = true;
            this.btnLoadFromApi.Click += new System.EventHandler(this.btnLoadFromApi_Click);
            // 
            // txtApiResponse
            // 
            this.txtApiResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtApiResponse.Location = new System.Drawing.Point(0, 0);
            this.txtApiResponse.Multiline = true;
            this.txtApiResponse.Name = "txtApiResponse";
            this.txtApiResponse.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtApiResponse.Size = new System.Drawing.Size(870, 465);
            this.txtApiResponse.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.formsPlot1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(876, 535);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Визуализация";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // formsPlot1
            // 
            this.formsPlot1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formsPlot1.Location = new System.Drawing.Point(3, 3);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(870, 529);
            this.formsPlot1.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnClearLog);
            this.tabPage4.Controls.Add(this.txtLog);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(876, 535);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Логи";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnClearLog
            // 
            this.btnClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearLog.Location = new System.Drawing.Point(795, 6);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(75, 23);
            this.btnClearLog.TabIndex = 1;
            this.btnClearLog.Text = "Очистить";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(3, 35);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(870, 497);
            this.txtLog.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 561);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(884, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 584);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(884, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(169, 17);
            this.lblStatus.Text = "Статус: Инициализация...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 606);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.Text = "Нейросеть с доступом в интернет и БД";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtModelName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveModel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDataUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTrainOnline;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPredict;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnGenerateTestData;
        private System.Windows.Forms.TextBox txtInputData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtApiUrl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLoadFromApi;
        private System.Windows.Forms.TextBox txtApiResponse;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnCreateTestModel;
        private System.Windows.Forms.Button btnLoadModel;
    }
}