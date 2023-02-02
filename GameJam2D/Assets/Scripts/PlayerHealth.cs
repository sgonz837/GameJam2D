using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    void Update()
    {
        if (GlobalVariables.playerHealth <= 0)
        {
            // Code for player death
            Debug.Log("Player died!");
        }

    }
}
