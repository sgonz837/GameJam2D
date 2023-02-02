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
    private bool tool;

    public int maxHealth = 3;

    private int currentHealth;
    private bool isDead = false;
    private void Start()
    {
        currentHealth = maxHealth;
    }

    IEnumerator Wait()
    {

        yield return new WaitForSeconds(2);
        GlobalVariables.playerAttack = false;
        Debug.Log("False");
        animator.SetBool("attack", true);
        GlobalVariables.playerHealth -= 10;
        Debug.Log("Hp: " + GlobalVariables.playerHealth);
        animator.SetBool("Take_Hit", false);
        tool = false;
        
    }
    IEnumerator WaitAndDie()
    {
        yield return new WaitForSeconds(1);
        this.gameObject.SetActive(false);
    }
    IEnumerator WaitAndAttack()
    {
        animator.SetBool("Move", false);
        animator.SetBool("Take_Hit", true);

        TakeDamage(1);
        Debug.Log(currentHealth);

        animator.SetBool("attack", false);
        yield return new WaitForSeconds(1);
        tool = false;
        GlobalVariables.playerAttack = false;
        GlobalVariables.enemyInDistance = false;
    }
    void Update()
    {
        if (isDead)
        {
            return;
        }

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
            GlobalVariables.enemyInDistance = true;


            if(tool == true)
            {
                StartCoroutine(WaitAndAttack());
            }
            else
            {
                //tool = false;
                //GlobalVariables.enemyInDistance = false;
                StartCoroutine(Wait());
            }
        }
        else
        {
            // Deactivate the "Attack" animation
            animator.SetBool("attack", false);
            animator.SetBool("Take_Hit", false);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            isDead = true;
            deathAnimation.SetTrigger("Die");
            StartCoroutine(WaitAndDie());

        }
    }
}
