using Gunz.Lobby.Views.Interfaces;

namespace Gunz.Lobby.Views.Container
{
    public interface IContainerView
    {
        void SetContent<TView>()
            where TView : IView;
    }
}
