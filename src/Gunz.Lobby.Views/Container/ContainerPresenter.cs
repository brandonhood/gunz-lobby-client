using Gunz.Lobby.Common.Enums;
using Gunz.Lobby.Views.Interfaces;
using Gunz.Lobby.Views.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunz.Lobby.Views.Container
{
    public class ContainerPresenter
    {
        #region Fields

        private readonly IContainerView _containerView;

        #endregion

        #region Constructor

        public ContainerPresenter(IContainerView containerView)
        {
            _containerView = containerView;
        }

        #endregion

        #region IContainerPresenter

        internal Task HandleRequestViewChangedAsync(RequestViewChangeEventArgs eventArgs)
        {
            return Task.CompletedTask;
        }

        #endregion
    }
}
