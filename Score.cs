namespace GuessTheNumber2;

public class Score  //class having stuff to hold for leaderboard
{
    public string PlayerName { get; set; }      //nick
    public int Attempts { get; set; }       //amount of attempts
    public string Difficulty { get; set; }      //difficulty
    public bool isNewGamePlus { get; set; }     //bool to check if player chose new game plus option
    public int TimeSeconds { get; set; }       //time 
    public Score(string playerName, int attempts, string difficulty, bool isNewGamePlus, int timeSeconds)   //constructor 
    {
        PlayerName = playerName;
        Attempts = attempts;
        Difficulty = difficulty;
        this.isNewGamePlus = isNewGamePlus;
        TimeSeconds = timeSeconds;
        
    }

}