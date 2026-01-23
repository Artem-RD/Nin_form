using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Attack : MonoBehaviour
{
    [Header("Attack Parametrs")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float damage;

    [Header("Skill Parametrs")]
    [SerializeField] private float rangeSkill;
    [SerializeField] private float damageSkill;

    [Header("Collider Parameters")]
    [SerializeField] private float DistanceCollider;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private float DistanceColliderSkill;
    [SerializeField] private BoxCollider2D boxColliderSkill;

    [Header("Player Layers")]
    [SerializeField] private LayerMask playerMask;
    private float cooldownTimer = Mathf.Infinity;

    private HealthPlayer healthPlayer;
    private Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
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
        if (PlayerInSkillField())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("skill");
            }
        }
    }

    private bool PlayerInSkillField()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxColliderSkill.bounds.center + transform.right * rangeSkill * transform.localScale.x * DistanceColliderSkill,
            new Vector3(boxColliderSkill.bounds.size.x * rangeSkill, boxColliderSkill.bounds.size.y, boxColliderSkill.bounds.size.z),
            0, Vector2.left, 0, playerMask);

        if (hit.collider != null)
        {
            healthPlayer = hit.transform.GetComponent<HealthPlayer>();
        }

        return hit.collider != null;
    }


    private bool PlayerInSinght()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * DistanceCollider,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerMask);

        if (hit.collider != null)
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
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(boxColliderSkill.bounds.center + transform.right * rangeSkill * transform.localScale.x * DistanceColliderSkill,
            new Vector3(boxColliderSkill.bounds.size.x * rangeSkill, boxColliderSkill.bounds.size.y, boxColliderSkill.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if (PlayerInSinght())
        {
            healthPlayer.TakeDamege(damage);
        }
    }

    private void SkillDamagePlayer()
    {
        if (PlayerInSkillField())
        {
            healthPlayer.TakeDamege(damage);
        }
    }
}
