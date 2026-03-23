

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
            Settings.CurrentLanguage.Get("p1"),
            Settings.CurrentLanguage.Get("p2"),
            Settings.CurrentLanguage.Get("p3"),
            Settings.CurrentLanguage.Get("p4"),
            Settings.CurrentLanguage.Get("p5")
        };
        
        
        int number = Rnd.Next(1, maxNumber+1);      //int holding random number
        int secretNumber =  Rnd.Next(1, maxNumber+1);      //int holding random number for new game plus thingy
        
        
        if (Settings.limitChoice == 1)  //if player has setting for asking the prompt that is default on, it will ask for limited attempts
        {
            Gui.PrintText(Settings.CurrentLanguage.Get("lmtd_q"));
            while (!int.TryParse(Console.ReadLine(), out readLimited) || readLimited < 0 || readLimited > 1)
            {
                Console.WriteLine(Settings.CurrentLanguage.Get("invalid_selection"));
            }

            
            if (readLimited == 1)       //asks how many attempts (I set 10 max cause why not)
            {
                Gui.PrintText(Settings.CurrentLanguage.Get("lmtd_q_2"));
                while (!int.TryParse(Console.ReadLine(), out limitedAttempts) || limitedAttempts < 0 ||
                       limitedAttempts > 10)
                {
                    Console.WriteLine(Settings.CurrentLanguage.Get("invalid_selection"));
                }
            }
        }

        
        if (readLimited == 1)       //game using limited attempt mechanic
        {
            Gui.PrintText(Settings.CurrentLanguage.Get("guess"));
            int guessedNumber;
            
            while (!int.TryParse(Console.ReadLine(), out guessedNumber) || guessedNumber < 0 || guessedNumber >= maxNumber+1)
            {
                Console.WriteLine(Settings.CurrentLanguage.Get("invalid_selection"));
            }
            
            var startTime = DateTime.Now;
            while (guessedNumber != number && limitedAttempts > 0)
            {
                
                if (guessedNumber < number)     //when you hit smaller
                {
                    string randomPhrases = Phrases[Rnd.Next(0, Phrases.Length)];
                    Gui.PrintText(Settings.CurrentLanguage.Get("too_little") + randomPhrases + Settings.CurrentLanguage.Get("current_attempt") + attempts + Settings.CurrentLanguage.Get("attempts_remain") + limitedAttempts);
                    attempts++;
                    limitedAttempts--;
                    Random phraseNumber = new Random();
                    while (!int.TryParse(Console.ReadLine(), out guessedNumber) || guessedNumber < 0 || guessedNumber >= maxNumber+1)
                    {
                        Console.WriteLine(Settings.CurrentLanguage.Get("invalid_selection"));
                    }
                }
                else if (guessedNumber > number)        //when u hit higher
                {
                    string randomPhrases = Phrases[Rnd.Next(0, Phrases.Length)];
                    Gui.PrintText(Settings.CurrentLanguage.Get("Too_high")+randomPhrases + Settings.CurrentLanguage.Get("current_attempt") + attempts + Settings.CurrentLanguage.Get("attempts_remain")+ limitedAttempts);
                    attempts++;
                    limitedAttempts--;
                    Random phraseNumber = new Random();
                    
                    while (!int.TryParse(Console.ReadLine(), out guessedNumber) || guessedNumber < 0 || guessedNumber >= maxNumber+1)
                    {
                        Console.WriteLine(Settings.CurrentLanguage.Get("invalid_selection"));
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
                Gui.PrintText(Settings.CurrentLanguage.Get("fail"));
                Console.ReadKey();
                Console.Clear();
                return null;
            }
            
            
            Gui.PrintText(Settings.CurrentLanguage.Get("win"));
            string playerName = Console.ReadLine();
            Console.Clear();
            newGamePlus = false;    //confirms settings newgameplus setting
            Score score = new Score(playerName, attempts, difficultyName,newGamePlus, timeSeconds);      //returns variables for leaderboard
            return score;
        }
        else        //when u dont have limited attempts
        {
            Gui.PrintText(Settings.CurrentLanguage.Get("guess"));       
            int guessedNumber;
            
            while (!int.TryParse(Console.ReadLine(), out guessedNumber) || guessedNumber < 0 || guessedNumber >= maxNumber+1)
            {
                Console.WriteLine(Settings.CurrentLanguage.Get("invalid_selection"));
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
                    Gui.PrintText(Settings.CurrentLanguage.Get("too_little")+randomPhrases + Settings.CurrentLanguage.Get("current_attempt") + attempts);
                    attempts++;
                    Random phraseNumber = new Random();
                    while (!int.TryParse(Console.ReadLine(), out guessedNumber) || guessedNumber < 0 || guessedNumber >= maxNumber+1)
                    {
                        Console.WriteLine(Settings.CurrentLanguage.Get("invalid_selection"));
                    }
                }
                
                else if (guessedNumber > secretNumber)  //bigger
                {
                    string randomPhrases = Phrases[Rnd.Next(0, Phrases.Length)];
                    Gui.PrintText(Settings.CurrentLanguage.Get("too_high") +randomPhrases + Settings.CurrentLanguage.Get("current_attempt") + attempts);
                    Random phraseNumber = new Random();
                    attempts++;
                    while (!int.TryParse(Console.ReadLine(), out guessedNumber) || guessedNumber < 0 || guessedNumber >= maxNumber+1)
                    {
                        Console.WriteLine(Settings.CurrentLanguage.Get("invalid_selection"));
                    }
                }
                if (guessedNumber == secretNumber)      //stop time
                { 
                    var endTime = DateTime.Now;
                    timeSeconds  = (int)(endTime - startTime).TotalSeconds;
                    break;
                }
            }
            
            Gui.PrintText(Settings.CurrentLanguage.Get("win"));     //win
            string playerName = Console.ReadLine();
            Console.Clear();
            Score score = new Score(playerName, attempts, difficultyName,newGamePlus, timeSeconds);
            return score;
        }
    }
}
    

