using UnityEngine;

public class Player : MonoBehaviour
{
    int stepsRemaining = 4;
    LevelManager levelManager;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();

        transform.position = levelManager.LevelStartLocation;
    }

    private void Update()
    {
        if (stepsRemaining <= 0)
        {
            EventsSystem.GameLost();
            this.enabled = false;
        }
        if (stepsRemaining > 0) { Move(); }
    }

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left;
            if (!levelManager.CanMove(transform.position))
            {
                transform.position -= Vector3.left;
                return;
            }
            stepsRemaining--;
            EventsSystem.PlayerMoved(stepsRemaining);
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += Vector3.right;
            if (!levelManager.CanMove(transform.position))
            {
                transform.position -= Vector3.right;
                return;
            }
            stepsRemaining--;
            EventsSystem.PlayerMoved(stepsRemaining);
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position += Vector3.up;
            if (!levelManager.CanMove(transform.position))
            {
                transform.position -= Vector3.up;
                return;
            }
            stepsRemaining--;
            EventsSystem.PlayerMoved(stepsRemaining);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += Vector3.down;
            if (!levelManager.CanMove(transform.position))
            {
                transform.position -= Vector3.down;
                return;
            }
            stepsRemaining--;
            EventsSystem.PlayerMoved(stepsRemaining);
        }
    }

    public void AddToSteps(int _stepsToAdd)
    {
        // TODO: 
        // EventsSystem.HandOffComplete();
        stepsRemaining += _stepsToAdd;
    }
}
