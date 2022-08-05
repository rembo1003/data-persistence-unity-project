using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerNameText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerName;

    public void SetText(string text)
    {
        playerName.text = text;
    }

}
