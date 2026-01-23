using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    public GameObject PopUpCanvas;
    public GameObject Pause;
    public GameObject Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PopUpCanvas.SetActive(true);
        Pause.SetActive(false);
        if (collision.CompareTag("Player"))
        {
          Player.SetActive(false);
        }
    }

}
