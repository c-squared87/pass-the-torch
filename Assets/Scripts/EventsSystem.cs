public static class EventsSystem
{
    public delegate void OnPlayerMoved(int _numberOfStepsRemaining);
    static event OnPlayerMoved onPlayerMoved;

    public static void ADD_PlayerMoveedListener(EventsSystem.OnPlayerMoved _method)
    {
        onPlayerMoved += _method;
    }
    public static void REMOVE_PlayerMoveedListener(EventsSystem.OnPlayerMoved _method)
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
}
