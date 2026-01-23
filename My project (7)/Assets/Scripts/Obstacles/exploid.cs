using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exploid : MonoBehaviour
{
    public GameObject Exploting;
    public GameObject StopTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Instantiate(Exploting, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(StopTrigger);
        }
    }
}
