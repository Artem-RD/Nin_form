using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotingScripts : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Explode()); 
    }

    IEnumerator Explode()
    {

        yield return new WaitForSeconds(0.9f); 

        Destroy(gameObject);
    }
}
