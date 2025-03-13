namespace Game.MainWindow
{
    public abstract class AbstractWindowTab : IWindowTab
    {
        private readonly IWindowTabView _view;

        public AbstractWindowTab(IWindowTabView view)
        {
            _view = view;
        }

        public void SetVisible(bool isVisible)
        {
            if (isVisible)
            {
                OnBeforeOpen();
            }
            else
            {
                OnBeforeClose();
            }

            _view.SetVisible(isVisible);
        }

        protected virtual void OnBeforeOpen() { }
        protected virtual void OnBeforeClose() { }
    }
}