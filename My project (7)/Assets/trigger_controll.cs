using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_controll : MonoBehaviour
{
    [SerializeField] GameObject controll;
    [SerializeField] GameObject trigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            controll.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            controll.SetActive(false);
            trigger.SetActive(false);
        }
    }
}
