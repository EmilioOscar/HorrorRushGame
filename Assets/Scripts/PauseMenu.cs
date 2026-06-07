using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
       public GameObject PausePanel;


    // Update is called once per frame
    void Update()
    {
        
    }


    public void pause()
    {
         PausePanel.SetActive(true);
         Time.timeScale = 0;
    } 

     public void Continue()
     {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
     }
}
