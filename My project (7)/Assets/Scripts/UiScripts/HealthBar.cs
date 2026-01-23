using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField]
    private HealthPlayer playerhealth;
    [SerializeField]
    private Image Bar;
    [SerializeField]
    private Image currenthealthBar;

    private void Start()
    {
        Bar.fillAmount = playerhealth.currentHealth / 100;
    }

    private void Update()
    {
        currenthealthBar.fillAmount = playerhealth.currentHealth / 100;
    }
}
