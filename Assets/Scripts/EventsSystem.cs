using UnityEngine;

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
        Debug.Log(_numberOfStepsRemaining + "Steps Left");
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
        Debug.Log("GAME LOST");
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
        Debug.Log("GAME WON");
        if (onGameWin != null)
        {
            onGameWin();
        }
    }

    /// TODO: HAND OFF SOUND
}
