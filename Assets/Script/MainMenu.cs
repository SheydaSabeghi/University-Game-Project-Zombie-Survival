using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text highScoreText;
    //public GameObject PanelPause;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playGame(){
        SceneManager.LoadScene(0);
    }

    public void back(){
        SceneManager.LoadScene(1);
    }

    public void ResetScore(){
        PlayerPrefs.SetInt("HighScore", 0);
        PlayerPrefs.Save();
        highScoreText = GameObject.Find("Hscore").GetComponent<Text>();
        highScoreText.text = "High Score : 0";
    }

    public void ExitGame(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}