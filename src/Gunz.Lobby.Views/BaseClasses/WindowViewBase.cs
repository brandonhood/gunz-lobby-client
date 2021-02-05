using Gunz.Lobby.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace Gunz.Lobby.Views.BaseClasses
{
    public abstract class WindowViewBase : Window, IView
    {
        #region Fields

        private readonly Dictionary<Type, object> _eventHandlers;

        #endregion

        #region Constructor

        protected WindowViewBase()
        {
            _eventHandlers = new Dictionary<Type, object>();
        }

        #endregion

        #region IView

        async ValueTask IAsyncDisposable.DisposeAsync()
        {
            _eventHandlers.Clear();
            await CleanupAsync();
        }

        void IView.RegisterHandler<TEventArgs>(Func<TEventArgs, Task> handler)
        {
            _eventHandlers.Add(typeof(TEventArgs), handler);
        }

        void IView.ShowDialog()
            => _ = ShowDialog();

        #endregion

        #region Protected members

        protected virtual Task CleanupAsync()
            => Task.CompletedTask;

        protected void SignalEvent<TEventArgs>(TEventArgs eventArgs)
            where TEventArgs : UiEventArgsBase
        {
            if (!_eventHandlers.TryGetValue(typeof(TEventArgs), out var handler))
                return;

            _ = ((Func<TEventArgs, Task>)handler)(eventArgs);
        }

        #endregion
    }
}
