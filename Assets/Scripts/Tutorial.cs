using UnityEngine.UI;
// using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public Text text_1, text_2;

    [SerializeField] GameObject newGameButton, mainMenuButton, clickthroughButton;

    [SerializeField] GameObject playerItem, exitItem, torchItem;

    public string[] Prompts1 = new string[]{
        "This is Torch. Say Hello!",
        "Get Torch to the exit!",
        "Need more steps?",
        "Ready to play?"
    };
    public string[] Prompts2 = new string[]{
        "Move Torch with the Arrow keys",
        "moving torch costs steps",
        "snag some at a fuel stop!",
        "    "
    };

    int currentTutorialStep;

    private void Start()
    {
        if (text_1 == null) { text_1 = GetComponent<Text>(); }
        if (text_2 == null) { text_2 = GetComponent<Text>(); }

        InitTutorial();
    }

    void InitTutorial()
    {
        currentTutorialStep = 0;

        playerItem.SetActive(false);
        exitItem.SetActive(false);
        torchItem.SetActive(false);

        newGameButton.SetActive(false);
        mainMenuButton.SetActive(false);

        playerItem.SetActive(true);

        UpdateUI();
    }

    public void AdvanceTutorial() // THIS IS CALLED FROM A SCREEN COVERING UI BUTTON
    {
        currentTutorialStep++;

        switch (currentTutorialStep)
        {
            case 1:
                exitItem.SetActive(true);
                break;
            case 2:
                torchItem.SetActive(true);
                break;
            case 3:
                exitItem.SetActive(false);
                torchItem.SetActive(false);

                newGameButton.SetActive(true);
                mainMenuButton.SetActive(true);
                clickthroughButton.SetActive(false);
                break;
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        text_1.text = Prompts1[currentTutorialStep];
        text_2.text = Prompts2[currentTutorialStep];
    }
}
