namespace LTraceFilter.Presentation.WinForms.Views
{
    internal partial class SampleRateForm : Form
    {
        private readonly Action<int> okClickCallback;

        public SampleRateForm(Action<int> okClickCallback)
        {
            InitializeComponent();
            this.okClickCallback = okClickCallback;
            ErrorLabel.Visible = false;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(SampleRateTextBox.Text, out int sampleRate))
            {
                ErrorLabel.Visible = true;
                ErrorLabel.Text = "digite um número inteiro inválido.";
                return;
            }
            okClickCallback?.Invoke(sampleRate);
            Close();
        }

        private void SampleRateTextBox_TextChanged(object sender, EventArgs e)
        {
            ErrorLabel.Visible = false;
        }
    }
}