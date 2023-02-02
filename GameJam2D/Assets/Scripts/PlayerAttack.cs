using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator enemyAnimator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Test");
            if (GlobalVariables.playerAttack == true)
            {
            enemyAnimator.SetBool("attack", false);
            enemyAnimator.SetBool("Take_Hit", true);
                Debug.Log("hit!");

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            //if (Input.GetMouseButtonDown(0))
            //{
                Debug.Log("False");
                enemyAnimator.SetBool("Take_Hit", false);
           // }
        }
    }
}
