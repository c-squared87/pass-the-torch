using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Dictionary<Vector3, Space> Spaces;
    public Dictionary<Vector3, TorchPoint> TorchPoints;

    public Vector3 LevelStartLocation { get; private set; }

    GameObject[] activeOnWin;
    GameObject[] activeOnLoss;

    private void OnEnable()
    {
        InitUI();

        if (TorchPoints == null) { TorchPoints = new Dictionary<Vector3, TorchPoint>(); }
        if (Spaces == null) { Spaces = new Dictionary<Vector3, Space>(); }

        EventsSystem.ADD_GameLoseListener(LoseScreen);
        EventsSystem.ADD_GameWinListener(WinScreen);
    }

    private void OnDisable()
    {
        EventsSystem.REMOVE_GameLoseListener(LoseScreen);
        EventsSystem.REMOVE_GameWinListener(WinScreen);
    }

    private void InitUI()
    {
        activeOnWin = GameObject.FindGameObjectsWithTag("ActiveOnGameWon");
        activeOnLoss = GameObject.FindGameObjectsWithTag("ActiveOnGameOver");

        foreach (GameObject gameObject in activeOnWin) { gameObject.SetActive(false); }
        foreach (GameObject gameObject in activeOnLoss) { gameObject.SetActive(false); }
    }

    private void WinScreen()
    {
        foreach (GameObject gameObject in activeOnWin) { gameObject.SetActive(true); }
        FindObjectOfType<Player>().enabled = false;
    }

    private void LoseScreen()
    {
        foreach (GameObject gameObject in activeOnLoss) { gameObject.SetActive(true); }
        FindObjectOfType<Player>().enabled = false;
    }

    public bool CanMove(Vector3 _locationToCheck)
    {
        if (TorchPoints.ContainsKey(_locationToCheck)) { TorchPoints[_locationToCheck].HandOffTorch(); }

        if (Spaces[_locationToCheck].currentSPACE_STATE != SPACE_STATE.BLOCKED)
        {
            if (Spaces[_locationToCheck].currentSPACE_STATE == SPACE_STATE.EXIT_SPACE) { EventsSystem.GameWon(); }
            // Spaces[_locationToCheck].currentSPACE_STATE = SPACE_STATE.BLOCKED;
            return true;
        }
        return false;
    }

    public void UpdateSpace(Space _space)
    {
        if (_space.currentSPACE_STATE == SPACE_STATE.START_SPACE)
        {
            LevelStartLocation = _space.SpaceLocation;
            return;
        }

        if (Spaces == null) { Spaces = new Dictionary<Vector3, Space>(); }

        Spaces.Add(_space.SpaceLocation, _space);
    }

    public void UpdateTorchPoints(TorchPoint _point)
    {
        if (TorchPoints == null) { TorchPoints = new Dictionary<Vector3, TorchPoint>(); }

        TorchPoints.Add(_point.TorchPointLocation, _point);
    }

    public void RemoveTorchPoint(TorchPoint _point)
    {
        TorchPoints.Remove(_point.TorchPointLocation);
    }

}
