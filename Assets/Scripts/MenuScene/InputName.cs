using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputName : MonoBehaviour
{
    [SerializeField] string playerName;
    [SerializeField] TMP_InputField inputName;

    void Awake()
    {
        inputName = GetComponent<TMP_InputField>();
        inputName.onValueChanged.AddListener(delegate{SetName();});
        if(DataPersistence.Instance != null)
        {
            inputName.text = DataPersistence.Instance.GetPlayerNameHS();
        }
    }

    void SetName()
    {
        playerName = inputName.text;
        
        if(DataPersistence.Instance != null)
        {
            DataPersistence.Instance.PlayerNameLoad(playerName);
        }
    }

    public string GetName()
    {
        return playerName;
    }
  
}
