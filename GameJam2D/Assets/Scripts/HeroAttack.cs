using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{

    //this will be attached to the player
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GlobalVariables.playerAttack = true;
           // Debug.Log("Player has Attacked!");

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //Debug.Log("Test on hero");
            if (GlobalVariables.playerAttack == true)
            {
               // GlobalVariables.playerAttack = true;
                //Debug.Log("hit! on ememy");

             }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GlobalVariables.playerAttack = false;
            //Debug.Log("False on enemy");
        }
    }

}
