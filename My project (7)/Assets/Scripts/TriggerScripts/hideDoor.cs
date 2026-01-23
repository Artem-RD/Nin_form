using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideDoor : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] GameObject tielmapDoor;
    [SerializeField] GameObject HealthBar;
    void Update()
    {
        if(Health.openDoor == true)
        {
            door.SetActive(false);
            tielmapDoor.SetActive(false);
            HealthBar.SetActive(false);
        }
    }
}
