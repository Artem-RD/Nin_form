using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheEnd: MonoBehaviour
{
    [SerializeField] private int Index;

    public GameObject TheEndCanvs;

    private float time = 2f;
    private bool starttime = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
       starttime = true;
       TheEndCanvs.SetActive(true);
    }
    private void Update()
    {
        if (starttime == true)
        {
            time = time - Time.deltaTime;
        }
        EndTrigger();
    }
    private void EndTrigger()
    {
        if (time < 0f)
        {   
            TheEndCanvs.SetActive (false);
            Time.timeScale = 1f;
            SceneManager.LoadScene(Index);
        }
    }
    
}
