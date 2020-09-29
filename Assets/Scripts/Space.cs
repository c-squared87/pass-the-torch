using UnityEngine;

public enum SPACE_STATE
{
    OPEN,
    BLOCKED,
    START_SPACE,
    EXIT_SPACE
}

[RequireComponent(typeof(SpriteRenderer))]
public class Space : MonoBehaviour
{
    public Vector3 SpaceLocation { get; private set; }
    public string SPACE_NAME { get; private set; }

    public SPACE_STATE currentSPACE_STATE = SPACE_STATE.OPEN;

    private void Start()
    {
        SpaceLocation = gameObject.transform.position;

        SPACE_NAME = gameObject.transform.position.ToString();
        gameObject.name = SPACE_NAME;
       
        FindObjectOfType<LevelManager>().UpdateSpace(this);
    }
}