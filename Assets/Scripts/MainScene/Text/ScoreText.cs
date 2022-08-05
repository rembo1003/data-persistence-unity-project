using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public void SetText(string scoreTextNew)
    {
        scoreText.text = scoreTextNew;
    }
}
