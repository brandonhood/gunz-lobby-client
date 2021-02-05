using Gunz.Lobby.Common.CustomExceptions;
using Gunz.Lobby.Domain.Contracts.Security;
using Gunz.Lobby.Repositories.Security;
using System.Net;
using System.Threading.Tasks;
using System.Windows;

namespace Gunz.Lobby.Views.Login
{
    public class LoginPresenter : ILoginPresenter
    {
        #region Fields

        private readonly ILoginView _loginView;
        private readonly IApiTokenRepository _apiTokenRepository;

        #endregion

        #region Constructor

        public LoginPresenter(ILoginView loginView, IApiTokenRepository apiTokenRepository)
        {
            _loginView = loginView;
            _apiTokenRepository = apiTokenRepository;

            _loginView.RegisterHandler<LoginRequestedEventArgs>(HandleLoginRequestedAsync);
        }

        #endregion

        #region ILoginPresenter

        public void Show()
            => _loginView.ShowDialog();

        #endregion

        #region Handlers

        internal async Task HandleLoginRequestedAsync(LoginRequestedEventArgs eventArgs)
        {
            ApiTokenResponse response;

            try
            {
                response = await _apiTokenRepository.GetApiTokenAsync(eventArgs.ServerAddress, eventArgs.Username, eventArgs.Password);
            }
            catch (CustomHttpResponseException ex) when (ex.StatusCode == HttpStatusCode.Forbidden)
            {
                MessageBox.Show("Invalid credentials.");
                return;
            }
            catch
            {
                MessageBox.Show("oops");
                return;
            }

            MessageBox.Show($"Your user id is {response.AccountId} and your token is {response.AccessToken}.");
        }

        #endregion
    }
}
