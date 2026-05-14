using System.Numerics;

namespace GuessTheNumber2;
public abstract class Language  //abstract class so u cant use new lang but ya gotta use inheritance thingy 
{
    public abstract string Get(LanguageKey key);
}
public enum LanguageKey
{
    MenuPlay,
    MenuPlay2,
    Menu,
    Choice1,
    Choice2,
    Leaderboard,
    Settings,
    Exit,
    InvalidSelection,
    LmtdQ,
    LmtdQ2,
    Guess,
    TooLittle,
    TooHigh,
    CurrentAttempt,
    AttemptsRemain,
    Fail,
    Win,
    LeaderboardShow,
    NoScores,
    LeaderStart,
    Attempts,
    Time,
    Return,
    SettingsShow,
    SelLang,
    SelLimit,
    P1, P2, P3, P4, P5,
    NmbChng,
    ClearQ
}
class Polish : Language
{
    public override string Get(LanguageKey key)
    {
        switch (key)
        {
            case LanguageKey.MenuPlay: return "1. Graj zwykla gre";
            case LanguageKey.MenuPlay2: return "2. Graj w nowa gre plus";
            case LanguageKey.Menu: return "MENU GLOWNE";
            case LanguageKey.Choice1: return "Wybierz jedna z opcji ponizej";
            case LanguageKey.Choice2: return "Wybierz trudnosc \n 1. Latwy (Zakres 1-25) \n 2. Sredni (Zakres 1-50) \n 3. Trudny (Zakres 1-100) \n 4. Powrot do menu glownego";
            case LanguageKey.Leaderboard: return "3. Sala Slaw";
            case LanguageKey.Settings: return "4. Ustawienia";
            case LanguageKey.Exit: return "5. Wyjscie";
            case LanguageKey.InvalidSelection: return "Zly input.. Sprobuj jeszcze raz";
            case LanguageKey.LmtdQ: return "Limitowane proby? \n 1. Tak \n 0. Nie";
            case LanguageKey.LmtdQ2: return "Ile prob? \n Zakres 1-10";
            case LanguageKey.Guess: return "Zgadnij liczbe!";
            case LanguageKey.TooLittle: return "Za malo! ";
            case LanguageKey.TooHigh: return "Za duzo! ";
            case LanguageKey.CurrentAttempt: return " Obecna proba : ";
            case LanguageKey.AttemptsRemain: return "Prob pozostalo : ";
            case LanguageKey.Fail: return "Przegrales! Nacisnij jakikolwiek przycisk aby wrocic...";
            case LanguageKey.Win: return "Gratulacje! \n Podaj swoja nazwe uzytkownika...";
            case LanguageKey.LeaderboardShow: return "Sala Slaw \n 1.  Latwy \n 2.  Sredni \n 3.  Trudny \n 4. Powrot do menu...";
            case LanguageKey.NoScores: return "Brak wynikow...";
            case LanguageKey.LeaderStart: return "===SALA SLAW===";
            case LanguageKey.Attempts: return "prob.";
            case LanguageKey.Time: return "Czas - ";
            case LanguageKey.Return: return "\nNacisnij jakikolwiek klawisz aby wrocic...";
            case LanguageKey.SettingsShow: return "Ustawienia \n 1. Zmien jezyk \n 2. prompty \n 3. Wyczysc Tablice Wynikow \n 4. Wroc";
            case LanguageKey.SelLang: return "Wybierz jezyk \n 1. English \n 2. Polski \n 3. Wroc";
            case LanguageKey.SelLimit: return "Wybierz czy chcesz byc pytany o limitowane proby \n 1. tak \n 2. Nie \n 3. Wroc";
            case LanguageKey.P1: return "kurcze nie umiesz";
            case LanguageKey.P2: return "frajer...";
            case LanguageKey.P3: return "wez sie ogarnij majster";
            case LanguageKey.P4: return "co ty soba wogole reprezentujesz";
            case LanguageKey.P5: return "wez XD przestan";
            case LanguageKey.NmbChng: return "NUMER SIE ZMIENIL naciśnij jakikolwiek klawisz aby kontynuować";
            case LanguageKey.ClearQ: return "Czy na pewno chcesz sclearowac wyniki? \n 1. Tak \n 2. Nie";
            default: return "Brak textu";
        }
    }
}


class English : Language
{
    public override string Get(LanguageKey key)
    {
        switch (key)
        {
            case LanguageKey.MenuPlay: return "1. Play normal game";
            case LanguageKey.MenuPlay2: return "2. Play New Game Plus";
            case LanguageKey.Menu: return "MAIN MENU";
            case LanguageKey.Choice1: return "Choose one of the options below";
            case LanguageKey.Choice2: return "Choose difficulty \n 1. Easy (Range 1-25) \n 2. Medium (Range 1-50) \n 3. Hard (Range 1-100) \n 4. Return to main menu";
            case LanguageKey.Leaderboard: return "3. Hall of Fame";
            case LanguageKey.Settings: return "4. Settings";
            case LanguageKey.Exit: return "5. Exit";
            case LanguageKey.InvalidSelection: return "Wrong input.. Try again";
            case LanguageKey.LmtdQ: return "Limited attempts? \n 1. Yes \n 0. No";
            case LanguageKey.LmtdQ2: return "How many attempts? \n Range 1-10";
            case LanguageKey.Guess: return "Guess the Number!";
            case LanguageKey.TooLittle: return "Too low! ";
            case LanguageKey.TooHigh: return "Too high! ";
            case LanguageKey.CurrentAttempt: return " Current attempt : ";
            case LanguageKey.AttemptsRemain: return "attempts left : ";
            case LanguageKey.Fail: return "You lost! Press any key to return...";
            case LanguageKey.Win: return "Congratulations! \n enter your username ...";
            case LanguageKey.LeaderboardShow: return "Hall of Fame \n 1.  Easy \n 2.  Medium \n 3.  Hard \n 4. Return to menu...";
            case LanguageKey.NoScores: return "No scores ...";
            case LanguageKey.LeaderStart: return "===Hall of Fame===";
            case LanguageKey.Attempts: return "attempts.";
            case LanguageKey.Time: return "Time - ";
            case LanguageKey.Return: return "\nPress any key to return...";
            case LanguageKey.SettingsShow: return "Settings \n 1. Langugae \n 2. Prompts \n 3. Clear Leaderboard  \n 4. Return";
            case LanguageKey.SelLang: return "Choose Language \n 1. English \n 2. Polsih \n 3. Return";
            case LanguageKey.SelLimit: return "Choose if you want to be asked for limited attempts \n 1. Yes \n 2. No \n 3. Return";
            case LanguageKey.P1: return "Come onn...";
            case LanguageKey.P2: return "u stupid??...";
            case LanguageKey.P3: return "mate just get a hang of youraself";
            case LanguageKey.P4: return "who do you think you are";
            case LanguageKey.P5: return "god just stop playing atp!";
            case LanguageKey.NmbChng: return "The NUMBER has CHANGED Please press any key to continue";
            case LanguageKey.ClearQ: return "Do you surely want to clear your leaderboard scores  \n 1. Yes \n 2. No";
            default: return "No text..";
        }
    }
}

 