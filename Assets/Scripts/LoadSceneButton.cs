using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{
    [SerializeField] string sceneToLoad;
    Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(LoadScene);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
