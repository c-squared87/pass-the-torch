using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class TorchPoint : MonoBehaviour
{
    [SerializeField] GameObject activeSprite;
    [SerializeField] GameObject inactiveSprite;

    SpriteRenderer spriteRenderer;

    NumberDisplay numberDisplay;

    public Vector3 TorchPointLocation;
    [SerializeField] int stepsValue;
    public bool Active = true;

    private void Start()
    {
        numberDisplay = GetComponentInChildren<NumberDisplay>();
        numberDisplay.InitNumberDisplay(stepsValue);

        SetSprite();
        TorchPointLocation = transform.position;
        FindObjectOfType<LevelManager>().UpdateTorchPoints(this);
    }

    void SetSprite()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void HandOffTorch()
    {
        FindObjectOfType<Player>().AddToSteps(stepsValue);
        EventsSystem.PlayerSuccess();
        Destroy(gameObject);
    }
}
