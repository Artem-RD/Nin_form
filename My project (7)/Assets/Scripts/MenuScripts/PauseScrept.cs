using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseScrept : MonoBehaviour
{
    public GameObject PauseCanvas;
    public GameObject MainPauseCanvas;

    public void Start()
    {
        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { 
           MainPauseCanvas.SetActive(true);
           PauseCanvas.SetActive(false);
           Time.timeScale = 0f;       
        }
    }

    public void Click()
    {
        MainPauseCanvas.SetActive(true);
        PauseCanvas.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        MainPauseCanvas.SetActive(false);
        PauseCanvas.SetActive(true);
        Time.timeScale = 1f;
    }

    public void BackMenu()
    {
        SceneManager.LoadScene(0);
        PauseCanvas.SetActive(false);
    }

    public void ResetLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
