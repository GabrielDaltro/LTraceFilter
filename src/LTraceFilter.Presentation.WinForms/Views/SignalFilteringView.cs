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
            Init();
        }

        private void Init()
        {
            int initialLowPassCutoff = 12;
            int initialHighPassCutoff = 26;

            DisableGridOfPlot();
            SetAxisLabels();
            EnablePlotLegend();
            AddRawSignal();

            LowCutoffTextBox.Text = initialLowPassCutoff.ToString();

            HighCutoffTextBox.Text = initialHighPassCutoff.ToString();

            float[] signal = presenter.FilterSignal(initialLowPassCutoff, initialHighPassCutoff);
            UpdateFilteredSignal(signal);

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
                // exibir valor inviável
                return;
            }
            else
                initialLowPassCutoff = lowPassValue;



            if (string.IsNullOrEmpty(HighCutoffTextBox.Text))
            {
                initialHighPassCutoff = null;
            }
            else if (!int.TryParse(HighCutoffTextBox.Text, out int highPassValue))
            {
                // exibir valor inviável
                return;
            }
            else
                initialHighPassCutoff = highPassValue;

            float[] signal = presenter.FilterSignal(initialLowPassCutoff, initialHighPassCutoff);
            UpdateFilteredSignal(signal);
        }

        private void AddRawSignal()
        {
            (var signal, var sampleRateHz) = presenter.GetSignal();
            rawSignalPlot = PlotSignal(signal, sampleRateHz, "Sísmica Original", Color.Black);
        }

        private void UpdateFilteredSignal(float[] filteredSignal)
        {
            Plot.Plot.Remove(filteredSignalPlot);
            Plot.Refresh();
            // remover magic number
            filteredSignalPlot = PlotSignal(filteredSignal, 250, "Sísmica Filtrada", Color.Blue);
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
    }
}