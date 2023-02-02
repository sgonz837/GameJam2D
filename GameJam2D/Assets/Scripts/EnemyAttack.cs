using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform player;
    public float activationDistance = 5.0f;
    public Animator animator;
    public Animator enemyAnimator;
    private bool tool;

    IEnumerator WaitAndAttack()
    {
        animator.SetBool("Move", false);
        animator.SetBool("Take_Hit", true);
        animator.SetBool("attack", false);
        yield return new WaitForSeconds(1);
        tool = false;
        GlobalVariables.playerAttack = false;
    }
    void Update()
    {

        if(GlobalVariables.playerAttack == true)
        {
            tool = true;
        }
        else
        {
            tool = false;
        }

        // Get the distance between the enemy and the player
        float distance = Vector3.Distance(transform.position, player.position);

        // Check if the distance is less than the activation distance
        if (distance < activationDistance)
        {

            if(tool == true)
            {
                StartCoroutine(WaitAndAttack());
            }
            else
            {
                GlobalVariables.playerAttack = false;
                Debug.Log("False");
                animator.SetBool("attack", true);
                animator.SetBool("Take_Hit", false);
                tool = false;
            }
        }
        else
        {
            // Deactivate the "Attack" animation
            animator.SetBool("attack", false);
            animator.SetBool("Take_Hit", false);
        }
    }
}
