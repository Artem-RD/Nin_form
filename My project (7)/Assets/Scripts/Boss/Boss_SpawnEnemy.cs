using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnEnemy;
    [SerializeField] private Transform[] spawnPoint;


    public int spawnCount;
    public int NowSpawnCount;

    private int randEnemy;
    private int randPoint;

    private void Start()
    {
    }


    public void SpawnEnemy()
    {
        

        if( NowSpawnCount < spawnCount) 
        {
            randEnemy = Random.Range(0, spawnEnemy.Length);
            randPoint = Random.Range(0, spawnPoint.Length);

            Instantiate(spawnEnemy[randEnemy], spawnPoint[randPoint].transform.position, Quaternion.identity);

            NowSpawnCount++;
        }

    }

   

 }
