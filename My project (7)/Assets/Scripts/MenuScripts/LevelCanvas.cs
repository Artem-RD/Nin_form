using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCanvas : MonoBehaviour
{
    public GameObject LevCanvas;
    public GameObject MainCanvas;
    public GameObject SettingCanvas;
    public void Click()
    {
        MainCanvas.SetActive(false);
        LevCanvas.SetActive(true);
    }
    
    public void ExitButton()
    {
        Application.Quit();
    }
    public void Setting()
    {
        MainCanvas.SetActive(false);
        SettingCanvas.SetActive(true);
    }

}
