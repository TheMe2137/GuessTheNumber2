using GuessTheNumber2;
    bool programDziala = true;
    while (programDziala)       //main program loop
    { 
        switch (Gui.ShowMenu())     //main menu 
            {
                case 1: //opens new game without new game plus
                {
                    var level = LevelChoice.levelChoice();
                    if (level.maxNumber != 0)
                    {
                        Console.Clear();
                        Score score = Game.startGame(level.maxNumber, level.difficultyName, false, 8);
                        Leaderboard.AddScore(score);
                    }

                    break;
                }
                case 2:     //opens new game with new game plus parameter
                {
                    var level = LevelChoice.levelChoice();
                    if (level.maxNumber != 0)
                    {
                        Console.Clear();
                        int interval = level.difficultyName switch
                        {
                            "easy" => 6,
                            "medium" => 7,
                            "hard" => 8,
                            _ => 8
                        };
                        Score score = Game.startGame(level.maxNumber, level.difficultyName, true, interval);
                        Leaderboard.AddScore(score);
                    }

                    break;
                }
                case 3:     //shows leaderboard when there are scores
                {
                    if (Leaderboard.HasScores())
                    {
                        Leaderboard.Show();
                    }

                    break;
                }
                case 4:     //shows settings menu
                {
                    
                    Settings.Show();
                    break;
                }
                case 5:     //turns off main program loop, thus, turning off the game :)
                {
                    
                    programDziala = false;
                    break;
                }
                    
            }
            
    }

    
