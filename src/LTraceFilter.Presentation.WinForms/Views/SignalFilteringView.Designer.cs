namespace LTraceFilter.Presentation.WinForms.Views
{
    partial class SignalFilteringView
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            LowCutoffHzLabel = new Label();
            HighCutoffHzLabel = new Label();
            LowCutoffTextBox = new TextBox();
            HighCutoffTextBox = new TextBox();
            Plot = new ScottPlot.FormsPlot();
            SuspendLayout();
            // 
            // LowCutoffHzLabel
            // 
            LowCutoffHzLabel.AutoSize = true;
            LowCutoffHzLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            LowCutoffHzLabel.Location = new Point(69, 104);
            LowCutoffHzLabel.Name = "LowCutoffHzLabel";
            LowCutoffHzLabel.Size = new Size(193, 21);
            LowCutoffHzLabel.TabIndex = 0;
            LowCutoffHzLabel.Text = "Low pass filter cutoff Hz";
            // 
            // HighCutoffHzLabel
            // 
            HighCutoffHzLabel.AutoSize = true;
            HighCutoffHzLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            HighCutoffHzLabel.Location = new Point(69, 203);
            HighCutoffHzLabel.Name = "HighCutoffHzLabel";
            HighCutoffHzLabel.Size = new Size(199, 21);
            HighCutoffHzLabel.TabIndex = 1;
            HighCutoffHzLabel.Text = "High pass filter cutoff Hz";
            // 
            // LowCutoffTextBox
            // 
            LowCutoffTextBox.BorderStyle = BorderStyle.FixedSingle;
            LowCutoffTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            LowCutoffTextBox.Location = new Point(69, 138);
            LowCutoffTextBox.Name = "LowCutoffTextBox";
            LowCutoffTextBox.Size = new Size(145, 25);
            LowCutoffTextBox.TabIndex = 2;
            // 
            // HighCutoffTextBox
            // 
            HighCutoffTextBox.BorderStyle = BorderStyle.FixedSingle;
            HighCutoffTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            HighCutoffTextBox.Location = new Point(69, 238);
            HighCutoffTextBox.Name = "HighCutoffTextBox";
            HighCutoffTextBox.Size = new Size(145, 25);
            HighCutoffTextBox.TabIndex = 3;
            // 
            // Plot
            // 
            Plot.Location = new Point(328, 24);
            Plot.Margin = new Padding(4, 3, 4, 3);
            Plot.Name = "Plot";
            Plot.Size = new Size(402, 503);
            Plot.TabIndex = 4;
            // 
            // SignalFilteringView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(Plot);
            Controls.Add(HighCutoffTextBox);
            Controls.Add(LowCutoffTextBox);
            Controls.Add(HighCutoffHzLabel);
            Controls.Add(LowCutoffHzLabel);
            Name = "SignalFilteringView";
            Size = new Size(800, 600);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LowCutoffHzLabel;
        private Label HighCutoffHzLabel;
        private TextBox LowCutoffTextBox;
        private TextBox HighCutoffTextBox;
        private ScottPlot.FormsPlot Plot;
    }
}
