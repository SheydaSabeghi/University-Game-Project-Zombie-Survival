using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadHighScore : MonoBehaviour
{
    public Text highScoreText;
    int highScore = 0;


    // Start is called before the first frame update
    void Start()
    {
        highScoreText = GameObject.Find("Hscore").GetComponent<Text>();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score:" + highScore.ToString();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
