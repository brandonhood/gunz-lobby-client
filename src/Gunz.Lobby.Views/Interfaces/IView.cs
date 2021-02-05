using System;
using System.Threading.Tasks;

namespace Gunz.Lobby.Views.Interfaces
{
    public interface IView : IAsyncDisposable
    {
        void RegisterHandler<TEventArgs>(Func<TEventArgs, Task> handler)
            where TEventArgs : UiEventArgsBase;
    }
}
