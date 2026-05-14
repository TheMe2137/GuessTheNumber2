namespace GuessTheNumber2;

public class Gui    //class for gui
{
    public static int ShowMenu()        //method for showing main menu
    {
        int maxOption;
        Console.Clear();
        Console.WriteLine("=====================");
        Console.WriteLine(Settings.CurrentLanguage.Get(LanguageKey.Menu));
        Console.WriteLine(Settings.CurrentLanguage.Get(LanguageKey.Choice1));
        Console.WriteLine(Settings.CurrentLanguage.Get(LanguageKey.MenuPlay));
        Console.WriteLine(Settings.CurrentLanguage.Get(LanguageKey.MenuPlay2));
        if (Leaderboard.HasScores())        //whenever leaderboard has scores, turns on the last option for leaderboard
        {
            maxOption = 5;
            Console.WriteLine(Settings.CurrentLanguage.Get(LanguageKey.Leaderboard));
        }
        else
        {
            maxOption = 4;
        }

        Console.WriteLine(Settings.CurrentLanguage.Get(LanguageKey.Settings));
        Console.WriteLine(Settings.CurrentLanguage.Get(LanguageKey.Exit));
        Console.WriteLine("=====================");
        return ReadInt(1, maxOption+1);
    }

    public static string PrintText(string text)     //basic method for printing strings in prettier way
    {
        Console.Clear();
        Console.WriteLine("=====================");
        Console.WriteLine(text);
        Console.WriteLine("=====================");
        return text;
    }

    public static int ReadInt(int min, int max)     //method for validation, so the code is simplier
    {
        int result;
        while (!int.TryParse(Console.ReadLine(), out result) || result < min || result > max)
        {
            Console.WriteLine(Settings.CurrentLanguage.Get(LanguageKey.InvalidSelection));
        }
        return result;
    }
}