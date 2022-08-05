using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;

    public void SetText(string text)
    {
        highScoreText.text = text;
    }
}
