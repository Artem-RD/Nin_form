using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinPicker : MonoBehaviour
{
    public static float coins = 0;
    public TMP_Text CoinText;

    public void Start()
    {
        coins = 0;
    }

    public void Update()
    {
        CoinText.text = coins.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            coins += 50;
            CoinText.text = coins.ToString();
            Destroy(collision.gameObject);
        }
    }
}
