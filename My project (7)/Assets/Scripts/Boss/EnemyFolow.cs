using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFolow : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] float agroRange;
    [SerializeField] float moveSpeed;
    [SerializeField] private float damage;
    [SerializeField] private float Enemydamage;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        float distansToPlayer = Vector2.Distance(transform.position, player.position);

        if(distansToPlayer < agroRange)
        {
            FolowPlayer();
        }
        else
        {
            Stop();
        }
    }

    void FolowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    void Stop()
    {
        transform.position = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HealthPlayer>().TakeDamege(damage);
            gameObject.GetComponent<Health>().TakeDamage(Enemydamage);
        }
    }
}
