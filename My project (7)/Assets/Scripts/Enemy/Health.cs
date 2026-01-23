using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
//using static UnityEditor.Progress;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Health : MonoBehaviour
{
    private ItemDrop getItem;

    [SerializeField] private float countCoin;

    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }

    private bool dead;
    public static bool openDoor;
    private Animator anim;

    private float time = 1f;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        getItem = GetComponent<ItemDrop>();
        currentHealth = startingHealth;
    }

    private void Update()
    {
        if (dead == true)
        {
            time = time - Time.deltaTime;
        }
        TriggerDeath();
    }

    public void TakeDamage(float damege)
    {
        currentHealth = Mathf.Clamp(currentHealth - damege, 0, startingHealth);

        

        if (gameObject.CompareTag("Boss"))
        {
            if(currentHealth <= 100)
            {
                GetComponent<Animator>().SetBool("IsStage2", true);
            }
            if(currentHealth > 0 && currentHealth <=100)
            {
                anim.SetTrigger("hurt2");
            }
        }

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                if (GetComponentInParent<EnemyPatrol>() != null)
                {
                    GetComponentInParent<EnemyPatrol>().enabled = false;
                }
                if(GetComponent<Enemy>() != null) 
                {
                    GetComponent<Enemy>().enabled = false;
                }
                if (getItem != null)
                {
                    getItem.DropItem();
                    Debug.Log("Dropped an Item " + getItem);
                }

                CoinPicker.coins += countCoin;

                dead = true;
            }

        }
 
    }
    void TriggerDeath()
        {
            if (time < 0f)
            {
              if (gameObject.CompareTag("Boss"))
              {
                openDoor = true;
              }
               Destroy(gameObject);
            }
        }
}
