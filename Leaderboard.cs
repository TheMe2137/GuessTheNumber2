using System;
using System.Collections.Generic;
namespace GuessTheNumber2;
public static class Leaderboard     //class for leaderboard usage
{
    private static List<Score> scores = new List<Score>();  //encapsulated list holding a score using score contructor from score.cs

    public static void AddScore(Score score)    //method adding score
    {
        scores.Add(score);
    }

    public static void Show()   //method to print out leaderboard by difficulty
    {
        Console.Clear();
        Gui.PrintText(Settings.CurrentLanguage.Get(LanguageKey.LeaderboardShow));

        int choice;

        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)   //validating 
        {
            Console.WriteLine(Settings.CurrentLanguage.Get(LanguageKey.InvalidSelection));
        }

        switch (choice)
        {
            case 1:
                ShowByDifficulty("easy");
                break;

            case 2:
                ShowByDifficulty("medium");
                break;

            case 3:
                ShowByDifficulty("hard");
                break;

            case 4:
                return;
        }
    }
         public static string ngPlusMark = "";
    public static void ShowByDifficulty(string difficulty)      //method printing out leaderboard  for specific difficulty
    {
         int position = 1;
        Console.Clear();

        var filteredScores = scores
            .Where(s => s.Difficulty == difficulty)
            .OrderBy(s => s.Attempts)
            .ThenBy(s => s.TimeSeconds);

        Console.WriteLine(Settings.CurrentLanguage.Get(LanguageKey.LeaderStart));


        if (scores.Count == 0)      //checks if scores has any counts
        {
            Gui.PrintText(Settings.CurrentLanguage.Get(LanguageKey.NoScores)); //sisyphus type shi
        }
        else
        {
            foreach (var score in filteredScores)   //loop printing out rows from leaderboard
            {
                ngPlusMark = score.GetScoreType() == "NG+" ? " NG+" : "";  // tenary operator that writes ngl plus co pisze gdy jest ngplus albo nie jest
                Console.WriteLine($"{position}. {score.PlayerName} - {score.Attempts} {Settings.CurrentLanguage.Get(LanguageKey.Attempts)} {Settings.CurrentLanguage.Get(LanguageKey.Time)}  {score.TimeSeconds}s{ngPlusMark}");
                position++;
            }
        }


        Console.WriteLine(Settings.CurrentLanguage.Get(LanguageKey.Return));
        Console.ReadKey();
    }
    public static bool HasScores()      //method checking for scores
    {
        return scores.Count > 0;
    }

    public static void ClearScores()        //method to clear scores
    {
        if(!Leaderboard.HasScores())
        {
            Gui.PrintText("Hall of Fame is already empty.");
            return;
        }
        else
        {
            scores.Clear();
        }
    }
}