namespace GuessTheNumber2;

public class LevelChoice        //class that holds method to choice the difficulty
{
    public static (int maxNumber, string difficultyName) levelChoice()      //method to chose difficulty
    {
        Gui.PrintText(Settings.CurrentLanguage.Get("choice_2"));
        
        int choice = int.Parse(Console.ReadLine());
        
        switch (choice)
        {
            case 1:
                
                return (25,"easy");
            case 2:
                return (50,"medium");
            case 3:
                return (100,"hard");
            case 4:
                Console.Clear();
                return (0, "");
                
        }
        Console.Clear();
        return (0, "");
    }
}