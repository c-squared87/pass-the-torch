using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum SPACE_STATE
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

    public Vector2 SpaceLocation { get; private set; }

    [SerializeField] SPACE_STATE currentSPACE_STATE = SPACE_STATE.OPEN;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SpaceLocation = gameObject.transform.position;

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