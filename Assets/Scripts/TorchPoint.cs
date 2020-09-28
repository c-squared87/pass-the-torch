using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class TorchPoint : MonoBehaviour
{
    [SerializeField] GameObject activeSprite;
    [SerializeField] GameObject inactiveSprite;

    SpriteRenderer spriteRenderer;

    public Vector3 TorchPointLocation;
    [SerializeField] int stepsValue;
    public bool Active = true;

    private void Start() {
        SetSprite();
        TorchPointLocation = transform.position;
        FindObjectOfType<LevelManager>().UpdateTorchPoints(this);
    }

    void SetSprite()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.magenta;
    }

    public void HandOffTorch()
    {
        FindObjectOfType<Player>().AddToSteps(stepsValue);
        Destroy(gameObject);
    }
}
