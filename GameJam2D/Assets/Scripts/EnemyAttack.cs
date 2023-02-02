using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform player;
    public float activationDistance = 5.0f;
    public Animator animator;
    public Animator enemyAnimator;
    public Animator deathAnimation; // The death animation to play when the enemy dies
    private bool playerAttacks;
    public int playerMaxHealth = 3;
    private int playerCurrentHealth;
    private bool enemyDies = false;

    private void Start()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    IEnumerator EnemyAttacksPlayer()
    {
        GlobalVariables.playerAttack = false;
        animator.SetBool("attack", true);


        yield return new WaitForSeconds(5f);
        GlobalVariables.playerHealth -= 10;
        Debug.Log("Hpp: " + GlobalVariables.playerHealth);
        Debug.Log("Waited for 6 seconds");
        animator.SetBool("Take_Hit", false);
        playerAttacks = false;
        //break;
        yield return new WaitForSeconds(5f);

        
            
    }

    IEnumerator WaitAndDie()
    {
        yield return new WaitForSeconds(1);
        this.gameObject.SetActive(false);
    }

    IEnumerator EnemyGetsHit()
    {
            animator.SetBool("Move", false);
            animator.SetBool("attack", false);
            animator.SetBool("Take_Hit", true);
            //yield return new WaitForSeconds(1);
            TakeDamage(1);
            yield return new WaitForSeconds(1f);
            Debug.Log(playerCurrentHealth);

            playerAttacks = false;
            GlobalVariables.playerAttack = false;
            GlobalVariables.enemyInDistance = false;
    }


    void Update()
    {
        if (enemyDies)
        {
            return;
        }

        if(GlobalVariables.playerAttack == true)
        {
            playerAttacks = true;
        }
        else
        {
            playerAttacks = false;
        }

        // Get the distance between the enemy and the player
        float distance = Vector3.Distance(transform.position, player.position);

        // Check if the distance is less than the activation distance
        if (distance < activationDistance)
        {
            GlobalVariables.enemyInDistance = true; //if player is within atttack distance of the enemy

            if(playerAttacks == true)
            {
                StartCoroutine(EnemyGetsHit());
                playerAttacks = false;
            }
            else
            {
                //tool = false;
                GlobalVariables.enemyInDistance = false;
                StartCoroutine(EnemyAttacksPlayer());
            }
        }
        else
        {

            GlobalVariables.enemyInDistance = false;
            // Deactivate the "Attack" animation
            animator.SetBool("attack", false);
            animator.SetBool("Take_Hit", false);
        }
    }

    public void TakeDamage(int damage)
    {
        playerCurrentHealth -= damage;

        if(playerCurrentHealth <= 0)
        {
            enemyDies = true;
            deathAnimation.SetTrigger("Die");
            StartCoroutine(WaitAndDie());

        }
    }
}
