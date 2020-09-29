using System.Collections;
using UnityEngine;

public class NumberDisplay : MonoBehaviour
{
    [SerializeField] Sprite[] numberIcons;

    SpriteRenderer spriteRenderer;

    public void InitNumberDisplay(int _num)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = numberIcons[_num];

        StartCoroutine(Breathe());
    }

    public void SetNumberDisplay(int _num)
    {
        spriteRenderer.sprite = numberIcons[_num];
    }

    IEnumerator Breathe()
    {
        while (true)
        {
            transform.position += new Vector3(0, .1f, 0);
            yield return new WaitForSeconds(0.5f);
            transform.position -= new Vector3(0, .1f, 0);
            yield return new WaitForSeconds(0.5f);
        }
    }

}
