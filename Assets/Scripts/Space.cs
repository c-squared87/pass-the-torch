using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] GameObject openSprite;
    [SerializeField] GameObject blockedSprite;
    [SerializeField] GameObject startSprite;
    [SerializeField] GameObject exitSpace;

    SpriteRenderer spriteRenderer;

    public Vector3 SpaceLocation { get; private set; }
    public string SPACE_NAME { get; private set; }

    public SPACE_STATE currentSPACE_STATE = SPACE_STATE.OPEN;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SpaceLocation = gameObject.transform.position;
        SPACE_NAME = gameObject.transform.position.ToString();
        gameObject.name = SPACE_NAME;

        SetSprite();
        FindObjectOfType<LevelManager>().UpdateSpace(this);
    }

    void SetSprite()
    {
        switch (currentSPACE_STATE)
        {
            case SPACE_STATE.OPEN:
                spriteRenderer.color = Color.grey;
                break;
            case SPACE_STATE.BLOCKED:
                spriteRenderer.color = Color.red;
                break;
            case SPACE_STATE.START_SPACE:
                spriteRenderer.color = Color.green;
                break;
            case SPACE_STATE.EXIT_SPACE:
                spriteRenderer.color = Color.yellow;
                break;
        }
    }
}