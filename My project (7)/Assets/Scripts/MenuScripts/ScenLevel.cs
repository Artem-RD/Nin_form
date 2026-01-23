using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenLevel : MonoBehaviour
{
    [SerializeField]private int Index;

  public void LevlScen()
  {
        Time.timeScale = 1f;
        SceneManager.LoadScene(Index);
  }
}
