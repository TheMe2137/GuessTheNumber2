namespace GuessTheNumber2;


public class Game   //class having game oriented objects/methods
{
    private static Random Rnd = new Random();
    private static int limitedAttempts;
    public static int readLimited;
    public static int timeSeconds;
    
    
    public static Score startGame(int maxNumber, string difficultyName, bool newGamePlus, int changeInterval)      //method that contains main game
    {
        int attempts = 1;
        
        string[] Phrases =      //array holding phrases that switch each time when player guesses wrong
        {
            Settings.CurrentLanguage.Get(LanguageKey.P1),
            Settings.CurrentLanguage.Get(LanguageKey.P2),
            Settings.CurrentLanguage.Get(LanguageKey.P3),
            Settings.CurrentLanguage.Get(LanguageKey.P4),
            Settings.CurrentLanguage.Get(LanguageKey.P5)
        };
        
        int number = Rnd.Next(1, maxNumber+1);      //int holding random number
        
        int secretNumber =  Rnd.Next(1, maxNumber+1);      //int holding random number for new game plus 
        
        if (newGamePlus)
        {
            Settings.limitChoice = 0;   //sets limited attempts to 0 if newgameplus is started
        }
        
        
        if (Settings.limitChoice == 1)  //if player has setting for asking the prompt that is default on, it will ask for limited attempts
        {
            Gui.PrintText(Settings.CurrentLanguage.Get(LanguageKey.LmtdQ));
            readLimited = Gui.ReadInt(0, 1);

            if (readLimited == 1)       //asks how many attempts (I set 10 max)
            {
                Gui.PrintText(Settings.CurrentLanguage.Get(LanguageKey.LmtdQ2));
                limitedAttempts = Gui.ReadInt(1, 10);
            }
        }

        
        if (readLimited == 1)       //game using limited attempt mechanic
        {
            
            Gui.PrintText(Settings.CurrentLanguage.Get(LanguageKey.Guess));
            
            int guessedNumber = Gui.ReadInt(0, maxNumber);
            
            var startTime = DateTime.Now;
            
            while (guessedNumber != number && limitedAttempts > 0)  //starts game loop with limited attempts
            {
                if (guessedNumber < number)     //when you guess a number that is lower
                {
                    string randomPhrases = Phrases[Rnd.Next(0, Phrases.Length)];
                    
                    Gui.PrintText(Settings.CurrentLanguage.Get(LanguageKey.TooLittle) +
                                  randomPhrases + 
                                  Settings.CurrentLanguage.Get(LanguageKey.CurrentAttempt) + 
                                  attempts + 
                                  Settings.CurrentLanguage.Get(LanguageKey.AttemptsRemain) + 
                                  limitedAttempts);
                    
                    attempts++;
                    limitedAttempts--;
                    
                    Random phraseNumber = new Random();
                    guessedNumber = Gui.ReadInt(0, maxNumber);
                }
                else if (guessedNumber > number)        //when you guess a number that is higher
                {
                    string randomPhrases = Phrases[Rnd.Next(0, Phrases.Length)];
                    
                    Gui.PrintText(Settings.CurrentLanguage.Get(LanguageKey.TooHigh)+
                                  randomPhrases + 
                                  Settings.CurrentLanguage.Get(LanguageKey.CurrentAttempt) + 
                                  attempts + 
                                  Settings.CurrentLanguage.Get(LanguageKey.AttemptsRemain)+ 
                                  limitedAttempts);
                    
                    attempts++;
                    limitedAttempts--;
                    
                    Random phraseNumber = new Random();
                    
                    guessedNumber = Gui.ReadInt(0, maxNumber);
                }
                
                if (guessedNumber == number)        //when player wins, timer ends and is taken by timeSeconds variable
                {
                    var endTime = DateTime.Now;
                    timeSeconds  = (int)(endTime - startTime).TotalSeconds;
                    break;
                }
            }

            if (limitedAttempts == 0)       //when you have 0 attempts left you fail and come back to menu
            {
                Gui.PrintText(Settings.CurrentLanguage.Get(LanguageKey.Fail));
                Console.ReadKey();
                Console.Clear();
                return null;
            }
            
            
            Gui.PrintText(Settings.CurrentLanguage.Get(LanguageKey.Win));
            
            string playerName = Console.ReadLine();
            
            Console.Clear();
            
            newGamePlus = false;    //makes sure the newGaMEpLUS variable is false
            Score score = newGamePlus 
                ? new NewGamePlusScore(playerName, attempts, difficultyName, timeSeconds)   //if player chose newGameplus it makes a score for new game plus, if not then for normal score
                : new Score(playerName, attempts, difficultyName, timeSeconds);
            return score;
        }
        else        //When player chose attempts with no limit
        {
            Gui.PrintText(Settings.CurrentLanguage.Get(LanguageKey.Guess));     
            
            int guessedNumber = Gui.ReadInt(0, maxNumber);
            
            var startTime = DateTime.Now;   //starts stopwatch to measure how much time player spends in game
            while (guessedNumber != secretNumber)
            {
                if (newGamePlus && attempts % changeInterval == 0)      //changes random number when new game plus is on amd every 8 tries
                {
                    secretNumber = Rnd.Next(1, maxNumber+1);
                    Gui.PrintText(Settings.CurrentLanguage.Get(LanguageKey.NmbChng));
                    Console.ReadKey();
                }
                
                if (guessedNumber < secretNumber)   //When player guesses number that is lower then number
                {
                    string randomPhrases = Phrases[Rnd.Next(0, Phrases.Length)];
                    Gui.PrintText(Settings.CurrentLanguage.Get(LanguageKey.TooLittle)+
                                  randomPhrases + 
                                  Settings.CurrentLanguage.Get(LanguageKey.CurrentAttempt) + 
                                  attempts);
                    attempts++;
                    Random phraseNumber = new Random();
                    guessedNumber = Gui.ReadInt(0, maxNumber);
                }
                
                else if (guessedNumber > secretNumber)  //When player guesses number that is higher then number
                {
                    string randomPhrases = Phrases[Rnd.Next(0, Phrases.Length)];
                    Gui.PrintText(Settings.CurrentLanguage.Get(LanguageKey.TooHigh) +
                                  randomPhrases + 
                                  Settings.CurrentLanguage.Get(LanguageKey.CurrentAttempt) + 
                                  attempts);
                    Random phraseNumber = new Random();
                    attempts++;
                    guessedNumber = Gui.ReadInt(0, maxNumber);
                }
                if (guessedNumber == secretNumber)      //stops timer and pushes it into variable
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
    

