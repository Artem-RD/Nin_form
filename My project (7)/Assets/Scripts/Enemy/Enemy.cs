using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header ("Attack Parametrs")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float damage;

    [Header("Collider Parameters")]
    [SerializeField] private float DistanceCollider;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layers")]
    [SerializeField] private LayerMask playerMask;
    private float cooldownTimer = Mathf.Infinity;

    private HealthPlayer healthPlayer;
    private Animator anim;

    private EnemyPatrol enemyPatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (PlayerInSinght())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("Attack");
            }
        }
        if(enemyPatrol != null) 
        {
            enemyPatrol.enabled = !PlayerInSinght();
        }
    }

    private bool PlayerInSinght()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * DistanceCollider,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y,boxCollider.bounds.size.z),
            0, Vector2.left, 0,playerMask);

        if(hit.collider != null)
        {
            healthPlayer = hit.transform.GetComponent<HealthPlayer>();
        }

        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * DistanceCollider,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if (PlayerInSinght()) 
        {
            healthPlayer.TakeDamege(damage);
        }
    }

}
