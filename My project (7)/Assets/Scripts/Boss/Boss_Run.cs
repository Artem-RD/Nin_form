using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Boss_Run : StateMachineBehaviour
{
    public float speed = 2.5f;
    public float attackRange = 0.5f;
    public float attackRange3 = 1f;

    private int rand;

    Transform player;
    Rigidbody2D rb;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       player = GameObject.FindGameObjectWithTag("Player").transform;
       rb = animator.GetComponent<Rigidbody2D>();

        rand = Random.Range(0, 1);
        if (rand == 1)
        {
            animator.SetTrigger("summon");
        }
        else 
        {
            animator.SetTrigger("Attack");
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<Boss>().LookAtPlayer();

        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        //float distans = Vector2.Distance(player.position, rb.position);

        //if (distans >= attackRange && distans <= attackRange3)
        //{
        //    animator.SetTrigger("Attack");
        //}
        //if (Vector2.Distance(player.position, rb.position) <= attackRange)
        //{
        //    animator.SetTrigger("skill");
        //}
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("skill");
    }

}
