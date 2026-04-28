

using System.Runtime.InteropServices.JavaScript;

namespace GuessTheNumber2;
public class Game   //class having game oriented objects/methods
{
    private static Random Rnd = new Random();
           private static int limitedAttempts;
            public static int readLimited;
            public static int timeSeconds;
            
    public static Score startGame(int maxNumber, string difficultyName, bool newGamePlus)      //method that contains main game thingy
    {
        if (newGamePlus)
        {
            Settings.limitChoice = 0;
        }
        



        int attempts = 1;
        string[] Phrases =      //array holding goofy phrases that switch each time u hit wrong
        {
            Settings.CurrentLanguage.Get(LanguageKey.P1),
            Settings.CurrentLanguage.Get(LanguageKey.P2),
            Settings.CurrentLanguage.Get(LanguageKey.P3),
            Settings.CurrentLanguage.Get(LanguageKey.P4),
            Settings.CurrentLanguage.Get(LanguageKey.P5)
        };
        
        
        int number = Rnd.Next(1, maxNumber+1);      //int holding random number
        int secretNumber =  Rnd.Next(1, maxNumber+1);      //int holding random number for new game plus thingy
        
        
        if (Settings.limitChoice == 1)  //if player has setting for asking the prompt that is default on, it will ask for limited attempts
        {
            Gui.PrintText(Settings.CurrentLanguage.Get(LanguageKey.LmtdQ));
            while (!int.TryParse(Console.ReadLine(), out readLimited) || readLimited < 0 || readLimited > 1)
            {
                Console.WriteLine(Settings.CurrentLanguage.Get(LanguageKey.InvalidSelection));
            }

            
            if (readLimited == 1)       //asks how many attempts (I set 10 max cause why not)
            {
                Gui.PrintText(Settings.CurrentLanguage.Get(LanguageKey.LmtdQ2));
                while (!int.TryParse(Console.ReadLine(), out limitedAttempts) || limitedAttempts < 0 ||
                       limitedAttempts > 10)
                {
                    Console.WriteLine(Settings.CurrentLanguage.Get(LanguageKey.InvalidSelection));
                }
            }
        }

        
        if (readLimited == 1)       //game using limited attempt mechanic
        {
            Gui.PrintText(Settings.CurrentLanguage.Get(LanguageKey.Guess));
            int guessedNumber;
            
            while (!int.TryParse(Console.ReadLine(), out guessedNumber) || guessedNumber < 0 || guessedNumber >= maxNumber+1)
            {
                Console.WriteLine(Settings.CurrentLanguage.Get(LanguageKey.InvalidSelection));
            }
            
            var startTime = DateTime.Now;
            while (guessedNumber != number && limitedAttempts > 0)
            {
                
                if (guessedNumber < number)     //when you hit smaller
                {
                    string randomPhrases = Phrases[Rnd.Next(0, Phrases.Length)];
                    Gui.PrintText(Settings.CurrentLanguage.Get(LanguageKey.TooLittle) + randomPhrases + Settings.CurrentLanguage.Get(LanguageKey.CurrentAttempt) + attempts + Settings.CurrentLanguage.Get(LanguageKey.AttemptsRemain) + limitedAttempts);
                    attempts++;
                    limitedAttempts--;
                    Random phraseNumber = new Random();
                    while (!int.TryParse(Console.ReadLine(), out guessedNumber) || guessedNumber < 0 || guessedNumber >= maxNumber+1)
                    {
                        Console.WriteLine(Settings.CurrentLanguage.Get(LanguageKey.InvalidSelection));
                    }
                }
                else if (guessedNumber > number)        //when u hit higher
                {
                    string randomPhrases = Phrases[Rnd.Next(0, Phrases.Length)];
                    Gui.PrintText(Settings.CurrentLanguage.Get(LanguageKey.TooHigh)+randomPhrases + Settings.CurrentLanguage.Get(LanguageKey.CurrentAttempt) + attempts + Settings.CurrentLanguage.Get(LanguageKey.AttemptsRemain)+ limitedAttempts);
                    attempts++;
                    limitedAttempts--;
                    Random phraseNumber = new Random();
                    
                    while (!int.TryParse(Console.ReadLine(), out guessedNumber) || guessedNumber < 0 || guessedNumber >= maxNumber+1)
                    {
                        Console.WriteLine(Settings.CurrentLanguage.Get(LanguageKey.InvalidSelection));
                    }
                }
                
                if (guessedNumber == number)        //win
                {
                    var endTime = DateTime.Now;
                    timeSeconds  = (int)(endTime - startTime).TotalSeconds;
                    break;
                }
            }

            if (limitedAttempts == 0)       //wen u have 0 attempts left u fail and come back to menu
            {
                Gui.PrintText(Settings.CurrentLanguage.Get(LanguageKey.Fail));
                Console.ReadKey();
                Console.Clear();
                return null;
            }
            
            
            Gui.PrintText(Settings.CurrentLanguage.Get(LanguageKey.Win));
            string playerName = Console.ReadLine();
            Console.Clear();
            newGamePlus = false;    //confirms settings newgameplus setting
            Score score = newGamePlus 
                ? new NewGamePlusScore(playerName, attempts, difficultyName, timeSeconds)   //jeżeli new game plus to zrob newgameplusscore jeżeli nie to zwykly score
                : new Score(playerName, attempts, difficultyName, timeSeconds);
            return score;
        }
        else        //when u dont have limited attempts
        {
            Gui.PrintText(Settings.CurrentLanguage.Get(LanguageKey.Guess));       
            int guessedNumber;
            
            while (!int.TryParse(Console.ReadLine(), out guessedNumber) || guessedNumber < 0 || guessedNumber >= maxNumber+1)
            {
                Console.WriteLine(Settings.CurrentLanguage.Get(LanguageKey.InvalidSelection));
            }
            
            var startTime = DateTime.Now;//starts stopwatch to measure how much time player spends in game
            while (guessedNumber != secretNumber)
            {
                if (newGamePlus && attempts % 8 == 0)      //changes random number when new game plus is on amd every 8 tries
                {
                    secretNumber = Rnd.Next(1, maxNumber+1);
                }
                
                if (guessedNumber < secretNumber)   //smaller
                {
                    string randomPhrases = Phrases[Rnd.Next(0, Phrases.Length)];
                    Gui.PrintText(Settings.CurrentLanguage.Get(LanguageKey.TooLittle)+randomPhrases + Settings.CurrentLanguage.Get(LanguageKey.CurrentAttempt) + attempts);
                    attempts++;
                    Random phraseNumber = new Random();
                    while (!int.TryParse(Console.ReadLine(), out guessedNumber) || guessedNumber < 0 || guessedNumber >= maxNumber+1)
                    {
                        Console.WriteLine(Settings.CurrentLanguage.Get(LanguageKey.InvalidSelection));
                    }
                }
                
                else if (guessedNumber > secretNumber)  //bigger
                {
                    string randomPhrases = Phrases[Rnd.Next(0, Phrases.Length)];
                    Gui.PrintText(Settings.CurrentLanguage.Get(LanguageKey.TooHigh) +randomPhrases + Settings.CurrentLanguage.Get(LanguageKey.CurrentAttempt) + attempts);
                    Random phraseNumber = new Random();
                    attempts++;
                    while (!int.TryParse(Console.ReadLine(), out guessedNumber) || guessedNumber < 0 || guessedNumber >= maxNumber+1)
                    {
                        Console.WriteLine(Settings.CurrentLanguage.Get(LanguageKey.InvalidSelection));
                    }
                }
                if (guessedNumber == secretNumber)      //stop time
                { 
                    var endTime = DateTime.Now;
                    timeSeconds  = (int)(endTime - startTime).TotalSeconds;
                    break;
                }
            }
            
            Gui.PrintText(Settings.CurrentLanguage.Get(LanguageKey.Win));     //win
            string playerName = Console.ReadLine();
            Console.Clear();
            Score score = newGamePlus 
                ? new NewGamePlusScore(playerName, attempts, difficultyName, timeSeconds)
                : new Score(playerName, attempts, difficultyName, timeSeconds);
            return score;
        }
    }
}
    

