using LTraceFilter.Presentation.WinForms.Views;
using LTraceFilter.Presentation.WinForms.Presenters;

namespace LTraceFilter.Presentation.WinForms
{
    internal partial class MainForm : Form, IMainView
    {
        private readonly MainPresenter presenter;
        private readonly ViewFactory viewFactory;

        public MainForm(ViewFactory viewFactory, MainPresenter presenter)
        {
            this.viewFactory = viewFactory;
            this.presenter = presenter;
            presenter.MainView = this;
            InitializeComponent();
        }

        public void OpenSignalFilteringView()
        {
            var view = viewFactory.CreateSignalFilteringView();
            AddUserControlToForm(view);
        }

        private void AddUserControlToForm(UserControl userControl)
        {
            if (BasePanel.Controls.Count > 0)
                BasePanel.Controls.RemoveAt(0);

            userControl.Dock = DockStyle.Fill;
            BasePanel.Controls.Add(userControl);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            presenter.MainFormLoadedCallback();
        }
    }
}