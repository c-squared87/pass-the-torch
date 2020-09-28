public static class EventsSystem
{
    public delegate void OnPlayerMoved(int _numberOfStepsRemaining);
    static event OnPlayerMoved onPlayerMoved;

    public static void ADD_PlayerMovedListener(EventsSystem.OnPlayerMoved _method)
    {
        onPlayerMoved += _method;
    }
    public static void REMOVE_PlayerMovedListener(EventsSystem.OnPlayerMoved _method)
    {
        onPlayerMoved -= _method;
    }
    public static void PlayerMoved(int _numberOfStepsRemaining)
    {
        if (onPlayerMoved != null)
        {
            onPlayerMoved(_numberOfStepsRemaining);
        }
    }


    public delegate void OnGameLose();
    static event OnGameLose onGameLose;

    public static void ADD_GameLoseListener(EventsSystem.OnGameLose _method)
    {
        onGameLose += _method;
    }
    public static void REMOVE_GameLoseListener(EventsSystem.OnGameLose _method)
    {
        onGameLose -= _method;
    }
    public static void GameLost()
    {
        if (onGameLose != null)
        {
            onGameLose();
        }
    }

    public delegate void OnGameWin();
    static event OnGameWin onGameWin;

    public static void ADD_GameWinListener(EventsSystem.OnGameWin _method)
    {
        onGameWin += _method;
    }
    public static void REMOVE_GameWinListener(EventsSystem.OnGameWin _method)
    {
        onGameWin -= _method;
    }
    public static void GameWon()
    {
        if (onGameWin != null)
        {
            onGameWin();
        }
    }
}
