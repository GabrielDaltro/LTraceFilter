namespace LTraceFilter.Presentation.WinForms.Views
{
    partial class SampleRateForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SampleRateForm));
            LowCutoffHzLabel = new Label();
            SampleRateTextBox = new TextBox();
            ErrorLabel = new Label();
            OkButton = new Button();
            SuspendLayout();
            // 
            // LowCutoffHzLabel
            // 
            LowCutoffHzLabel.AutoSize = true;
            LowCutoffHzLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            LowCutoffHzLabel.ForeColor = Color.Black;
            LowCutoffHzLabel.Location = new Point(12, 18);
            LowCutoffHzLabel.Name = "LowCutoffHzLabel";
            LowCutoffHzLabel.Size = new Size(202, 21);
            LowCutoffHzLabel.TabIndex = 1;
            LowCutoffHzLabel.Text = "Taxa de Amostragem(Hz)";
            // 
            // SampleRateTextBox
            // 
            SampleRateTextBox.BorderStyle = BorderStyle.FixedSingle;
            SampleRateTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            SampleRateTextBox.Location = new Point(66, 52);
            SampleRateTextBox.Name = "SampleRateTextBox";
            SampleRateTextBox.Size = new Size(251, 25);
            SampleRateTextBox.TabIndex = 2;
            SampleRateTextBox.TextChanged += SampleRateTextBox_TextChanged;
            // 
            // ErrorLabel
            // 
            ErrorLabel.AutoSize = true;
            ErrorLabel.BackColor = SystemColors.ControlLightLight;
            ErrorLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ErrorLabel.ForeColor = Color.Red;
            ErrorLabel.Location = new Point(66, 80);
            ErrorLabel.Name = "ErrorLabel";
            ErrorLabel.Size = new Size(64, 15);
            ErrorLabel.TabIndex = 3;
            ErrorLabel.Text = "ErrorLabel";
            // 
            // OkButton
            // 
            OkButton.ForeColor = Color.Black;
            OkButton.Location = new Point(147, 97);
            OkButton.Name = "OkButton";
            OkButton.Size = new Size(88, 22);
            OkButton.TabIndex = 4;
            OkButton.Text = "Ok";
            OkButton.UseVisualStyleBackColor = true;
            OkButton.Click += OkButton_Click;
            // 
            // SampleRateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(374, 140);
            Controls.Add(OkButton);
            Controls.Add(ErrorLabel);
            Controls.Add(SampleRateTextBox);
            Controls.Add(LowCutoffHzLabel);
            ForeColor = SystemColors.ButtonHighlight;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(390, 150);
            Name = "SampleRateForm";
            Text = "Sample Rate";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LowCutoffHzLabel;
        private TextBox SampleRateTextBox;
        private Label ErrorLabel;
        private Button OkButton;
    }
}