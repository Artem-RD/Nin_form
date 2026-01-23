using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform FirePoint;

    public void Shoot()
    {
        Instantiate(bullet,FirePoint.position,FirePoint.rotation);
    }
}
