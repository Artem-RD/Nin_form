using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneTrigger : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject TimeLineManager;
    [SerializeField] private GameObject cutSceneTrigger;
    [SerializeField] private float time;

    private bool managerActiv;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TimeLineManager.SetActive(true);
            managerActiv = true;
        }
    }

    private void Update()
    {
        if (managerActiv == true)
        {
            time = time - Time.deltaTime;
        }
        timeStop();
        ActiveCutScene();
    }

    private void timeStop()
    {
        if(time < 0f)
        {
            TimeLineManager.SetActive(false);
            managerActiv = false;
            cutSceneTrigger.SetActive(false);
        }
    }

    private void ActiveCutScene()
    {
        if(TimeLineManager.activeSelf)
        {
            cutSceneTrigger.SetActive(true);
            Player.SetActive(false);
        }
        else
        {
            Player.SetActive(true);
            TimeLineManager.SetActive(false);
        }
    }
}
