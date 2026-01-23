using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollection : MonoBehaviour
{
    [SerializeField]private float healthValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<HealthPlayer>().AddHealth(healthValue);
            gameObject.SetActive(false);
        }
    }
}
