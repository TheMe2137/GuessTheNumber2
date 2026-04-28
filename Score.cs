public class Score
{
    public string PlayerName { get; set; }
    public int Attempts { get; set; }
    public string Difficulty { get; set; }
    public int TimeSeconds { get; set; }

    public Score(string playerName, int attempts, string difficulty, int timeSeconds)
    {
        PlayerName = playerName;
        Attempts = attempts;
        Difficulty = difficulty;
        TimeSeconds = timeSeconds;
    }

    public virtual string GetScoreType() => "Normal"; // domyślnie zwykły wynik
}

public class NewGamePlusScore : Score
{
    public NewGamePlusScore(string playerName, int attempts, string difficulty, int timeSeconds)
        : base(playerName, attempts, difficulty, timeSeconds) // wywołuje konstruktor Score
    {
    }

    public override string GetScoreType() => "NG+"; // nadpisuje na NG+
}