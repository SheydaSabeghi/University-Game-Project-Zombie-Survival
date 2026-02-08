using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PanelPause;

    // Start is called before the first frame update
    void Start()
    {
        PanelPause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pauseButton(){
        PanelPause.SetActive(true);
        Time.timeScale = 0;
    }

    public void continueButton(){
        PanelPause.SetActive(false);
        Time.timeScale = 1;
    }
}
