using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
    }

    //this will be attached to the player
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GlobalVariables.enemyInDistance == true)
            {
                GlobalVariables.playerAttack = true;
                StartCoroutine(Wait());
            } 

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (GlobalVariables.playerAttack == true)
            {
                StartCoroutine(Wait());
             }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GlobalVariables.playerAttack = false;
            GlobalVariables.enemyInDistance = false;
        }
    }

}
