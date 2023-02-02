using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    public GameObject cutscene; // Assign the cutscene object in the inspector

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Check if the colliding object has the "Player" tag
        {
            cutscene.SetActive(true); // Enable the cutscene object
        }
    }
}
