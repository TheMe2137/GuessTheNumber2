using System.Numerics;

namespace GuessTheNumber2;
public abstract class Language  //abstract class so u cant use new lang but ya gotta use inheritance thingy 
{
    public abstract string Get(string key);
}
class Polish : Language     // polimorphism and abstraction class making valid reason to use the abstract class 
{
    public override string Get(string key)
    {
        switch (key)
        {
            case "menu_play":
                return "1. Graj zwykla gre";
            case "menu_play2":
                return "2. Graj w nowa gre plus ";
            case "menu":
                return "MENU GLOWNE";
            case "choice_1":
                return "Wybierz jedna z opcji ponizej";
            case "leaderboard":
                return "3. Sala Slaw";
            case "settings":
                return "4. Ustawienia";
            case "exit":
                return "5. Wyjscie";
            case "invalid_selection":
                return "Zly input.. Sprobuj jeszcze raz";
            case "choice_2":
                return "Wybierz trudnosc \n 1. Latwy (Zakres 1-25) \n 2. Sredni (Zakres 1-50) \n 3. Trudny (Zakres 1-100) \n 4. Powrot do menu glownego";
            case "lmtd_q":
                return "Limitowane proby? \n 1. Tak \n 0. Nie";
            case "lmtd_q_2":
                return "Ile prob? \n Zakres 1-10";
            case"guess":
                return "Zgadnij liczbe!";
            case"too_little":
                return "Za malo! ";
            case"too_high":
                return "Za duzo! ";
            case"current_attempt":
                return " Obecna proba : ";
            case"attempts_remain":
                return "Prob pozostalo : ";
            case"fail":
                return "Przegrales! Nacisnij jakikolwiek przycisk aby wrocic...";
            case"win":
                return "Gratulacje! \n Podaj swoja nazwe uzytkownika...";
            case"leaderboardshow":
                return ("Sala Slaw \n 1.  Latwy \n 2.  Sredni \n 3.  Trudny \n 4. Powrot do menu...");
            case"noscores":
                return "Brak wynikow...";
            case "leaderstart":
                return "===SALA SLAW===";
            case "attempts":
                return "prob.";
            case "time":
                return "Czas - ";
            case"return":
                return "\nNacisnij jakikolwiek klawisz aby wrocic...";
            case"settings_show":
                return "Ustawienia \n 1. Zmien jezyk \n 2. prompty \n 3. Wyczysc Tablice Wynikow \n 4. Wroc";
            case"sellang":
                return "Wybierz jezyk \n 1. English \n 2. Polski \n 3. Wroc";
            case"selllimit":
                return "Wybierz czy chcesz byc pytany o limitowane proby \n 1. tak \n 2. Nie \n 3. Wroc";
            case"p1":
                return "kurcze nie umiesz";
            case"p2":
                return "frajer...";
            case"p3":
                return "wez sie ogarnij majster";
            case"p4":
                return "co ty soba wogole reprezentujesz";
            case "p5":
                return "wez XD przestan";
            case "nmbchng":
                return "NUMER SIE ZMIENIL";
            case"clearq":
                return "Czy na pewno chcesz sclearowac wyniki? \n 1. Tak \n 2. Nie";
                    
            }
        return "Brak textu";
    }
    }


class English : Language
{
    public override string Get(string key)
    {
        switch (key)
        {
            case "menu_play":
                return "1. Play normal game";
            case "menu_play2":
                return "2. Play New Game Plus ";
            case "menu":
                return "MAIN MENU";
            case "choice_1":
                return "Select one of the options below:";
            case "leaderboard":
                return "3. Hall of Fame";
            case "settings":
                return "4. Settings";
            case "exit":
                return "5. Exit";
            case "invalid_selection":
                return "Invalid selection.. Try again";
            case "choice_2":
                return
                    "Select difficulty \n 1. Easy (Range 1-25) \n 2. Medium (Range 1-50) \n 3. Hard (Range 1-100) \n 4. Return to main menu";
            case "lmtd_q":
                return "Limited attempts? \n 0. Yes \n 1. No3";
            case "lmtd_q_2":
                return "How many attempts? \n Range 1-10";
            case "guess":
                return "Guess the number!";
            case "too_little":
                return "Too little! ";
            case "too_high":
                return "Too high! ";
            case "current_attempt":
                return " Current attempt: ";
            case "attempts_remain":
                return "Attempt remaining: ";
            case "fail":
                return "You failed! Press any key to exit...";
            case "win":
                return "Congratulations! \n Enter your username...";
            case "leaderboardshow":
                return "Hall of Fame \n 1.  Easy \n 2.  Medium \n 3.  Hard \n 4. Return to menu";
            case "noscores":
                return "No scores yet...";
            case "leaderstart":
                return "===Hall of Fame===";
            case "attempts":
                return "Attempts.";
            case "time":
                return "Time - ";
            case "return":
                return "\nPress any key to return...";
            case "settings_show":
                return "Settings \n 1. Change language \n 2. Prompts \n 3. Clear Hall of Fame \n 4. Back";
            case "sellang":
                return "Select language \n 1. English \n 2. Polski \n 3. Back";
            case "selllimit":
                return "Select if you want to get the limited attempts prompt \n 1. Yes \n 2. No \n 3. Back";
            case "p1":
                return "damn you suck";
            case "p2":
                return "you lost!";
            case "p3":
                return "u stupid";
            case "p4":
                return "holy hell just guess already";
            case "p5":
                return "XDDD loooseer";
            case "nmbchng":
                return "NUMBER HAS BEEN CHANGED";
            case "clearq":
                return "Are you sure you want to delete all scores? \n 1. Yes \n 2. No";
        }

        return "No text";
    }
}


 