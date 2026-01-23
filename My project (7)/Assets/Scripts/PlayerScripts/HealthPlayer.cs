using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }

    private bool dead;

    public Animator anim;

    public GameObject DeathCanvas;
    public GameObject PauseCanvas;

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
        TriggerDeath();
    }


    public void TakeDamege(float damege)
    {
        currentHealth = Mathf.Clamp(currentHealth - damege, 0, startingHealth);

        if (currentHealth > 0 )
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            if(!dead)
            {
                anim.SetTrigger("Death");
                GetComponent<PlayerMovment>().enabled = false;
                dead = true;
            }
            
        }
    }

    public void AddHealth(float value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, startingHealth);
    }

    private void TriggerDeath()
    {
        if (time < 0f)
        {
            PauseCanvas.SetActive(false);
            DeathCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
    }

}
