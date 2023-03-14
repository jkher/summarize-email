using Spectre.Console;

class Shared
{
    public static void WritePanel(string head, string body)
    {
        var content = $"[deepskyblue1]{head}[/]\n\n{body}";
        AnsiConsole.Write(new Panel(content)
          .Border(BoxBorder.Rounded)
          .Padding(2, 1, 2, 1)
        );
        AnsiConsole.Write("");
    }

    public static void WriteHackTogetherBadge()
    {
        AnsiConsole.WriteLine("");
        AnsiConsole.Markup("[grey93 on grey46] MICROSOFT [/][grey93 on darkorange] HACK-TOGETHER [/]");
        AnsiConsole.WriteLine("");
    }

    public static void SayGoodbye()
    {
        AnsiConsole.WriteLine("");
        AnsiConsole.Markup("[greenyellow] Goodbye! [/]");
        AnsiConsole.WriteLine("");
    }
}