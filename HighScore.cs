using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "HighScore : " + PlayerPrefs.GetInt("HighScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
