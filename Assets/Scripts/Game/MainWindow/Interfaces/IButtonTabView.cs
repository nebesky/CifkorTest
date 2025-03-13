using System;

namespace Game.MainWindow
{
    public interface IButtonTabView
    {
        event Action<IButtonTabView> OnClick;
    }
}