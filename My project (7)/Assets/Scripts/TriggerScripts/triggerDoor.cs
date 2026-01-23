using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDoor : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] GameObject tielmapDoor;
    [SerializeField] GameObject Boss;
    [SerializeField] GameObject BossHelthBar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            door.SetActive(true);
            tielmapDoor.SetActive(true);
            Boss.SetActive(true);
            BossHelthBar.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
