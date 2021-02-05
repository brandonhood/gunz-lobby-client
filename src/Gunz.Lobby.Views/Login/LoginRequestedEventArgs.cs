namespace Gunz.Lobby.Views.Login
{
    public record LoginRequestedEventArgs(string ServerAddress, string Username, string Password)
        : UiEventArgsBase;
}
