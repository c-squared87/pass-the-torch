﻿using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int stepsRemaining = 4;
    LevelManager levelManager;

    NumberDisplay numberDisplay;

    private void Start()
    {
        numberDisplay = GetComponentInChildren<NumberDisplay>();
        numberDisplay.InitNumberDisplay(stepsRemaining);

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
                EventsSystem.PlayerFail();
                return;
            }
            stepsRemaining--;
            EventsSystem.StepsChanged(stepsRemaining);
            numberDisplay.SetNumberDisplay(stepsRemaining);
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += Vector3.right;
            if (!levelManager.CanMove(transform.position))
            {
                transform.position -= Vector3.right;
                EventsSystem.PlayerFail();
                return;
            }
            stepsRemaining--;
            EventsSystem.StepsChanged(stepsRemaining);
            numberDisplay.SetNumberDisplay(stepsRemaining);
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position += Vector3.up;
            if (!levelManager.CanMove(transform.position))
            {
                transform.position -= Vector3.up;
                EventsSystem.PlayerFail();
                return;
            }
            stepsRemaining--;
            EventsSystem.StepsChanged(stepsRemaining);
            numberDisplay.SetNumberDisplay(stepsRemaining);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += Vector3.down;
            if (!levelManager.CanMove(transform.position))
            {
                transform.position -= Vector3.down;
                EventsSystem.PlayerFail();
                return;
            }
            stepsRemaining--;
            EventsSystem.StepsChanged(stepsRemaining);
            numberDisplay.SetNumberDisplay(stepsRemaining);
        }
    }

    public void AddToSteps(int _stepsToAdd)
    {
        stepsRemaining += _stepsToAdd;
        EventsSystem.StepsChanged(stepsRemaining);
        numberDisplay.SetNumberDisplay(stepsRemaining);
    }
}
