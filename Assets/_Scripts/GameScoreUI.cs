using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    
    private void Start()
    {
        Bird.Instance.OnScoreChanged += Bird_OnScoreChanged; 
    }

    private void OnDestroy()
    {
        Bird.Instance.OnScoreChanged -= Bird_OnScoreChanged; 
    }

    private void Bird_OnScoreChanged()
    {
        scoreText.text = Bird.Instance.Score.ToString();
    }
}
