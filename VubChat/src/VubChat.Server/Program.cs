namespace VubChat.Server;

internal static class Program
{
    /// <summary>
    /// Glavna ulazna točka aplikacije.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new GlavnaForma());
    }
}
