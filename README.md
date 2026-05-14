# 🎯 GuessTheNumber2

> A console-based number guessing game built in C# with full OOP architecture.  
> University project — Cybersecurity studies.

---

## 📖 About

GuessTheNumber2 is a rewrite of a classic number guessing game, rebuilt from scratch with clean Object-Oriented Programming principles. The game features multiple difficulty levels, a Hall of Fame leaderboard, bilingual support, and a chaotic **New Game Plus** mode where the secret number changes mid-game.

---

## 🎮 Features

- **3 difficulty levels** — Easy (1–25), Medium (1–50), Hard (1–100)
- **New Game Plus mode** — secret number changes every few attempts depending on difficulty
- **Hall of Fame** — leaderboard sorted by attempts and time, split by difficulty
- **Limited attempts mode** — optional, configurable 1–10 attempts
- **Bilingual** — English & Polish language support, switchable in settings
- **Taunts** — the game will talk trash when you guess wrong 💀

---

## 🏗️ OOP Architecture

The project demonstrates all four pillars of OOP:

| Pillar | Implementation |
|---|---|
| **Abstraction** | `abstract class Language` with `abstract Get(LanguageKey)` |
| **Inheritance** | `Polish : Language`, `English : Language`, `NewGamePlusScore : Score` |
| **Polymorphism** | `Language` reference holds either `Polish` or `English` at runtime; `GetScoreType()` returns different values per type |
| **Encapsulation** | `private static List<Score> scores` in `Leaderboard`, properties with getters/setters in `Score` |

---

## 📁 Project Structure

```
GuessTheNumber2/
├── MainProgramLoop.cs   # Main game loop
├── Game.cs              # Core game logic
├── Gui.cs               # UI methods + input validation
├── Language.cs          # Abstract language class + Polish/English + LanguageKey enum
├── Score.cs             # Score & NewGamePlusScore classes
├── Leaderboard.cs       # Hall of Fame logic
├── LevelChoice.cs       # Difficulty selection
└── Settings.cs          # Language, prompts, leaderboard settings
```

---

## 🔑 Key Design Decisions

### `LanguageKey` enum instead of strings
Instead of `language.Get("too_high")` (typo-prone), the game uses:
```csharp
language.Get(LanguageKey.TooHigh)
```
The compiler catches any mistakes immediately — no runtime surprises.

### `NewGamePlusScore` inherits from `Score`
```csharp
public class NewGamePlusScore : Score
{
    public override string GetScoreType() => "NG+";
}
```
The type of the object itself carries the information — no boolean flags needed.

### Centralized input validation
All user input goes through one method:
```csharp
int choice = Gui.ReadInt(min, max);
```

---



## 🕹️ How to Play

1. Launch the game
2. Select **Play normal game** or **New Game Plus**
3. Choose difficulty
4. Guess the number — the game will tell you if you're too high or too low
5. Win and get added to the **Hall of Fame**

In **New Game Plus**, the secret number changes every 6/7/8 attempts (depending on difficulty). Watch out for the `NUMBER HAS BEEN CHANGED` message.

---

## ⚙️ Settings

| Option | Description |
|---|---|
| Change language | Switch between English and Polish |
| Prompts | Toggle the limited attempts prompt on/off |
| Clear Hall of Fame | Wipe all scores |

---

## 👨‍💻 Author
Maciej Demianiuk

Built with C# 
