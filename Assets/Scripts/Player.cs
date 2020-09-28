using UnityEngine;

public class Player : MonoBehaviour
{
    int stepsRemaining = 3;
    LevelManager levelManager;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void Update()
    {
        if (stepsRemaining > 0)
        {
            Move();
        }
    }

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left;
            if (levelManager.CanMove(transform.position))
            {
                return;
            }
            else
            {
                transform.position -= Vector3.left;
            }
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += Vector3.right;
            if (levelManager.CanMove(transform.position))
            {
                return;
            }
            else
            {
                transform.position -= Vector3.right;
            }
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position += Vector3.up;
            if (levelManager.CanMove(transform.position))
            {
                return;
            }
            else
            {
                transform.position -= Vector3.up;
            }
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += Vector3.down;
            if (levelManager.CanMove(transform.position))
            {
                return;
            }
            else
            {
                transform.position -= Vector3.down;
            }
        }
    }
}
