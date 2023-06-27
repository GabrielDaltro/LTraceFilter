using LTraceFilter.Presentation.WinForms.Presenters;

namespace LTraceFilter.Presentation.WinForms.Views
{
    internal partial class SignalFilteringView : UserControl
    {
        private readonly SignalFilteringPresenter presenter;
        public SignalFilteringView(SignalFilteringPresenter presenter)
        {
            this.presenter = presenter;
            InitializeComponent();
        }
    }
}