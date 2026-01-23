using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBarBoss : MonoBehaviour
{
    [SerializeField]
    private Health health;
    [SerializeField]
    private Image Bar;
    [SerializeField]
    private Image currenthealthBar;

    private void Start()
    {
        Bar.fillAmount = health.currentHealth / 200;
    }

    private void Update()
    {
        currenthealthBar.fillAmount = health.currentHealth / 200;
    }
}
