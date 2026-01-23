using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoss : MonoBehaviour
{

    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }

    private bool dead;

    public Animator anim;

    private float time = 1f;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (dead == true)
        {
            time = time - Time.deltaTime;
        }
        if(time <= 0) 
        {
            gameObject.SetActive(false);
        }
    }


    public void TakeDamege(float damege)
    {
        currentHealth = Mathf.Clamp(currentHealth - damege, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("Death");
                dead = true;
            }

        }
    }

}
