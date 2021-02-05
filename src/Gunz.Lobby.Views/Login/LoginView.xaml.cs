using Gunz.Lobby.Views.BaseClasses;
using System.Windows;

namespace Gunz.Lobby.Views.Login
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : WindowViewBase, ILoginView
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SignalEvent(new LoginRequestedEventArgs(ServerAddressTextBox.Text, UsernameTextBox.Text, PasswordTextBox.Password));
        }
    }
}
