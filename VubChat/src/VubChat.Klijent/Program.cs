namespace VubChat.Klijent;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new GlavnaForma());
    }
}
