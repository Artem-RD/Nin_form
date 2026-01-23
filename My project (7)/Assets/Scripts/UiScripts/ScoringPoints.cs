using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoringPoints: MonoBehaviour
{
    [SerializeField] private TMP_Text Score;

    void Update()
    {
        Score.text = CoinPicker.coins.ToString();
    }

}
