namespace GuessTheNumber2;

public class Gui
{
    public  static int ShowMenu()   //method to print out menu using language class
    {
        int maxOption;
        Console.Clear();
        Console.WriteLine("=====================");
        Console.WriteLine(Settings.CurrentLanguage.Get(LanguageKey.Menu));
        Console.WriteLine(Settings.CurrentLanguage.Get(LanguageKey.Choice1));
        Console.WriteLine(Settings.CurrentLanguage.Get(LanguageKey.MenuPlay));
        Console.WriteLine(Settings.CurrentLanguage.Get(LanguageKey.MenuPlay2));
        if (Leaderboard.HasScores())        //when leaderboard has scores, the option unlocks
        {
            maxOption = 5;
            Console.WriteLine(Settings.CurrentLanguage.Get(LanguageKey.Leaderboard));
        }
        else
        {
            maxOption = 4;
        }
        
        Console.WriteLine(Settings.CurrentLanguage.Get(LanguageKey.Settings));
        Console.WriteLine(Settings.CurrentLanguage.Get(LanguageKey.Exit)); //omfg i have to do all ts manually cause i aint supporting clankers ### REMOVE LATER###
        Console.WriteLine("=====================");
        int menuChoice;
        while (!int.TryParse(Console.ReadLine(), out menuChoice) || menuChoice < 1 || menuChoice > maxOption+1)       //validate input
        {
            Console.WriteLine(Settings.CurrentLanguage.Get(LanguageKey.InvalidSelection));
        }
        return menuChoice;
    }

    public static string PrintText(string text)     //method to print out texts in a pretty way
    {
        Console.Clear();
        Console.WriteLine("=====================");
        Console.WriteLine(text);
        Console.WriteLine("=====================");
        return text;
    }
    
}