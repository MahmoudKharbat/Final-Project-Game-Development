using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wins : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_TextMeshPro;
    void Start()
    {
        if (GlobalManager.Instance != null)
        {
            m_TextMeshPro.text = "" + GlobalManager.Instance.getWins();
            Debug.Log("" + GlobalManager.Instance.getWins());
        }
        else
            m_TextMeshPro.text = "0";
    }
    void Update()
    {
        
    }
}
