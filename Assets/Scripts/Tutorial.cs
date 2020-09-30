using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] Text text;

    Player player;

    public string[] Prompts = new string[]{
        "say hello to torch. move torch with wasd or arrow keys.",
        "torch has fuel, see the number? walk to the exit.",
        "not going to make the exit? go to a fuel point to refill."
        // GOOD LUCK!
        // - START GAME
        // - MAIN MENU
    };

    public Transform[] StartPoints;

    int currentTutorialStep = 0;

    public void AdvanceTutorial()
    {
        player = FindObjectOfType<Player>();

        currentTutorialStep++;
        transform.position = StartPoints[currentTutorialStep].position;
        player.transform.position = transform.position;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (text == null) { text = GetComponent<Text>(); }
        text.text = Prompts[currentTutorialStep];
    }

    #region REPURPOSED LEVELMANAGER CODE BELOW

    public Dictionary<Vector3, Space> Spaces;
    public Dictionary<Vector3, TorchPoint> TorchPoints;

    // public Vector3 LevelStartLocation { get; private set; }

    GameObject[] activeOnWin;
    GameObject[] activeOnLoss;

    private void OnEnable()
    {
        InitUI();

        if (TorchPoints == null) { TorchPoints = new Dictionary<Vector3, TorchPoint>(); }
        if (Spaces == null) { Spaces = new Dictionary<Vector3, Space>(); }

        // EventsSystem.ADD_GameLoseListener(LoseScreen);
        // EventsSystem.ADD_GameWinListener(WinScreen);
    }

    private void OnDisable()
    {
        // EventsSystem.REMOVE_GameLoseListener(LoseScreen);
        // EventsSystem.REMOVE_GameWinListener(WinScreen);
    }

    private void InitUI()
    {
        activeOnWin = GameObject.FindGameObjectsWithTag("ActiveOnGameWon");
        activeOnLoss = GameObject.FindGameObjectsWithTag("ActiveOnGameOver");

        foreach (GameObject gameObject in activeOnWin) { gameObject.SetActive(false); }
        foreach (GameObject gameObject in activeOnLoss) { gameObject.SetActive(false); }
    }

    // private void WinScreen()
    // {
    //     foreach (GameObject gameObject in activeOnWin) { gameObject.SetActive(true); }
    //     FindObjectOfType<Player>().enabled = false;
    // }

    // private void LoseScreen()
    // {
    //     foreach (GameObject gameObject in activeOnLoss) { gameObject.SetActive(true); }
    //     FindObjectOfType<Player>().enabled = false;
    // }

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
        // if (_space.currentSPACE_STATE == SPACE_STATE.START_SPACE)
        // {
        //     LevelStartLocation = _space.SpaceLocation;
        //     return;
        // }

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
    
    #endregion
}
