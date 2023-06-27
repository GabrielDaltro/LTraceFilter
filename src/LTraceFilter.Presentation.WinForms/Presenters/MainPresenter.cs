using LTraceFilter.Presentation.WinForms.Views;

namespace LTraceFilter.Presentation.WinForms.Presenters
{
    internal class MainPresenter
    {
        private IMainView? mainView;

        public IMainView? MainView { set => mainView = value; }

        public void MainFormLoadedCallback()
        {
            mainView?.OpenSignalFilteringView();
        }
    }
}
