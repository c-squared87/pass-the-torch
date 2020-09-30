using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            FindObjectOfType<Tutorial>().AdvanceTutorial();
            Debug.Log("triggered");
        }
    }
}
