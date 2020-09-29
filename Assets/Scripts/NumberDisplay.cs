using UnityEngine;

public class NumberDisplay : MonoBehaviour
{
    [SerializeField] Sprite[] numberIcons;

    SpriteRenderer spriteRenderer;

    public void InitNumberDisplay(int _num)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = numberIcons[_num];
    }

    public void SetNumberDisplay(int _num){
        spriteRenderer.sprite = numberIcons[_num];
    }
}
