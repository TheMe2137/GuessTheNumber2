namespace GuessTheNumber2;

public class Settings       //class having setting related objects
{
    public static Language CurrentLanguage = new Polish();
    public static void Show()   //
    {
        Gui.PrintText(Settings.CurrentLanguage.Get("settings_show"));   //prints out settings gui
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 4)
        {
            Console.WriteLine(Settings.CurrentLanguage.Get("invalid_selection"));
        }

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
            Gui.PrintText(Settings.CurrentLanguage.Get("sellang"));
            int languageChoice;
            while (!int.TryParse(Console.ReadLine(), out languageChoice) || languageChoice < 0 || languageChoice > 3)   //validate
            {
                Console.WriteLine(Settings.CurrentLanguage.Get("invalid_selection"));
            }
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
        Gui.PrintText(Settings.CurrentLanguage.Get("selllimit"));
        while (!int.TryParse(Console.ReadLine(), out limitChoice) || limitChoice < 0 || limitChoice > 3)
        {
            Console.WriteLine(Settings.CurrentLanguage.Get("invalid_selection"));
        }
    }

    public static void ClearLeaderboard()   //method clearing leaderboard and confirming it
    {
        Gui.PrintText(Settings.CurrentLanguage.Get("clearq"));

        int confirm;
        while(!int.TryParse(Console.ReadLine(), out confirm) || confirm < 1 || confirm > 2)
        {
            Gui.PrintText("Please enter 1 or 2.");
        }

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