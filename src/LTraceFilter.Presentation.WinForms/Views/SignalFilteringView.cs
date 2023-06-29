using ScottPlot;
using ScottPlot.Plottable;
using LTraceFilter.Presentation.WinForms.Presenters;

namespace LTraceFilter.Presentation.WinForms.Views
{
    internal partial class SignalFilteringView : UserControl
    {
        private ScatterPlot? rawSignalPlot;
        private ScatterPlot? filteredSignalPlot;
        private readonly SignalFilteringPresenter presenter;

        public SignalFilteringView(SignalFilteringPresenter presenter)
        {
            this.presenter = presenter;
            InitializeComponent();
            (float? initialLowPassCutoff, float? initialHighPassCutoff) = presenter.GetInitialFilterSettings();
            Init(initialLowPassCutoff, initialHighPassCutoff);
        }

        public string GetSignalPath()
        {
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                }
            }
            return filePath;
        }

        private void Init(float? initialLowPassCutoff, float? initialHighPassCutoff)
        {
            DisableGridOfPlot();
            SetAxisLabels();
            EnablePlotLegend();
            AddRawSignal();

            LowCutoffTextBox.Text = initialLowPassCutoff.ToString();

            HighCutoffTextBox.Text = initialHighPassCutoff.ToString();

            (float[]? signal, int? sampleRate) = presenter.FilterSignal(initialLowPassCutoff, initialHighPassCutoff);
            if (signal != null && sampleRate != null)
                UpdateFilteredSignal(signal, sampleRate.Value);

            LowCutoffTextBox.TextChanged += LowOrHighCutoffTextBox_TextChanged;
            HighCutoffTextBox.TextChanged += LowOrHighCutoffTextBox_TextChanged;
        }

        private void LowOrHighCutoffTextBox_TextChanged(object? sender, EventArgs e)
        {
            int? initialLowPassCutoff;
            int? initialHighPassCutoff;

            if (string.IsNullOrEmpty(LowCutoffTextBox.Text))
            {
                initialLowPassCutoff = null;
            }
            else if (!int.TryParse(LowCutoffTextBox.Text, out int lowPassValue))
            {
                // TO DO: exibir valor inviável
                return;
            }
            else
            {
                if (lowPassValue == 0)
                {
                    // TO DO: exibir valor inviável
                    return;
                }
                initialLowPassCutoff = lowPassValue;
            }

            if (string.IsNullOrEmpty(HighCutoffTextBox.Text))
            {
                initialHighPassCutoff = null;
            }
            else if (!int.TryParse(HighCutoffTextBox.Text, out int highPassValue))
            {
                // TO DO: exibir valor inviável
                return;
            }
            else
            {
                if (highPassValue == 0)
                {
                    // TO DO: exibir valor inviável
                    return;
                }
                initialHighPassCutoff = highPassValue;
            }

            (float[]? signal, int? sampleRate) = presenter.FilterSignal(initialLowPassCutoff, initialHighPassCutoff);
            if (signal != null && sampleRate != null)
                UpdateFilteredSignal(signal, sampleRate.Value);
        }

        private void AddRawSignal()
        {
            if (rawSignalPlot != null)
            {
                Plot.Plot.Remove(rawSignalPlot);
                Plot.Refresh();
            }

            (var signal, var sampleRateHz) = presenter.GetSignal();
            if (signal == null || sampleRateHz == null)
                return;
            rawSignalPlot = PlotSignal(signal, sampleRateHz.Value, "Sísmica Original", Color.Black);
        }

        private void UpdateFilteredSignal(float[] filteredSignal, int sampleRate)
        {
            Plot.Plot.Remove(filteredSignalPlot);
            Plot.Refresh();
            filteredSignalPlot = PlotSignal(filteredSignal, sampleRate, "Sísmica Filtrada", Color.Blue);
        }

        private ScatterPlot PlotSignal(float[] signal, int sampleRateHz, string label, Color? color = null)
        {
            float samplingPeriod = 1 / ((float)sampleRateHz);
            var scatterPlot = Plot.Plot.AddScatter(ToDoubleArray(signal), GenerateTimeAxisValues(samplingPeriod, signal.Length), color, 1, 5, MarkerShape.none);
            scatterPlot.Label = label;
            Plot.Refresh();
            return scatterPlot;
        }

        private void DisableGridOfPlot()
        {
            Plot.Plot.Grid(false);
        }

        private void SetAxisLabels()
        {
            Plot.Plot.XLabel("Amplitude");
            Plot.Plot.YLabel("Tempo(ms)");
        }

        private void EnablePlotLegend()
        {
            Plot.Plot.Legend();
        }

        private double[] ToDoubleArray(float[] floatArray)
        {
            var doubleArray = new double[floatArray.Length];
            for (int i = 0; i < floatArray.Length; i++)
                doubleArray[i] = floatArray[i];
            return doubleArray;
        }

        private double[] GenerateTimeAxisValues(float samplingPeriod, int signalLenth)
        {
            double[] timeAxis = new double[signalLenth];
            for (int i = 0; i < signalLenth; i++)
            {
                timeAxis[i] = i * samplingPeriod * 1000;
            }
            return timeAxis;
        }

        private void ImportarSinalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var path = GetSignalPath();
            if (string.IsNullOrEmpty(path))
                return;

            new SampleRateForm(okClickCallback: (int sampleRate) =>
            {
                var signal = presenter.ReadNewSignalFromSourceFile(path);
                if (signal == null)
                {
                    MessageBox.Show("Erro ao carregar sinal", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                presenter.SaveImportedSignal(signal, sampleRate);
                AddRawSignal();
                (float? initialLowPassCutoff, float? initialHighPassCutoff) = presenter.GetInitialFilterSettings();
                (float[]? filteredSignal, _) = presenter.FilterSignal(initialLowPassCutoff, initialHighPassCutoff);
                if (filteredSignal != null)
                    UpdateFilteredSignal(filteredSignal, sampleRate);
            }).Show();
        }

        private void ExportarResultadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg";
            saveFileDialog1.Title = "Salvar gráfico";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "") 
            {
                Plot.Plot.SaveFig(saveFileDialog1.FileName);
            }
        }
    }
}