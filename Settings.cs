namespace GuessTheNumber2;

public class Settings       //class having setting related objects
{
    public static Language CurrentLanguage = new Polish();
    public static void Show()   //
    {
        Gui.PrintText(Settings.CurrentLanguage.Get(LanguageKey.SettingsShow));   //prints out settings gui
        int choice = Gui.ReadInt(0,4);
        
        
        switch (choice) //switch reading what setting option you chose
        {
            case 1:
                ChangeLanguage();
                break;
            case 2:
                ChangeLimited();
                break;
            case 3:
                ClearLeaderboard();
                break;
            case 4:
                return;
        }
    }

    public static void ChangeLanguage()     //method to change language
        {
            Gui.PrintText(Settings.CurrentLanguage.Get(LanguageKey.SelLang));
            int languageChoice = Gui.ReadInt(0,3);
            
            switch(languageChoice){
                case 1:
                    Settings.CurrentLanguage = new English();
                    break;
                case 2:
                    Settings.CurrentLanguage = new Polish();
                    break;
                case 3:
                    break;
            
        }
    }

        public static int limitChoice = 1;
    public static void ChangeLimited()  //method for setting that changes if it prompts the limited attempts prompt
    {
        Gui.PrintText(Settings.CurrentLanguage.Get(LanguageKey.SelLimit));
        limitChoice = Gui.ReadInt(0, 3);
    }

    public static void ClearLeaderboard()   //method clearing leaderboard and confirming it
    {
        Gui.PrintText(Settings.CurrentLanguage.Get(LanguageKey.ClearQ));

        int confirm =  Gui.ReadInt(1,2);
        

        if(confirm == 1)
        {
            Leaderboard.ClearScores();
            Gui.PrintText("Leaderboard cleared.");
        }
        else
        {
            Gui.PrintText("Operation cancelled.");
        }
    }
}