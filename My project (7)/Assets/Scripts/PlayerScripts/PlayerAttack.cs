using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private float timeAttack;
    public float startTimeAttack;

    public Transform attackPos;
    public LayerMask enemy;
    public float attackRange;
    public float damege;
    public Animator animator;

    private void Update()
    {
        if(timeAttack <= 0) 
        {
            if(Input.GetMouseButton(0)) 
            {
                animator.SetTrigger("attack");
            }
            if (Input.GetMouseButton(1))
            {
                animator.SetTrigger("attack2");
            }
            timeAttack = startTimeAttack;
        }
        else
        {
            timeAttack -= Time.deltaTime;
        }
    }
    public void ONAttack()
    {
      Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange,enemy);
      for(int i = 0; i < enemies.Length; i++)
      {
          enemies[i].GetComponent<Health>().TakeDamage(damege);
      }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
