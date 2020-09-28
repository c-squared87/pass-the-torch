using UnityEngine;

public static class EventsSystem
{

    /**
        INDEX:

        OnStepsChanged
        OnGameLose
        OnGameWin
        OnBroadcastMessage
        OnPlayerSuccess
        OnPlayerFail
    **/

    public delegate void OnStepsChanged(int _numberOfStepsRemaining);
    static event OnStepsChanged onStepsChanged;

    public static void ADD_StepsChangedListener(EventsSystem.OnStepsChanged _method)
    {
        onStepsChanged += _method;
    }
    public static void REMOVE_StepsChangedListener(EventsSystem.OnStepsChanged _method)
    {
        onStepsChanged -= _method;
    }
    public static void StepsChanged(int _numberOfStepsRemaining)
    {
        if (onStepsChanged != null) { onStepsChanged(_numberOfStepsRemaining); }
    }

    //====================================================================================

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
        if (onGameLose != null) { onGameLose(); }
    }

    //====================================================================================

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
        if (onGameWin != null) { onGameWin(); }
    }

    //====================================================================================

    public delegate void OnBroadcastMessage(string _message);
    static event OnBroadcastMessage onBroadcastMessage;

    public static void ADD_BroadcastMessageListener(EventsSystem.OnBroadcastMessage _method)
    {
        onBroadcastMessage += _method;
    }
    public static void REMOVE_BroadcastMessageListener(EventsSystem.OnBroadcastMessage _method)
    {
        onBroadcastMessage -= _method;
    }
    public static void BroadcastMessage(string _message)
    {
        if (onBroadcastMessage != null) { onBroadcastMessage(_message); }
    }

    //==================================================================================== 

    public delegate void OnPlayerSuccess();
    static event OnPlayerSuccess onPlayerSuccess;

    public static void ADD_PlayerSuccessListener(EventsSystem.OnPlayerSuccess _method)
    {
        onPlayerSuccess += _method;
    }
    public static void REMOVE_PlayerSuccessListener(EventsSystem.OnPlayerSuccess _method)
    {
        onPlayerSuccess -= _method;
    }
    public static void PlayerSuccess()
    {
        if (onPlayerSuccess != null) { onPlayerSuccess(); }
    }

    //====================================================================================

    public delegate void OnPlayerFail();
    static event OnPlayerFail onPlayerFail;

    public static void ADD_PlayerFailListener(EventsSystem.OnPlayerFail _method)
    {
        onPlayerFail += _method;
    }
    public static void REMOVE_PlayerFailListener(EventsSystem.OnPlayerFail _method)
    {
        onPlayerFail -= _method;
    }
    public static void PlayerFail()
    {
        if (onPlayerFail != null) { onPlayerFail(); }
    }

    //====================================================================================


}
